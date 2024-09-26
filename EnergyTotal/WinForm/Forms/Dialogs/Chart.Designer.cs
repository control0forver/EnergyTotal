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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chart));
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
            resources.ApplyResources(mainChart, "mainChart");
            mainChart.BackColor = SystemColors.Control;
            mainChart.DisplayScale = 1F;
            mainChart.Name = "mainChart";
            mainChart.MouseDown += OnMainChartMouseDown;
            mainChart.MouseUp += OnMainChartMouseUp;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Items.AddRange(new ToolStripItem[] { chartToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            // 
            // chartToolStripMenuItem
            // 
            resources.ApplyResources(chartToolStripMenuItem, "chartToolStripMenuItem");
            chartToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { refreshToolStripMenuItem, pausedToolStripMenuItem, autoScaleToolStripMenuItem, clearToolStripMenuItem, filterToolStripMenuItem });
            chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            // 
            // refreshToolStripMenuItem
            // 
            resources.ApplyResources(refreshToolStripMenuItem, "refreshToolStripMenuItem");
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Click += OnRefreshClick;
            // 
            // pausedToolStripMenuItem
            // 
            resources.ApplyResources(pausedToolStripMenuItem, "pausedToolStripMenuItem");
            pausedToolStripMenuItem.CheckOnClick = true;
            pausedToolStripMenuItem.Name = "pausedToolStripMenuItem";
            pausedToolStripMenuItem.CheckedChanged += OnPausedCheckedChanged;
            // 
            // autoScaleToolStripMenuItem
            // 
            resources.ApplyResources(autoScaleToolStripMenuItem, "autoScaleToolStripMenuItem");
            autoScaleToolStripMenuItem.Checked = true;
            autoScaleToolStripMenuItem.CheckOnClick = true;
            autoScaleToolStripMenuItem.CheckState = CheckState.Checked;
            autoScaleToolStripMenuItem.Name = "autoScaleToolStripMenuItem";
            autoScaleToolStripMenuItem.CheckedChanged += OnAutoScaleCheckedChanged;
            // 
            // clearToolStripMenuItem
            // 
            resources.ApplyResources(clearToolStripMenuItem, "clearToolStripMenuItem");
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Click += OnClearClick;
            // 
            // filterToolStripMenuItem
            // 
            resources.ApplyResources(filterToolStripMenuItem, "filterToolStripMenuItem");
            filterToolStripMenuItem.Checked = true;
            filterToolStripMenuItem.CheckOnClick = true;
            filterToolStripMenuItem.CheckState = CheckState.Checked;
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { recordLifeChangesOnlyToolStripMenuItem });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.CheckedChanged += OnFilterCheckedChanged;
            // 
            // recordLifeChangesOnlyToolStripMenuItem
            // 
            resources.ApplyResources(recordLifeChangesOnlyToolStripMenuItem, "recordLifeChangesOnlyToolStripMenuItem");
            recordLifeChangesOnlyToolStripMenuItem.Checked = true;
            recordLifeChangesOnlyToolStripMenuItem.CheckOnClick = true;
            recordLifeChangesOnlyToolStripMenuItem.CheckState = CheckState.Checked;
            recordLifeChangesOnlyToolStripMenuItem.Name = "recordLifeChangesOnlyToolStripMenuItem";
            recordLifeChangesOnlyToolStripMenuItem.CheckedChanged += OnFilterRecordOnLifePercentChangesOnlyCheckedChanged;
            // 
            // Chart
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainChart);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Chart";
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