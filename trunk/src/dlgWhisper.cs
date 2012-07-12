using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RomViewer
{
    public partial class dlgWhisper : Form
    {
        private string _target = "";
        private MainForm _mainForm;

        public dlgWhisper(string target, MainForm form)
        {
            InitializeComponent();
            _target = target;
            _mainForm = form;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mmServer.ServerInstance.QueueChat("WHISPER", tbText.Text, _target);
                _mainForm.AddWhisperText("-->["+_target+"]", tbText.Text);
                tbConversation.AppendText("-->[" + _target + "] " + tbText.Text + Environment.NewLine);
                tbText.Clear();
            }
        }

        private void dlgWhisper_Shown(object sender, EventArgs e)
        {
            Text = "Whisper to " + _target;
        }

        public void AddText(string s)
        {
            tbConversation.AppendText(s);
        }
    }
}
