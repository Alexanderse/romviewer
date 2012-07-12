using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using NHibernate;
using NHibernate.Context;
using RomService;
using RomService.Library;
using RomViewer.Core.Mapping;
using RomViewer.Core.NPCs;
using RomViewer.Init;
using RomViewer.Tasks;
using SharpLite.Domain.DataInterfaces;
using log4net;
using log4net.Config;

[assembly: XmlConfigurator(ConfigFileExtension = "log4net", Watch = true)]

namespace RomServiceTestBed
{
    public partial class Form1 : Form
    {
        TcpClient _client;
        private TCPServer _server;
        private ILog _logger = LogManager.GetLogger(typeof(Form1));

        public Form1()
        {
            InitializeComponent();
        }

        private void SetButtonState(bool started)
        {
            btnStart.Enabled = !started;
            btnStop.Enabled = started;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _logger.Info("Starting");
            SetButtonState(true);
            try
            {
                RomViewContainer.Initialize();
                ISessionFactory _factory = RomViewContainer.Container.GetInstance<ISessionFactory>();
                ISession session = _factory.OpenSession();
                CallSessionContext.Bind(session);
                //ITransaction tx = session.BeginTransaction();
                INonPlayerEntityRepository npeRepo =
                    RomViewContainer.Container.GetInstance<INonPlayerEntityRepository>();
                IRepository<MapPoint> pointRepo = RomViewContainer.Container.GetInstance<IRepository<MapPoint>>();
                IRepository<MapZone> zoneRepo = RomViewContainer.Container.GetInstance<IRepository<MapZone>>();

                MapBuilder mb = new MapBuilder(npeRepo, pointRepo, zoneRepo);
                Map map = mb.BuildMap(100);
                RomViewContainer.Container.Inject(typeof (Map), map);

                _server = new TCPServer(31001);
                _server.StartServer();
                _logger.Info("Started");
                /*
                 * _client = new TcpClient("127.0.0.1", 31001);
                            int itemId = 228216;
                            string source = string.Format("ITEM{0}GET{0}{1}{2}", (char)1, itemId, (char)0);
                            NetworkStream ns = _client.GetStream();
                            byte[] data = Encoding.ASCII.GetBytes(source);
                            ns.Write(data, 0, data.Length);

                            byte[] byteBuffer = new byte[1024];
                            int size = ns.Read(byteBuffer, 0, byteBuffer.Length);
                            string result = Encoding.ASCII.GetString(byteBuffer, 0, size);

                            _client.Close();
                            _server.StopServer();
                 * */
            } catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                SetButtonState(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _logger.Info("Stopping");
            _server.StopServer();
            _server = null;
            SetButtonState(false);
        }
    }
}
