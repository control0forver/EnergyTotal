using ScottPlot;

namespace EnergyTotal.WinForm.Forms.Dialogs
{
    partial class Chart
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
            mainChart = new ScottPlot.WinForms.FormsPlot();
            menuStrip1 = new MenuStrip();
            chartToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            pausedToolStripMenuItem = new ToolStripMenuItem();
            autoScaleToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            filterToolStripMenuItem = new ToolStripMenuItem();
            recordLifeChangesOnlyToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mainChart
            // 
            mainChart.BackColor = SystemColors.Control;
            mainChart.DisplayScale = 1F;
            mainChart.Dock = DockStyle.Fill;
            mainChart.Location = new Point(0, 25);
            mainChart.Name = "mainChart";
            mainChart.Size = new Size(800, 425);
            mainChart.TabIndex = 2;
            mainChart.MouseDown += OnMainChartMouseDown;
            mainChart.MouseUp += OnMainChartMouseUp;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { chartToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 25);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // chartToolStripMenuItem
            // 
            chartToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { refreshToolStripMenuItem, pausedToolStripMenuItem, autoScaleToolStripMenuItem, clearToolStripMenuItem, filterToolStripMenuItem });
            chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            chartToolStripMenuItem.Size = new Size(59, 21);
            chartToolStripMenuItem.Text = "(&C)hart";
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.ShortcutKeys = Keys.F5;
            refreshToolStripMenuItem.Size = new Size(180, 22);
            refreshToolStripMenuItem.Text = "(&R)efresh";
            refreshToolStripMenuItem.Click += OnRefreshClick;
            // 
            // pausedToolStripMenuItem
            // 
            pausedToolStripMenuItem.CheckOnClick = true;
            pausedToolStripMenuItem.Name = "pausedToolStripMenuItem";
            pausedToolStripMenuItem.ShortcutKeys = Keys.F6;
            pausedToolStripMenuItem.Size = new Size(180, 22);
            pausedToolStripMenuItem.Text = "(&P)aused";
            pausedToolStripMenuItem.CheckedChanged += OnPausedCheckedChanged;
            // 
            // autoScaleToolStripMenuItem
            // 
            autoScaleToolStripMenuItem.Checked = true;
            autoScaleToolStripMenuItem.CheckOnClick = true;
            autoScaleToolStripMenuItem.CheckState = CheckState.Checked;
            autoScaleToolStripMenuItem.Name = "autoScaleToolStripMenuItem";
            autoScaleToolStripMenuItem.ShortcutKeys = Keys.F7;
            autoScaleToolStripMenuItem.Size = new Size(180, 22);
            autoScaleToolStripMenuItem.Text = "(&A)uto Scale";
            autoScaleToolStripMenuItem.CheckedChanged += OnAutoScaleCheckedChanged;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            clearToolStripMenuItem.Size = new Size(180, 22);
            clearToolStripMenuItem.Text = "(C)lear";
            clearToolStripMenuItem.Click += OnClearClick;
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.Checked = true;
            filterToolStripMenuItem.CheckOnClick = true;
            filterToolStripMenuItem.CheckState = CheckState.Checked;
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { recordLifeChangesOnlyToolStripMenuItem });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.Size = new Size(180, 22);
            filterToolStripMenuItem.Text = "(&F)ilter";
            filterToolStripMenuItem.CheckedChanged += OnFilterCheckedChanged;
            // 
            // recordLifeChangesOnlyToolStripMenuItem
            // 
            recordLifeChangesOnlyToolStripMenuItem.Checked = true;
            recordLifeChangesOnlyToolStripMenuItem.CheckOnClick = true;
            recordLifeChangesOnlyToolStripMenuItem.CheckState = CheckState.Checked;
            recordLifeChangesOnlyToolStripMenuItem.Name = "recordLifeChangesOnlyToolStripMenuItem";
            recordLifeChangesOnlyToolStripMenuItem.Size = new Size(245, 22);
            recordLifeChangesOnlyToolStripMenuItem.Text = "Record on Life Changes Only";
            recordLifeChangesOnlyToolStripMenuItem.CheckedChanged += OnFilterRecordOnLifePercentChangesOnlyCheckedChanged;
            // 
            // Chart
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainChart);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Chart";
            Text = "Monitor Chart View";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot mainChart;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem chartToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem pausedToolStripMenuItem;
        private ToolStripMenuItem autoScaleToolStripMenuItem;
        private ToolStripMenuItem filterToolStripMenuItem;
        private ToolStripMenuItem recordLifeChangesOnlyToolStripMenuItem;
    }
}