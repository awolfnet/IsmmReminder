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
    public partial class Browser : Form, Interface.IFaultsBrowserView
    {
        public ChromiumWebBrowser mainBrowser = null;
        private Faults _faults = null;
        private Dictionary<string, string> _cookies = null;

        public Browser()
        {
            InitializeComponent();
            Cef.Initialize(new CefSettings());
            Cef.EnableHighDPISupport();

            mainBrowser = new ChromiumWebBrowser("https://ismm.sg/ce/faults");
            mainBrowser.FrameLoadEnd += MainBrowser_FrameLoadEnd;
            this.Controls.Add(mainBrowser);
            mainBrowser.Dock = DockStyle.Fill;
        }

        private void MainBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            CookieVisitor visitor = new CookieVisitor();
            visitor.SendCookie += _faults.SendCookie;
            ICookieManager cookieManager = mainBrowser.GetCookieManager();
            cookieManager.VisitAllCookies(visitor);
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            SetController(Program.Faults);
            _faults.SetBrowserView(this);
            _cookies = new Dictionary<string, string>();
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
            Program.Message.Show();
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
            _faults.StartMonitor();
        }
        public class CookieVisitor : CefSharp.ICookieVisitor
        {
            public event Action<KeyValuePair<string, string>> SendCookie;
            public void Dispose()
            {

            }

            public bool Visit(Cookie cookie, int count, int total, ref bool deleteCookie)
            {
                deleteCookie = false;
                SendCookie?.Invoke(new KeyValuePair<string, string>(cookie.Name, cookie.Value));
                return true;
            }



        }

        private void menuDebug_Click(object sender, EventArgs e)
        {
            mainBrowser.ShowDevTools();
        }

        public Dictionary<string, string> GetCookie()
        {
            return this._cookies;
        }

        private void menuFetch_Click(object sender, EventArgs e)
        {
            _faults.Fetch();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _faults.StopMonitor();
        }

        public void RefreshPage()
        {
            mainBrowser.Reload();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuControlPanel_Click(object sender, EventArgs e)
        {

        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_faults.Status, "ISMM Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
