using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using RomService.Library;
using RomViewer.Tasks;

namespace RomService
{
    public partial class RomService : ServiceBase
    {
        private TCPServer _server = null;

        public RomService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _server = new TCPServer(31001);
            _server.StartServer();
        }

        protected override void OnStop()
        {
            _server.StopServer();
        }

    }
}
