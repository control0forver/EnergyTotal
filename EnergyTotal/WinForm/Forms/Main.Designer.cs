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
            mainLayoutPanel.ColumnCount = 1;
            mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayoutPanel.Controls.Add(LogTextBox, 0, 1);
            mainLayoutPanel.Controls.Add(mainMenu, 0, 0);
            mainLayoutPanel.Dock = DockStyle.Fill;
            mainLayoutPanel.Location = new Point(0, 0);
            mainLayoutPanel.Name = "mainLayoutPanel";
            mainLayoutPanel.RowCount = 2;
            mainLayoutPanel.RowStyles.Add(new RowStyle());
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainLayoutPanel.Size = new Size(354, 235);
            mainLayoutPanel.TabIndex = 2;
            // 
            // LogTextBox
            // 
            LogTextBox.BackColor = Color.Black;
            LogTextBox.Dock = DockStyle.Fill;
            LogTextBox.ForeColor = Color.White;
            LogTextBox.Location = new Point(3, 28);
            LogTextBox.Multiline = true;
            LogTextBox.Name = "LogTextBox";
            LogTextBox.ReadOnly = true;
            LogTextBox.Size = new Size(348, 204);
            LogTextBox.TabIndex = 1;
            LogTextBox.WordWrap = false;
            // 
            // mainMenu
            // 
            mainMenu.Dock = DockStyle.Fill;
            mainMenu.Items.AddRange(new ToolStripItem[] { monitorToolStripMenuItem, helpToolStripMenuItem });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(354, 25);
            mainMenu.TabIndex = 3;
            mainMenu.Text = "menuStrip1";
            // 
            // monitorToolStripMenuItem
            // 
            monitorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { enabledToolStripMenuItem, intervalToolStripMenuItem, viewToolStripMenuItem });
            monitorToolStripMenuItem.Name = "monitorToolStripMenuItem";
            monitorToolStripMenuItem.Size = new Size(75, 21);
            monitorToolStripMenuItem.Text = "(&M)onitor";
            // 
            // enabledToolStripMenuItem
            // 
            enabledToolStripMenuItem.Checked = true;
            enabledToolStripMenuItem.CheckOnClick = true;
            enabledToolStripMenuItem.CheckState = CheckState.Checked;
            enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            enabledToolStripMenuItem.ShortcutKeys = Keys.F2;
            enabledToolStripMenuItem.Size = new Size(180, 22);
            enabledToolStripMenuItem.Text = "(&E)nabled";
            enabledToolStripMenuItem.CheckedChanged += OnEnabledCheckedChanged;
            // 
            // intervalToolStripMenuItem
            // 
            intervalToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { intervalCurrentValueToolStripMenuItem, setNewToolStripMenuItem });
            intervalToolStripMenuItem.Name = "intervalToolStripMenuItem";
            intervalToolStripMenuItem.Size = new Size(180, 22);
            intervalToolStripMenuItem.Text = "(&I)nterval";
            // 
            // intervalCurrentValueToolStripMenuItem
            // 
            intervalCurrentValueToolStripMenuItem.Enabled = false;
            intervalCurrentValueToolStripMenuItem.Name = "intervalCurrentValueToolStripMenuItem";
            intervalCurrentValueToolStripMenuItem.Size = new Size(180, 22);
            intervalCurrentValueToolStripMenuItem.Text = "Current: {0}";
            // 
            // setNewToolStripMenuItem
            // 
            setNewToolStripMenuItem.Name = "setNewToolStripMenuItem";
            setNewToolStripMenuItem.ShortcutKeys = Keys.F3;
            setNewToolStripMenuItem.Size = new Size(180, 22);
            setNewToolStripMenuItem.Text = "(&S)et New";
            setNewToolStripMenuItem.Click += OnSetNewMonitorIntervalClick;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chartToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(180, 22);
            viewToolStripMenuItem.Text = "(&V)iew";
            // 
            // chartToolStripMenuItem
            // 
            chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            chartToolStripMenuItem.ShortcutKeys = Keys.F10;
            chartToolStripMenuItem.Size = new Size(143, 22);
            chartToolStripMenuItem.Text = "(&C)hart";
            chartToolStripMenuItem.Click += OnViewChartClick;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutEnergyTotalToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 21);
            helpToolStripMenuItem.Text = "(&H)elp";
            // 
            // aboutEnergyTotalToolStripMenuItem
            // 
            aboutEnergyTotalToolStripMenuItem.Name = "aboutEnergyTotalToolStripMenuItem";
            aboutEnergyTotalToolStripMenuItem.ShortcutKeyDisplayString = "";
            aboutEnergyTotalToolStripMenuItem.ShortcutKeys = Keys.F1;
            aboutEnergyTotalToolStripMenuItem.Size = new Size(217, 22);
            aboutEnergyTotalToolStripMenuItem.Text = "(&A)bout Energy Total";
            aboutEnergyTotalToolStripMenuItem.Click += OnAboutClick;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 235);
            Controls.Add(mainLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MainMenuStrip = mainMenu;
            Name = "Main";
            Text = "Energy Total";
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
