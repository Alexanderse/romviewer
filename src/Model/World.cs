using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.ComponentModel;
using System.Diagnostics;

namespace RomViewer.Model
{
    public static class World
    {
        public static WorldData Data = new WorldData();
        public static List<Waypoint> Waypoints = new List<Waypoint>();
        public static bool Initialised = false;
        private static int _nodeId = 0;
        private static int _objectId = 0;
        public static Vector3 PlayerPos;
        public static Zone PlayerZone;
        public static bool IsTravelling;
        public static Zone CurrentZone;

        public static void SaveToDirectory(string path)
        {
            string filename = Path.Combine(path, "WorldData.dat");

            List<Type> knownTypes = new List<Type>();
            knownTypes.Add(typeof(GameNode));
            knownTypes.Add(typeof(Zone));
            knownTypes.Add(typeof(GameObject));
            knownTypes.Add(typeof(GameObjectType));
            knownTypes.Add(typeof(TransportLink));

            StringBuilder serialXML = new StringBuilder();
            DataContractSerializer ser = new DataContractSerializer(typeof(WorldData), knownTypes, int.MaxValue, true, true, null);

            using (XmlWriter xWriter = XmlWriter.Create(serialXML, new XmlWriterSettings(){Encoding = Encoding.UTF8}))
            {
                ser.WriteObject(xWriter, Data);
                xWriter.Flush();
            }

            File.WriteAllText(filename, serialXML.ToString(), Encoding.UTF8);
        }

        public static void LoadFromDirectory(string path)
        {
            string filename = Path.Combine(path, "WorldData.dat");

            if (!File.Exists(filename)) return;
            
            List<Type> knownTypes = new List<Type>();
            knownTypes.Add(typeof(GameNode));
            knownTypes.Add(typeof(Zone));
            knownTypes.Add(typeof(GameObject));
            knownTypes.Add(typeof(GameObjectType));
            knownTypes.Add(typeof(TransportLink));

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            try
            {
                StreamReader r = new StreamReader(fs, true);

                DataContractSerializer ser = new DataContractSerializer(typeof(WorldData), knownTypes, int.MaxValue,
                                                                        true, true, null);

                using (XmlReader reader = XmlReader.Create(r))
                {
                    Data = (WorldData)ser.ReadObject(reader, false);
                }
            }
            finally
            {
                fs.Close();
            }

            //Data.Zones.Add(new Zone() { Id = 2013, Name = "Coast of Opportunity" });

            Data.Nodes = new List<GameNode>();
            foreach (Zone zone in Data.Zones)
            {
                foreach (GameNode node in zone.Waypoints)
                {
                    if (!Data.Nodes.Contains(node)) Data.Nodes.Add(node);
                }

                //rebuild as I'm getting duplicates
                zone.Waypoints.Clear();
            }

            foreach (GameNode node in Data.Nodes)
            {
                if (node.Zone != null) node.Zone.Waypoints.Add(node);
            }

            foreach (GameNode node in Data.Nodes)
            {
                if (node.Id > _nodeId) _nodeId = node.Id;
            }

            foreach (GameObject obj in Data.RomObjects)
            {
                if (obj.Id > _objectId) _objectId = obj.Id;
            }
        }


        public static void Initialise(string path)
        {
            LoadFromDirectory(path);
        }

        public static void BuildModel(BackgroundWorker worker)
        {
            Waypoints.Clear();

            //Create waypoints for each node
            foreach (GameNode node in Data.Nodes)
            {
                Waypoint wp = new Waypoint(node);
                Waypoints.Add(wp);
            }

            
            int prog = 2;
            worker.ReportProgress(prog);

            //Link each waypoint via physical links
            foreach (Waypoint waypoint in Waypoints)
            {
                worker.ReportProgress(prog);
                List<GameNodeLink> toRemove = new List<GameNodeLink>();

                foreach (GameNodeLink neighbour in waypoint.Node.GameNodeLinks)
                {
                    Waypoint destination = Waypoints.Find(wp => wp.Node == neighbour.Target);
                    if (destination == null)
                        toRemove.Add(neighbour);
                    else
                        waypoint.AddLink(destination, LinkStyle.Walk, neighbour.Script);
                }

                foreach (var neighbour in toRemove)
                {
                    waypoint.Node.GameNodeLinks.Remove(neighbour);
                }
            }

            prog = 3;
            worker.ReportProgress(prog);


            //setup teleport links and object types
            foreach (Waypoint waypoint in Waypoints)
            {
                foreach (GameObject go in waypoint.Node.GameObjects)
                {
                    foreach (TransportLink link in go.TransportLinks)
                    {
                        waypoint.AddLink(Waypoints.Find(wp => wp.Node == link.Destination), LinkStyle.Transport, link.Script);
                    }

                    foreach (GameObjectType objectType in go.ObjectTypes)
                    {
                        if (!waypoint.SupportsObjectType.Contains(objectType)) waypoint.SupportsObjectType.Add(objectType);
                    }
                }
            }

            prog = 10;
            worker.ReportProgress(prog);

            BuildNearestLinks(worker);
        }

