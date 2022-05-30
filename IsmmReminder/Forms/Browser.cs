using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using IsmmReminder.Controller;

namespace IsmmReminder.Forms
{
    public partial class Browser : Form, Interface.IFaultsView
    {
        public ChromiumWebBrowser mainBrowser;
        private Faults _faults;

        public Browser()
        {
            InitializeComponent();
            Cef.Initialize(new CefSettings());
            Cef.EnableHighDPISupport();

            mainBrowser = new ChromiumWebBrowser("https://ismm.sg/ce/faults");
            this.Controls.Add(mainBrowser);
            mainBrowser.Dock = DockStyle.Fill;
        }

        private void Browser_Load(object sender, EventArgs e)
        {

        }


        private void menuHome_Click(object sender, EventArgs e)
        {
            mainBrowser.LoadUrl("https://ismm.sg/ce/faults");
        }

        private void menuReload_Click(object sender, EventArgs e)
        {
            mainBrowser.Reload();
        }

        private void menuShowControlPanel_Click(object sender, EventArgs e)
        {
            Program.ControlPanel.Show();
        }

        private void menuMessage_Click(object sender, EventArgs e)
        {
            Util.HTTP http = new Util.HTTP();
            http.Request("");
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void SetController(Faults faults)
        {
            _faults = faults;
        }

        private void startToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void menuStart_Click(object sender, EventArgs e)
        {

        }
    }
}
