using System.Collections.Generic;
using System.Drawing;
using MS.Internal.Xml.XPath;
using RomViewer.Model;

namespace RomViewer.Navigator
{
    public class NodeViewer
    {
        private Bitmap _map;
        private readonly List<Zone> _zones = new List<Zone>();

        private readonly MapSettings _mapSettings;
        private Rectangle _mapDimensions = new Rectangle(0,0,0,0);
        private Rectangle _viewDimensions = new Rectangle(0, 0, 0, 0);
        private Point _originOffset = new Point(0, 0);

        private Dictionary<GameNode, RectangleF> _nodeDimensions = new Dictionary<GameNode, RectangleF>();
        private Dictionary<GameNode, PointF> _nodeCenters = new Dictionary<GameNode, PointF>();
        private Vector3 _playerPos;
        private List<MapToken> _mapTokens = new List<MapToken>();
        public Point OriginOffset { get { return _originOffset; } }
        public Rectangle ViewDimensions { get { return _viewDimensions; } }

        private class MapToken
        {
            public int Id;
            public string Name;
            public Vector3 Coordinates;

            public MapToken(int id, string name, Vector3 coordinates)
            {
                Id = id;
                Name = name;
                Coordinates = coordinates;
            }
        }


        public void AddMapToken(int id, string name, Vector3 coords)
        {
            if (_mapTokens.Find(token => token.Id == id) == null)
            {
                _mapTokens.Add(new MapToken(id, name, coords));
            }
        }

        public Rectangle MapDimensions
        {
            get { return _mapDimensions; }
        }

        public NodeViewer(Zone zone, MapSettings mapSettings)
        {
            _zones.Clear();
            _zones.Add(zone);
            _mapSettings = mapSettings;
        }

        public NodeViewer(List<Zone> zones, MapSettings mapSettings)
        {
            _zones.Clear();
            _zones.AddRange(zones);
            _mapSettings = mapSettings;
        }

        private Rectangle GetMapDimensions()
        {
            if (_mapDimensions.Width == 0)
            {
                double l = double.MaxValue, r = double.MinValue, t = double.MinValue, b = double.MaxValue;

                foreach (Zone zone in _zones)
                {
                    foreach (GameNode node in zone.Waypoints)
                    {
                        if (node.Coordinates.X < l) l = node.Coordinates.X;
                        if (node.Coordinates.X > r) r = node.Coordinates.X;
                        if (-node.Coordinates.Z > t) t = -node.Coordinates.Z;
                        if (-node.Coordinates.Z < b) b = -node.Coordinates.Z;
                    }
                }

                if (l == double.MaxValue)
                {
                    l = 0;
                    r = 10;
                    t = 0;
                    b = 10;
                }

                //note: we do b-t inthe formula below as rom has y coordinates in reverse to us
                _mapDimensions = new Rectangle(0, 0, (int) (((r - l)/_mapSettings.Scale) + _mapSettings.Margin*2), (int) (((t - b)/_mapSettings.Scale) + _mapSettings.Margin*2));

                //determine origin
                _originOffset = new Point((int)-(l / _mapSettings.Scale) + _mapSettings.Margin, (int)-(b / _mapSettings.Scale) + _mapSettings.Margin);

                _nodeCenters.Clear();
                _nodeDimensions.Clear();
            }
            return _mapDimensions;
        }

        private void InitSurface()
        {
            Rectangle dimensions = GetMapDimensions();
            
            // now only draw the visible
            //Rectangle view = GetViewDimensions();

            _map = new Bitmap(_viewDimensions.Width, _viewDimensions.Height);
            Graphics g = Graphics.FromImage(_map);
            try
            {
                g.FillRectangle(_mapSettings.BackgroundBrush, dimensions);
            }
            finally
            {
                g.Dispose();
            }
        }

        private void DrawNodes()
        {
            Graphics g = Graphics.FromImage(_map);
            try
            {
                foreach (Zone zone in _zones)
                {

                    foreach (GameNode node in zone.Waypoints)
                    {
                        RectangleF nodeRect = GetNodeDimensions(node);
                        PointF nodeCenter = GetNodeCenter(node);
                        g.FillEllipse(_mapSettings.OnGetNodeBrush(node), nodeRect);

                        //draw name
                        g.DrawString(string.Format("{0} [{1}]", node.Name, node.Id), _mapSettings.NodeFont,
                                     new SolidBrush(_mapSettings.NodeTextColor), nodeRect.Right + 2, nodeRect.Top);

                        foreach (GameNodeLink neighbour in node.GameNodeLinks)
                        {
                            PointF neighbourCenter = GetNodeCenter(neighbour.Target);
                            g.DrawLine(_mapSettings.OnGetLinkPen(node, neighbour), nodeCenter, neighbourCenter);
                        }

                        foreach (GameObject gameObject in node.GameObjects)
                        {
                            foreach (TransportLink link in gameObject.TransportLinks)
                            {
                                PointF linkCenter = GetNodeCenter(link.Destination);

                                g.DrawLine(_mapSettings.OnGetLinkPen(node, link), nodeCenter, linkCenter);
                            }
                        }
                    }

                    if (_playerPos.Magnitude != 0)
                    {
                        RectangleF nodeRect = GetPointDimensions(_playerPos);
                        PointF nodeCenter = GetPointCenter(_playerPos);
                        g.FillRectangle(Brushes.ForestGreen, nodeRect);
                    }

                    foreach (MapToken token in _mapTokens)
                    {
                        RectangleF nodeRect = GetPointDimensions(token.Coordinates);
                        PointF nodeCenter = GetPointCenter(token.Coordinates);
                        if (token.Id < 100000) g.FillRectangle(Brushes.Blue, nodeRect);
                        if (token.Id >= 100000) g.FillRectangle(Brushes.Red, nodeRect);

                        g.DrawString(string.Format("{0} [{1}]", token.Name, token.Id), _mapSettings.NodeFont, new SolidBrush(_mapSettings.NodeTextColor), nodeRect.Right + 2, nodeRect.Top);

                    }
                }
            }
            finally
            {
                g.Dispose();
            }
        }

