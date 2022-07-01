using CefSharp;
using CefSharp.WinForms;
using IsmmReminder.Controller;
using IsmmReminder.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsmmReminder.Forms
{
    public partial class Message : Form, IMessage
    {
        public ChromiumWebBrowser mainBrowser = null;

        private Faults _faults = null;
        private string _jsContent = string.Empty;

        public Message()
        {
            InitializeComponent();

            mainBrowser = new ChromiumWebBrowser("https://web.whatsapp.com");
            this.Controls.Add(mainBrowser);
            mainBrowser.Dock = DockStyle.Fill;
            mainBrowser.LoadingStateChanged += MainBrowser_LoadingStateChanged;
            mainBrowser.FrameLoadEnd += MainBrowser_FrameLoadEnd;
        }

       

        private void MainBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                e.Frame.ExecuteJavaScriptAsync(_jsContent);
            }
        }

        private void MainBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {

        }

        private void Message_Load(object sender, EventArgs e)
        {
            SetController(Program.Faults);
            _faults.SetMessageView(this);
            _jsContent = ReadJSFromFile(System.AppDomain.CurrentDomain.BaseDirectory+ @"\Misc\WhatsAppAPI.js");
        }

        private string ReadJSFromFile(string jsfile)
        {
            string jsContent = string.Empty;
            // This text is added only once to the file.
            if (!File.Exists(jsfile))
            {
                throw new Exception("File doesn't exists");
            }

            jsContent = File.ReadAllText(jsfile);

            return jsContent;

        }

        public void SendMesage(string Contact, string Message)
        {
            mainBrowser.ExecuteScriptAsync($"setMessage('{Message}')");
            System.Threading.Thread.Sleep(100);
            mainBrowser.ExecuteScriptAsync($"sendMessage()");
        }

        public void SetController(Faults faults)
        {
            _faults = faults;
        }
    }
}
