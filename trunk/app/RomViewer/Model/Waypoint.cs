using System;
using System.Collections;
using System.Collections.Generic;

namespace RomViewer.Model
{
    public class Waypoint
    {
        public GameNode Node;
        public Zone Zone = null;
        public Vector3 Coordinates;
        public int Id;
        public string Name;
        public Dictionary<int, WaypointLink> Links = new Dictionary<int, WaypointLink>();
        public List<GameObjectType> SupportsObjectType = new List<GameObjectType>();
        public Dictionary<GameObjectType, WaypointLink> NearestTypeLinks = new Dictionary<GameObjectType, WaypointLink>();


        public Waypoint(Zone zone, Vector3 coordinates, int id, string name)
        {
            Zone = zone;
            Coordinates = coordinates;
            Id = id;
            Name = name;
        }

        public Waypoint(GameNode node)
        {
            Id = node.Id;
            Name = node.Name;
            Coordinates = node.Coordinates;
            Node = node;
            Zone = node.Zone;
        }

        public WaypointLink AddLink(Waypoint destination, LinkStyle stlye)
        {
            WaypointLink result = new WaypointLink(this, destination, stlye);
            Links.Add(destination.Id, result);
            return result;
        }

        public WaypointLink AddLink(Waypoint destination, LinkStyle stlye, string script)
        {

            WaypointLink result = new WaypointLink(this, destination, stlye, script);
            Links.Add(destination.Id, result);
            return result;
        }

        public void SetNearestTypeWaypoint(GameObjectType gameType, WaypointLink link)
        {
            if (NearestTypeLinks.ContainsKey(gameType)) NearestTypeLinks.Remove(gameType);
            NearestTypeLinks.Add(gameType, link);
        }

        public override string ToString()
        {
            return Node.ToString();
        }

        public string ToRomBotXML(int num, string script)
        {
            string s = "";
            if ((script!=null) && (script.Length > 0))
            {
                s = Environment.NewLine + script + Environment.NewLine;
            }
            string result = string.Format("	<!-- #  {0:00} --><waypoint x=\"{1}\" z=\"{2}\"  type=\"RUN\">{3}</waypoint>", num, Coordinates.X, Coordinates.Z, s);
            return result;
        }
    }

    public class WaypointLink
    {
        public Waypoint Source { get; set; }
        public Waypoint Destination { get; set; }
        public LinkStyle Style { get; set; }
        public string Script { get; set; }
        public double Distance { get; set; }

        public WaypointLink(Waypoint source, Waypoint destination, LinkStyle style)
        {
            Source = source;
            Destination = destination;
            Style = style;

            if (style == LinkStyle.Walk)
                Distance = source.Coordinates.Distance(destination.Coordinates);
            else
                Distance = 1200;
        }

        public WaypointLink(Waypoint source, Waypoint destination, LinkStyle style, string script): this(source, destination, style)
        {
            Script = script;
        }

        public override string ToString()
        {
            string source = (Source != null) ? Source.Name : "unknown";
            string dest = (Destination != null) ? Destination.Name : "unknown";

            return source + " -> " + dest;
        }
    }

    public enum LinkStyle
    {
        Walk,
        Transport
    }

    public class InteractiveObject
    {
        public GameObject GameObject;
        public List<GameObjectType> ImplementsTypes = new List<GameObjectType>();
        public Dictionary<GameObjectType, string> TypeScripts = new Dictionary<GameObjectType, string>();
        public Dictionary<Waypoint, WaypointLink> TransportLinks = new Dictionary<Waypoint, WaypointLink>();

        public InteractiveObject(GameObject gameObject)
        {
            GameObject = gameObject;
            ImplementsTypes.AddRange(gameObject.ObjectTypes);
        }
    }
}