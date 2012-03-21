using System;
using System.Collections;
using System.Collections.Generic;
using RomViewer.Core;
using RomViewer.Core.Mapping;
using RomViewer.Core.NPCs;
using SharpLite.Domain.DataInterfaces;

namespace RomViewer.Tasks
{
    public class MapBuilder
    {
        private IRepository<MapZone> _zoneRepo;
        private IRepository<MapPoint> _pointRepo;
        private INonPlayerEntityRepository _npeRepo;

        public MapBuilder(INonPlayerEntityRepository npeRepo, IRepository<MapPoint> pointRepo, IRepository<MapZone> zoneRepo)
        {
            _npeRepo = npeRepo;
            _pointRepo = pointRepo;
            _zoneRepo = zoneRepo;
        }

        public Map BuildMap()
        {

            var allZones = _zoneRepo.GetAll();
            List<MapZone> zones = new List<MapZone>(allZones);
            var allPoints = _pointRepo.GetAll();
            List<MapPoint> points = new List<MapPoint>(allPoints);

            //locate all npc's on the map and associate with a node
            var allNpcs = _npeRepo.GetAll();
            List<NonPlayerEntity> npcs = new List<NonPlayerEntity>(allNpcs);


            Map map = new Map(zones, points, npcs);
            map.Chart();
            return map;
        }
    }

    public class Map
    {
        private Hashtable _mapPoints = new Hashtable();
        private Hashtable _mapZones = new Hashtable();
        private List<NonPlayerEntity> _npcs = new List<NonPlayerEntity>();
        private Hashtable _npcLookup = new Hashtable();
        private Hashtable _npcByRomId = new Hashtable();
        private Hashtable _mappedPoints = new Hashtable();
        private Hashtable _npcLocations = new Hashtable();

        public Hashtable MappedPoints
        {
            get { return _mappedPoints; }
        }

        public Hashtable MapPoints
        {
            get { return _mapPoints; }
        }

        public Map(List<MapZone> zones, List<MapPoint> points, List<NonPlayerEntity> npcs)
        {
            foreach (var zone in zones){_mapZones.Add(zone.RomId, zone);}
            foreach (var npc in npcs)
            {
                string key = npc.RomId.ToString() + "." + npc.UniqueId.ToString();
                if (_npcLookup.ContainsKey(key)) continue;

                _npcLookup.Add(key, npc);
                if (_npcByRomId.ContainsKey(npc.RomId)) continue;
                _npcByRomId.Add(npc.RomId, npc);
            }
            _npcs = npcs;
            foreach (var point in points)
            {
                _mapPoints.Add(point.Id, point);
                _mappedPoints.Add(point.Id, new PlottedMapPoint(point));
            }
        }

        public void Chart()
        {
            //locate all npcs
            foreach (var npc in _npcs)
            {
                NonPlayerEntity entity = npc;
                Vector3 coords = new Vector3(entity.X, entity.Y, entity.Z);
                PlottedMapPoint pt = FindNearest(coords, entity.ZoneId);
                if ((pt!=null) && (pt.Location.Distance(coords) < 800))
                {
                    pt.AddNPC(entity);
                    _npcLocations.Add(entity, pt);
                }
            }

            //find shortest routes for each type (caching here so faster when playing game).

        }

        private class mapNode
        {
            public PlottedMapPoint MapPoint;
            public double distance;
            public mapNode Parent;
            public MapLink link;
            public Vector3 Location;

            public mapNode(PlottedMapPoint mapPoint, double distance)
            {
                MapPoint = mapPoint;
                Location = mapPoint.Location;
                this.distance = distance;
            }
        }

        class MapNodeComparer : IComparer
        {
            public int Compare(object O1, object O2)
            {
                mapNode mn1 = (mapNode)O1;
                mapNode mn2 = (mapNode)O2;

                return (int) (mn1.distance - mn2.distance);
            }
        }