        private static void BuildNearestLinks(BackgroundWorker worker)
        {
            List<WaypointLink> path = new List<WaypointLink>();
            List<WaypointLink> currentShortestPath = new List<WaypointLink>();
            List<Waypoint> visitedList = new List<Waypoint>();

            double typeInc = (90 / (int)GameObjectType.Transporter);
            double wpInc = (typeInc / (Waypoints.Count-2));
            double progress = 10;

            for (GameObjectType i = GameObjectType.VendorPet; i <= GameObjectType.Transporter; i++)
            {
                if ((i == GameObjectType.Bank) || (i == GameObjectType.Transporter)) continue;

                foreach (Waypoint waypoint in Waypoints)
                {
                    Debug.WriteLine(i.ToString() + ": " + waypoint.Name);
                    progress += wpInc;
                    worker.ReportProgress((int)progress, i.ToString());

                    visitedList.Clear();
                    currentShortestPath.Clear();
                    path.Clear();
                    visitedList.Add(waypoint);
                    if (waypoint.NearestTypeLinks.ContainsKey(i)) continue;

                    if (waypoint.SupportsObjectType.Contains(i)) continue;

                    foreach (KeyValuePair<int, WaypointLink> pair in waypoint.Links)
                    {
                        FindNearest(i, path, visitedList, currentShortestPath, pair.Value);
                    }

                    if (currentShortestPath.Count > 0)
                    {
                        Debug.WriteLine(i.ToString() + ": " + waypoint.Name + " ---> " + _pathToString(currentShortestPath));
                        Debug.WriteLine("");

                        //run through each link and set nearest type!!
                        foreach (WaypointLink waypointLink in currentShortestPath)
                        {
                            if (!waypointLink.Source.NearestTypeLinks.ContainsKey(i)) waypointLink.Source.NearestTypeLinks.Add(i, waypointLink);
                        }
                    }
                }
            }
        }

        private static double _getPathLength(List<WaypointLink> path)
        {
            double result = 0;

            foreach (WaypointLink link in path)
            {
                result += link.Distance;
            }

            return result;
        }

        private static void UpdatePath(List<WaypointLink> path, List<WaypointLink> newPath)
        {
            path.Clear();
            for (int i = 0; i < newPath.Count; i++)
            {
                path.Add(newPath[i]);
            }
        }

        private static string _pathToString(List<WaypointLink> path)
        {
            if (path.Count < 1) return "";

            string result = path[0].Source.Name;

            foreach (WaypointLink link in path)
            {
                result += "." + link.Destination.Name;
            }

            return result;
        }


        private static bool FindNearest(GameObjectType gameObjectType, List<WaypointLink> path, List<Waypoint> visitedList, List<WaypointLink> currentShortestPath, WaypointLink waypointLink)
        {
            if ((currentShortestPath.Count > 0) && (_getPathLength(path) >= _getPathLength(currentShortestPath)))
            {
                string s = _pathToString(path) + "." + waypointLink.Destination.Name;
                s = "Path longer than current path: " + s;
                Debug.WriteLine(s);
                return false;
            }

            if (waypointLink.Destination.SupportsObjectType.Contains(gameObjectType))
            {
                UpdatePath(currentShortestPath, path);
                currentShortestPath.Add(waypointLink);
                string s = _pathToString(currentShortestPath);
                s = "Found new shortest path: " + s;
                Debug.WriteLine(s);

                return false;
            }

            if (visitedList.Contains(waypointLink.Destination))
            {
                return false;
            }

            if ((waypointLink.Destination.NearestTypeLinks.ContainsKey(gameObjectType) && (waypointLink.Destination.NearestTypeLinks[gameObjectType].Destination != waypointLink.Source)))
            {
                path.Add(waypointLink);

                string s = _pathToString(currentShortestPath);
                s = "Found preexisting route at: " + s;
                Debug.WriteLine(s);


                //follow links to end
                int iPathDepth = 1;
                WaypointLink link = waypointLink.Destination.NearestTypeLinks[gameObjectType];
                do
                {
                    path.Add(link);
                    iPathDepth++;
                    if (link.Destination.NearestTypeLinks.ContainsKey(gameObjectType))
                        link = link.Destination.NearestTypeLinks[gameObjectType];
                    else link = null;
                } while (link != null);
                if ((currentShortestPath.Count < 1) || (_getPathLength(path) < _getPathLength(currentShortestPath)))
                {
                    s = _pathToString(path);
                    s = "Used existing route, path is now: " + s;
                    Debug.WriteLine(s);
                    UpdatePath(currentShortestPath, path);
                    for (int i = 0; i < iPathDepth; i++) path.RemoveAt(path.Count - 1); //back out of path
                    return false;
                }
                for (int i = 0; i == iPathDepth; i++) path.RemoveAt(path.Count - 1); //remove 1 extra as we will add it backin below
                Debug.WriteLine("Existing route is longer than current shortest");

            }

            visitedList.Add(waypointLink.Destination);
            path.Add(waypointLink);

            foreach (KeyValuePair<int, WaypointLink> pair in waypointLink.Destination.Links)
            {
                FindNearest(gameObjectType, path, visitedList, currentShortestPath, pair.Value);
            }

            path.Remove(waypointLink);
            visitedList.Remove(waypointLink.Destination);

            return false;
        }

