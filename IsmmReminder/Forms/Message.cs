using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsmmReminder.Forms
{
    public partial class Message : Form
    {
        public ChromiumWebBrowser mainBrowser = null;

        public Message()
        {
            InitializeComponent();

            mainBrowser = new ChromiumWebBrowser("https://web.whatsapp.com");
            this.Controls.Add(mainBrowser);
            mainBrowser.Dock = DockStyle.Fill;
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }
    }
}
