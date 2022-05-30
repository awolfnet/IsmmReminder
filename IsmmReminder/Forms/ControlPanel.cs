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
    public partial class ControlPanel : Form
    {
        public ControlPanel()
        {
            InitializeComponent();
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Fault Number";
            dataGridView1.Columns[1].Name = "Reported Date";
            dataGridView1.Columns[2].Name = "Fault Acknowledged Date";
            dataGridView1.Columns[3].Name = "Responded on Site Date";
            dataGridView1.Columns[4].Name = "RA Conducted Date";
            dataGridView1.Columns[5].Name = "Work Started Date";
            dataGridView1.Columns[6].Name = "Work Completed Date";

        }
    }
}