        private PointF GetNodeCenter(GameNode node)
        {
            if (_nodeCenters.ContainsKey(node)) return (PointF) _nodeCenters[node];

            PointF nodeCenter = new PointF((float)(_originOffset.X + (node.Coordinates.X / _mapSettings.Scale) - _viewDimensions.Left), (float)(_originOffset.Y + (-node.Coordinates.Z / _mapSettings.Scale)-_viewDimensions.Y)); //reverse as rom -ve is other way from us
            _nodeCenters.Add(node, nodeCenter);
            return nodeCenter;
        }

        private RectangleF GetNodeDimensions(GameNode node)
        {
            if (_nodeDimensions.ContainsKey(node)) return (RectangleF)_nodeDimensions[node];

            GetMapDimensions();

            PointF nodeCenter = GetNodeCenter(node);
            RectangleF result = new RectangleF((float)(nodeCenter.X - _mapSettings.NodeWidth/2), (float)(nodeCenter.Y - _mapSettings.NodeWidth/2), _mapSettings.NodeWidth, _mapSettings.NodeWidth);

            _nodeDimensions.Add(node, result);

            return result;
        }

        private PointF GetPointCenter(Vector3 Coordinates)
        {
            PointF nodeCenter = new PointF((float)(_originOffset.X + (Coordinates.X / _mapSettings.Scale) - _viewDimensions.Left), (float)(_originOffset.Y + (-Coordinates.Z / _mapSettings.Scale) - _viewDimensions.Top)); //reverse as rom -ve is other way from us
            return nodeCenter;
        }

        private RectangleF GetPointDimensions(Vector3 Coordinates)
        {
            GetMapDimensions();

            PointF nodeCenter = GetPointCenter(Coordinates);
            RectangleF result = new RectangleF((float)(nodeCenter.X - _mapSettings.NodeWidth / 2), (float)(nodeCenter.Y - _mapSettings.NodeWidth / 2), _mapSettings.NodeWidth, _mapSettings.NodeWidth);

            return result;
        }


        public Bitmap GetMap()
        {
            if (_map == null)
            {
                InitSurface();
                DrawNodes();
            }
            return _map;
        }

        public void ChangeScale(double scale)
        {
            _mapSettings.Scale = scale;
            _mapDimensions = new Rectangle(0,0,0,0);
            _map = null;
        }

        public GameNode FindNodeAtPoint(PointF point)
        {
            foreach (KeyValuePair<GameNode, RectangleF> pair in _nodeDimensions)
                if (pair.Value.Contains(point)) return pair.Key;

            return null;
        }

        public void SetPlayerPos(Vector3 playerPos)
        {
            _playerPos = playerPos;
        }

        public void SetView(Rectangle clientRectangle)
        {
            _viewDimensions = clientRectangle;
        }

        internal Vector3 GetMapCoordsAtPoint(PointF mouseClick)
        {
            float x, y;
            x = (float)((mouseClick.X - _originOffset.X + _viewDimensions.Left) * _mapSettings.Scale);
            y = (float)((mouseClick.Y - _originOffset.Y + _viewDimensions.Top) * -_mapSettings.Scale);
            Vector3 gameCoord = new Vector3(x, 0, y);
            return gameCoord;
        }
    }

    public delegate Brush GetNodeBrushDelegate(GameNode node);
    public delegate Pen GetLinkPenDelegate(GameNode source, object link);

    public class MapSettings
    {
        public int Margin = 30;
        public Brush BackgroundBrush;
        public int NodeWidth;
        public Brush NodeBrush;
        public Pen MovementLinkPen;
        public Pen TeleportLinkPen;
        public double Scale;
        public Font NodeFont;
        public Color NodeTextColor;
        public GetNodeBrushDelegate OnGetNodeBrush = null;
        public GetLinkPenDelegate OnGetLinkPen = null;

        public MapSettings(int margin, int nodeWidth, double scale, Color backColor, Color NodeColor, Pen movementPen, Pen teleportPen)
        {
            Margin = margin;
            NodeWidth = nodeWidth;
            BackgroundBrush = new SolidBrush(backColor);
            MovementLinkPen = movementPen;
            Scale = scale;
            NodeFont = new Font(FontFamily.GenericSansSerif, 8);
            NodeTextColor = NodeColor;
            TeleportLinkPen = teleportPen;
            NodeBrush = new SolidBrush(NodeColor);
        }

    }

   
}