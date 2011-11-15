using System.Collections.Generic;
using System.Runtime.Serialization;
using MS.Internal.Xml.XPath;

namespace RomViewer.Model
{
    [DataContract]
    public class GameNode
    {
        [DataMember] private Vector3 _coordinates;
        [DataMember] private int _id;
        [DataMember] private string _name;
        [DataMember] private List<GameObject> _gameObjects = new List<GameObject>();
        [DataMember] private Zone _zone;
        [DataMember] private List<GameNodeLink>  _gameNodeLinks = new List<GameNodeLink>();

        public List<GameNodeLink> GameNodeLinks
        {
            get { return _gameNodeLinks; }
            set { _gameNodeLinks = value; }
        }

        public Vector3 Coordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }

        public Zone Zone
        {
            get { return _zone; }
            set { _zone = value; }
        }

        public void AddNeighbour(GameNode node, bool bidirectional)
        {
            GameNodeLinks.Add(new GameNodeLink(node, ""));
            if (bidirectional) node.AddNeighbour(this, false);
        }

        public override string ToString()
        {
            string result = string.Format("{0:00} {1}", _id, _name);
            if (_zone != null) result = string.Format("{0} - {1}", _zone.Name, result);

            return result;
        }
    }

    [DataContract]
    public class GameNodeLink
    {
        [DataMember] private GameNode _target;
        [DataMember] private string _script;

        public GameNodeLink(GameNode target, string script)
        {
            _target = target;
            _script = script;
        }

        public GameNode Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public string Script
        {
            get { return _script; }
            set { _script = value; }
        }
    }

    [DataContract]
    public enum GameObjectType
    {
        [EnumMember]
        None,
        [EnumMember]
        VendorPet,
        [EnumMember]
        VendorGeneral,
        [EnumMember]
        AuctionHouse,
        [EnumMember]
        Bank,
        [EnumMember]
        Mailbox,
        [EnumMember]
        Housemaid,
        [EnumMember]
        Transporter
    }

    [DataContract]
    public class GameObject
    {
        [DataMember]
        private List<GameObjectType> _objectTypes = new List<GameObjectType>();
        [DataMember]
        private int _id;
        [DataMember]
        private string _name;
        [DataMember]
        private List<TransportLink> _transportLinks = new List<TransportLink>();

        public List<GameObjectType> ObjectTypes
        {
            get { return _objectTypes; }
            set { _objectTypes = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<TransportLink> TransportLinks
        {
            get { return _transportLinks; }
            set { _transportLinks = value; }
        }
    }

    [DataContract]
    public class TransportLink
    {
        [DataMember]
        private GameNode _destination;
        [DataMember]
        private string _script;

        public GameNode Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        public string Script
        {
            get { return _script; }
            set { _script = value; }
        }
    }

    [DataContract]
    public class Zone
    {
        [DataMember]
        private int _id;
        [DataMember]
        private string _name;
        [DataMember]
        private List<GameNode> _waypoints = new List<GameNode>();

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<GameNode> Waypoints
        {
            get { return _waypoints; }
            set { _waypoints = value; }
        }

        public override string ToString()
        {
            return string.Format("{0:00} {1}", this._id, this._name);
        }

        public void AddNode(GameNode node)
        {
            Waypoints.Add(node);
        }

        public GameNode AddNode(int id, string name, Vector3 coordinates)
        {
            GameNode node = new GameNode() {Coordinates = coordinates, Name = name, Id = id, Zone = this};
            AddNode(node);
            return node;
        }

    }

}