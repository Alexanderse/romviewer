using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RomViewer
{
    public partial class dlgMultiLineMessage : Form
    {
        public dlgMultiLineMessage(List<string> channels)
        {
            InitializeComponent();

            cbChannel.Items.AddRange(channels.ToArray());
        }

        private void cbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            tbTarget.Enabled = (cbChannel.Text.ToLower() == "whisper");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbTarget.Enabled && tbTarget.Text.Length < 1)
            {
                MessageBox.Show("You must specify a target for whispers.");
                return;
            }

            foreach (string line in tbMessage.Lines)
            {
                if (line.Trim().Length < 1) continue;
                mmServer.ServerInstance.QueueChat(cbChannel.Text, line, (tbTarget.Enabled ? tbTarget.Text : ""));
                Thread.Sleep(500); 
            }
        }
    }
}
