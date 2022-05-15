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
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            mainBrowser.ScriptErrorsSuppressed = true;
            mainBrowser.Navigate("https://ismm.sg/ce/faults");
        }

        private void menuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void controlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ControlPanel.Show();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainBrowser.Navigate("https://ismm.sg/ce/faults");
        }
    }
}
