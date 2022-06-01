using IsmmReminder.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsmmReminder
{
    static class Program
    {
        private static Browser _browserForm = null;
        public static Browser Browser
        {
            get
            {
                if (_browserForm == null || _browserForm.IsDisposed)
                {
                    _browserForm = new Browser();
                }
                return _browserForm;
            }

        }

        private static ControlPanel _controlPanel = null;
        public static ControlPanel ControlPanel
        {
            get
            {
                if (_controlPanel == null || _controlPanel.IsDisposed)
                {
                    _controlPanel = new ControlPanel();
                }
                return _controlPanel;
            }
        }

        private static Controller.Faults _faults = null;
        public static Controller.Faults Faults
        {
            get
            {
                if(_faults==null)
                {
                    _faults = new Controller.Faults();
                }
                return _faults;
            }
        }

        public static Forms.Message _message = null;
        public static Forms.Message Message
        {
            get
            {
                if (_message == null || _message.IsDisposed)
                {
                    _message = new Forms.Message();
                }
                return _message;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Browser);
        }
    }
}
