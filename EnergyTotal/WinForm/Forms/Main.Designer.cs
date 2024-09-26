namespace EnergyTotal.WinForm.Forms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            mainLayoutPanel = new TableLayoutPanel();
            LogTextBox = new TextBox();
            mainMenu = new MenuStrip();
            monitorToolStripMenuItem = new ToolStripMenuItem();
            enabledToolStripMenuItem = new ToolStripMenuItem();
            intervalToolStripMenuItem = new ToolStripMenuItem();
            intervalCurrentValueToolStripMenuItem = new ToolStripMenuItem();
            setNewToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            chartToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutEnergyTotalToolStripMenuItem = new ToolStripMenuItem();
            mainLayoutPanel.SuspendLayout();
            mainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            resources.ApplyResources(mainLayoutPanel, "mainLayoutPanel");
            mainLayoutPanel.Controls.Add(LogTextBox, 0, 1);
            mainLayoutPanel.Controls.Add(mainMenu, 0, 0);
            mainLayoutPanel.Name = "mainLayoutPanel";
            // 
            // LogTextBox
            // 
            LogTextBox.BackColor = Color.Black;
            resources.ApplyResources(LogTextBox, "LogTextBox");
            LogTextBox.ForeColor = Color.White;
            LogTextBox.Name = "LogTextBox";
            LogTextBox.ReadOnly = true;
            // 
            // mainMenu
            // 
            resources.ApplyResources(mainMenu, "mainMenu");
            mainMenu.Items.AddRange(new ToolStripItem[] { monitorToolStripMenuItem, helpToolStripMenuItem });
            mainMenu.Name = "mainMenu";
            // 
            // monitorToolStripMenuItem
            // 
            monitorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { enabledToolStripMenuItem, intervalToolStripMenuItem, viewToolStripMenuItem });
            monitorToolStripMenuItem.Name = "monitorToolStripMenuItem";
            resources.ApplyResources(monitorToolStripMenuItem, "monitorToolStripMenuItem");
            // 
            // enabledToolStripMenuItem
            // 
            enabledToolStripMenuItem.Checked = true;
            enabledToolStripMenuItem.CheckOnClick = true;
            enabledToolStripMenuItem.CheckState = CheckState.Checked;
            enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            resources.ApplyResources(enabledToolStripMenuItem, "enabledToolStripMenuItem");
            enabledToolStripMenuItem.CheckedChanged += OnEnabledCheckedChanged;
            // 
            // intervalToolStripMenuItem
            // 
            intervalToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { intervalCurrentValueToolStripMenuItem, setNewToolStripMenuItem });
            intervalToolStripMenuItem.Name = "intervalToolStripMenuItem";
            resources.ApplyResources(intervalToolStripMenuItem, "intervalToolStripMenuItem");
            // 
            // intervalCurrentValueToolStripMenuItem
            // 
            resources.ApplyResources(intervalCurrentValueToolStripMenuItem, "intervalCurrentValueToolStripMenuItem");
            intervalCurrentValueToolStripMenuItem.Name = "intervalCurrentValueToolStripMenuItem";
            // 
            // setNewToolStripMenuItem
            // 
            setNewToolStripMenuItem.Name = "setNewToolStripMenuItem";
            resources.ApplyResources(setNewToolStripMenuItem, "setNewToolStripMenuItem");
            setNewToolStripMenuItem.Click += OnSetNewMonitorIntervalClick;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chartToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // chartToolStripMenuItem
            // 
            chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            resources.ApplyResources(chartToolStripMenuItem, "chartToolStripMenuItem");
            chartToolStripMenuItem.Click += OnViewChartClick;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutEnergyTotalToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutEnergyTotalToolStripMenuItem
            // 
            aboutEnergyTotalToolStripMenuItem.Name = "aboutEnergyTotalToolStripMenuItem";
            resources.ApplyResources(aboutEnergyTotalToolStripMenuItem, "aboutEnergyTotalToolStripMenuItem");
            aboutEnergyTotalToolStripMenuItem.Click += OnAboutClick;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MainMenuStrip = mainMenu;
            Name = "Main";
            FormClosing += OnMainClosing;
            mainLayoutPanel.ResumeLayout(false);
            mainLayoutPanel.PerformLayout();
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel mainLayoutPanel;
        private TextBox LogTextBox;
        private MenuStrip mainMenu;
        private ToolStripMenuItem monitorToolStripMenuItem;
        private ToolStripMenuItem enabledToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutEnergyTotalToolStripMenuItem;
        private ToolStripMenuItem chartToolStripMenuItem;
        private ToolStripMenuItem intervalToolStripMenuItem;
        private ToolStripMenuItem intervalCurrentValueToolStripMenuItem;
        private ToolStripMenuItem setNewToolStripMenuItem;
    }
}