        public static List<WaypointLink> GetShortestPath(Waypoint target, Waypoint startPoint)
        {
            List<WaypointLink> path = new List<WaypointLink>();
            List<WaypointLink> currentShortestPath = new List<WaypointLink>();
            List<Waypoint> visitedList = new List<Waypoint>();

            if (target == startPoint) return currentShortestPath;

            visitedList.Clear();
            currentShortestPath.Clear();
            path.Clear();
            visitedList.Add(startPoint);

            foreach (KeyValuePair<int, WaypointLink> pair in startPoint.Links)
            {
                FindShortestPath(target, path, visitedList, currentShortestPath, pair.Value);
            }

            return currentShortestPath;
            
        }

        private static void FindShortestPath(Waypoint target, List<WaypointLink> path, List<Waypoint> visitedList, List<WaypointLink> currentShortestPath, WaypointLink waypointLink)
        {
            if ((currentShortestPath.Count > 0) && (_getPathLength(path) >= _getPathLength(currentShortestPath))) return;
            if (waypointLink.Destination == target)
            {
                UpdatePath(currentShortestPath, path);
                currentShortestPath.Add(waypointLink);
                return;
            }

            if (visitedList.Contains(waypointLink.Destination)) return;

            visitedList.Add(waypointLink.Destination);
            path.Add(waypointLink);

            foreach (KeyValuePair<int, WaypointLink> pair in waypointLink.Destination.Links)
            {
                FindShortestPath(target, path, visitedList, currentShortestPath, pair.Value);
            }

            path.Remove(waypointLink);
            visitedList.Remove(waypointLink.Destination);

            return;
        }

        public static int GetNextNodeId()
        {
            _nodeId++;
            return _nodeId;
        }

        public static int GetNextObjectId()
        {
            _objectId++;
            return _objectId;
        }

        public static GameNode FindNearestNode(Vector3 playerPos)
        {
            GameNode result = null;

            foreach (GameNode node in CurrentZone.Waypoints)
            {
                if (result == null)
                {
                    result = node;
                    continue;
                }

                if (result.Coordinates.Distance(playerPos) > node.Coordinates.Distance(playerPos))
                {
                    result = node;
                }
            }

            return result;
        }
    
        public static List<WaypointLink> FindRouteTo(GameObjectType gameObjectType, GameNode startAt)
        {
            Waypoint start = Waypoints.Find(waypoint => (waypoint.Node == startAt));
            if (start == null) return null;

            List<WaypointLink> result = new List<WaypointLink>();

            Waypoint current = start;
            //result.Add(current.NearestTypeLinks[gameObjectType]);
            while (!current.SupportsObjectType.Contains(gameObjectType))
            {
                result.Add(current.NearestTypeLinks[gameObjectType]);
                current = current.NearestTypeLinks[gameObjectType].Destination;
            }

            return result;
        }

        internal static void DeleteNode(GameNode node)
        {
            Data.Nodes.Remove(node);

            foreach (var item in Data.Nodes)
            {
                //remove basic links
                List<object> linksToRemove = new List<object>();

                foreach (var link in item.GameNodeLinks)
                {
                    if (link.Target == node) linksToRemove.Add(link);
                }

                foreach (var link in linksToRemove)
                {
                    item.GameNodeLinks.Remove((GameNodeLink)link);
                }


                //remove transport links
                linksToRemove.Clear();

                foreach (var go in item.GameObjects)
                {
                    foreach (var link in go.TransportLinks)
                    {
                        if (link.Destination == node) linksToRemove.Add(link);
                    }

                    foreach (var link in linksToRemove)
                    {
                        go.TransportLinks.Remove((TransportLink)link);
                    }
                }
            }

            node.Zone.Waypoints.Remove(node);
        }
    }
}