        public List<MapLink> BuildRoute(MapPoint start, MapPoint destination)
        {
            List<MapLink> result = new List<MapLink>();

            mapNode beginning = null;
            mapNode ending = null;
            PlottedMapPoint pStart = (PlottedMapPoint)_mappedPoints[start.Id];
            PlottedMapPoint pDestination = (PlottedMapPoint) _mappedPoints[destination.Id];


            Dictionary<int, mapNode> nodes = new Dictionary<int, mapNode>();
            beginning = new mapNode(pStart, 0);
            ending= new mapNode(pDestination, double.MaxValue);
            nodes.Add(pStart.MapPoint.Id, beginning);
            nodes.Add(pDestination.MapPoint.Id, ending);

            foreach (DictionaryEntry entry in _mappedPoints)
            {
                if ((entry.Value == pStart) || (entry.Value == pDestination)) continue;
                mapNode node = new mapNode((PlottedMapPoint)entry.Value, double.MaxValue);
                nodes.Add(node.MapPoint.MapPoint.Id, node);
            }


            SortableList openList = new SortableList(new MapNodeComparer());
            openList.KeepSorted = true;
            openList.AddDuplicates = true;

            openList.Add(beginning);
            Dictionary<int, mapNode> closedList = new Dictionary<int, mapNode>();

            bool found = false;
            while ((!found) && (openList.Count > 0))
            {
                mapNode current = (mapNode) openList[0];
                if (current == ending)
                {
                    found = true;
                }
                else
                {
                    closedList.Add(current.MapPoint.MapPoint.Id, current);
                    openList.Remove(current);

                    foreach (MapLink link in current.MapPoint.Links)
                    {
                        PlottedMapPoint end = (PlottedMapPoint) _mappedPoints[link.End.Id];
                        mapNode nEnd = nodes[link.End.Id];

                        double distance = 0;
                        if (link.LinkType == LinkType.Teleport) distance = 2000 + current.distance;
                        else
                            distance = current.Location.Distance(end.Location) + current.distance;

                        if (distance < nEnd.distance)
                        {
                            nEnd.distance = distance;
                            nEnd.Parent = current;
                            nEnd.link = link;
                            if ((!closedList.ContainsKey(end.MapPoint.Id)) && (!_sortedListContains(openList, nEnd)))
                            {
                                openList.Add(nEnd);
                            }
                        }
                    }
                }
            }

            if (found)
            {
                mapNode node = ending;
                while (node != beginning)
                {
                    result.Insert(0, node.link);
                    node = node.Parent;
                }
            }

            


            return result;
        }

        private bool _sortedListContains(SortableList list, object o)
        {
            foreach (var item in list)
            {
                if (item == o) return true;
            }
            return false;
        }

        public PlottedMapPoint FindNearest(Vector3 location, int zoneId)
        {
            MapZone zone = (MapZone) _mapZones[zoneId];

            PlottedMapPoint result = null;
            double distance= 0;
            foreach (DictionaryEntry entry in _mappedPoints)
            {
                PlottedMapPoint pt = (PlottedMapPoint) entry.Value;
                if (pt.MapPoint.MapZone == zone)
                {
                    if (result == null)
                    {
                        result = pt;
                        distance = pt.Location.Distance(location);
                    }
                    else if (pt.Location.Distance(location) < distance)
                    {
                        result = pt;
                        distance = pt.Location.Distance(location);
                    }
                }
            }


            return result;
        }

        public List<MapLink> BuildRoute(Vector3 start, int zoneId, MapPoint destination)
        {
            PlottedMapPoint pStart = FindNearest(start, zoneId);
            if (pStart == null) return new List<MapLink>();

            return BuildRoute(pStart.MapPoint, destination);
        }

        public NonPlayerEntity GetEntity(int npeId, int uniqueId)
        {
            string key = npeId.ToString() + "." + uniqueId.ToString();

            if (_npcLookup.ContainsKey(key)) return (NonPlayerEntity) _npcLookup[key];
            return null;
        }

        public NonPlayerEntity GetEntity(int npeId)
        {
            if (_npcByRomId.ContainsKey(npeId)) return (NonPlayerEntity)_npcByRomId[npeId];
            return null;
        }

        public List<MapLink> BuildRoute(Vector3 start, int zoneId, int npeId, int uniqueId)
        {
            PlottedMapPoint pStart = FindNearest(start, zoneId);

            //locate npe
            NonPlayerEntity entity = GetEntity(npeId, uniqueId);
            if ((entity == null) || (pStart == null)) return new List<MapLink>();

            PlottedMapPoint pEnd = (PlottedMapPoint) _npcLocations[entity];
            if (pEnd == null) return new List<MapLink>();

            return BuildRoute(pStart.MapPoint, pEnd.MapPoint);
        }

        public List<MapLink> BuildRoute(Vector3 start, int zoneId, int npeId)
        {
            PlottedMapPoint pStart = FindNearest(start, zoneId);

            //locate npe
            NonPlayerEntity entity = GetEntity(npeId);
            if ((entity == null) || (pStart == null)) return new List<MapLink>();

            PlottedMapPoint pEnd = (PlottedMapPoint)_npcLocations[entity];
            if (pEnd == null) return new List<MapLink>();

            return BuildRoute(pStart.MapPoint, pEnd.MapPoint);
        }

    }

    public class PlottedMapPoint
    {
        public MapPoint MapPoint { get; set; }
        public Vector3 Location { get; set; }
        public List<NonPlayerEntity> NonPlayerEntities = new List<NonPlayerEntity>();
        public List<MapLink> Links = new List<MapLink>();
        public EntityTypes EntityTypes;

        public PlottedMapPoint(MapPoint point)
        {
            MapPoint = point;
            Location = new Vector3(point.X, point.Y,point.Z);
            Links.AddRange(point.Links);
        }

        public void AddNPC(NonPlayerEntity entity)
        {
            if (!NonPlayerEntities.Contains(entity))
            {
                foreach (TeleportLink link in entity.Links)
                {
                    MapLink l = new MapLink()
                                    {
                                        Start = MapPoint,
                                        End = link.End,
                                        LinkType = LinkType.Teleport,
                                        Script = link.Script
                                    };
                    Links.Add(l);
                }
                EntityTypes = EntityTypes | entity.EntityTypes;
                NonPlayerEntities.Add(entity);
            }
        }
    }


}