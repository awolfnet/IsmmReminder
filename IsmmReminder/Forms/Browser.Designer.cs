
namespace IsmmReminder.Forms
{
    partial class Browser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReload = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHome = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControlPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowControlPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFetch = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBrowser,
            this.menuControlPanel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1308, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuBrowser
            // 
            this.menuBrowser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReload,
            this.menuHome,
            this.menuDebug});
            this.menuBrowser.Name = "menuBrowser";
            this.menuBrowser.Size = new System.Drawing.Size(91, 29);
            this.menuBrowser.Text = "&Browser";
            // 
            // menuReload
            // 
            this.menuReload.Name = "menuReload";
            this.menuReload.Size = new System.Drawing.Size(168, 34);
            this.menuReload.Text = "&Reload";
            this.menuReload.Click += new System.EventHandler(this.menuReload_Click);
            // 
            // menuHome
            // 
            this.menuHome.Name = "menuHome";
            this.menuHome.Size = new System.Drawing.Size(168, 34);
            this.menuHome.Text = "&Home";
            this.menuHome.Click += new System.EventHandler(this.menuHome_Click);
            // 
            // menuDebug
            // 
            this.menuDebug.Name = "menuDebug";
            this.menuDebug.Size = new System.Drawing.Size(168, 34);
            this.menuDebug.Text = "&Debug";
            this.menuDebug.Click += new System.EventHandler(this.menuDebug_Click);
            // 
            // menuControlPanel
            // 
            this.menuControlPanel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowControlPanel,
            this.menuMessage,
            this.menuStart,
            this.menuFetch,
            this.stopToolStripMenuItem,
            this.statusToolStripMenuItem});
            this.menuControlPanel.Name = "menuControlPanel";
            this.menuControlPanel.Size = new System.Drawing.Size(133, 29);
            this.menuControlPanel.Text = "&Control Panel";
            this.menuControlPanel.Click += new System.EventHandler(this.menuControlPanel_Click);
            // 
            // menuShowControlPanel
            // 
            this.menuShowControlPanel.Name = "menuShowControlPanel";
            this.menuShowControlPanel.Size = new System.Drawing.Size(270, 34);
            this.menuShowControlPanel.Text = "&Show";
            this.menuShowControlPanel.Click += new System.EventHandler(this.menuShowControlPanel_Click);
            // 
            // menuMessage
            // 
            this.menuMessage.Name = "menuMessage";
            this.menuMessage.Size = new System.Drawing.Size(270, 34);
            this.menuMessage.Text = "&Message";
            this.menuMessage.Click += new System.EventHandler(this.menuMessage_Click);
            // 
            // menuStart
            // 
            this.menuStart.Name = "menuStart";
            this.menuStart.Size = new System.Drawing.Size(270, 34);
            this.menuStart.Text = "S&tart";
            this.menuStart.Click += new System.EventHandler(this.menuStart_Click);
            // 
            // menuFetch
            // 
            this.menuFetch.Name = "menuFetch";
            this.menuFetch.Size = new System.Drawing.Size(270, 34);
            this.menuFetch.Text = "&Fetch";
            this.menuFetch.Click += new System.EventHandler(this.menuFetch_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.stopToolStripMenuItem.Text = "Sto&p";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.statusToolStripMenuItem.Text = "S&tatus";
            this.statusToolStripMenuItem.Click += new System.EventHandler(this.statusToolStripMenuItem_Click);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 794);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Browser";
            this.Text = "Browser";
            this.Load += new System.EventHandler(this.Browser_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuBrowser;
        private System.Windows.Forms.ToolStripMenuItem menuReload;
        private System.Windows.Forms.ToolStripMenuItem menuHome;
        private System.Windows.Forms.ToolStripMenuItem menuControlPanel;
        private System.Windows.Forms.ToolStripMenuItem menuShowControlPanel;
        private System.Windows.Forms.ToolStripMenuItem menuMessage;
        private System.Windows.Forms.ToolStripMenuItem menuStart;
        private System.Windows.Forms.ToolStripMenuItem menuDebug;
        private System.Windows.Forms.ToolStripMenuItem menuFetch;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
    }
}

