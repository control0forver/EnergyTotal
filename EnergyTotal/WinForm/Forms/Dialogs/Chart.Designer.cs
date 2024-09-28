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
            debugToolStripMenuItem = new ToolStripMenuItem();
            loadDemosToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            chartCursorValueLabel = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainChart
            // 
            mainChart.BackColor = SystemColors.Control;
            mainChart.DisplayScale = 1F;
            resources.ApplyResources(mainChart, "mainChart");
            mainChart.Name = "mainChart";
            mainChart.MouseDown += OnMainChartMouseDown;
            mainChart.MouseMove += OnMainChartMouseMove;
            mainChart.MouseUp += OnMainChartMouseUp;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { chartToolStripMenuItem, debugToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // chartToolStripMenuItem
            // 
            chartToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { refreshToolStripMenuItem, pausedToolStripMenuItem, autoScaleToolStripMenuItem, clearToolStripMenuItem, filterToolStripMenuItem });
            chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            resources.ApplyResources(chartToolStripMenuItem, "chartToolStripMenuItem");
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            resources.ApplyResources(refreshToolStripMenuItem, "refreshToolStripMenuItem");
            refreshToolStripMenuItem.Click += OnRefreshClick;
            // 
            // pausedToolStripMenuItem
            // 
            pausedToolStripMenuItem.CheckOnClick = true;
            pausedToolStripMenuItem.Name = "pausedToolStripMenuItem";
            resources.ApplyResources(pausedToolStripMenuItem, "pausedToolStripMenuItem");
            pausedToolStripMenuItem.CheckedChanged += OnPausedCheckedChanged;
            // 
            // autoScaleToolStripMenuItem
            // 
            autoScaleToolStripMenuItem.Checked = true;
            autoScaleToolStripMenuItem.CheckOnClick = true;
            autoScaleToolStripMenuItem.CheckState = CheckState.Checked;
            autoScaleToolStripMenuItem.Name = "autoScaleToolStripMenuItem";
            resources.ApplyResources(autoScaleToolStripMenuItem, "autoScaleToolStripMenuItem");
            autoScaleToolStripMenuItem.CheckedChanged += OnAutoScaleCheckedChanged;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(clearToolStripMenuItem, "clearToolStripMenuItem");
            clearToolStripMenuItem.Click += OnClearClick;
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.Checked = true;
            filterToolStripMenuItem.CheckOnClick = true;
            filterToolStripMenuItem.CheckState = CheckState.Checked;
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { recordLifeChangesOnlyToolStripMenuItem });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            resources.ApplyResources(filterToolStripMenuItem, "filterToolStripMenuItem");
            filterToolStripMenuItem.CheckedChanged += OnFilterCheckedChanged;
            // 
            // recordLifeChangesOnlyToolStripMenuItem
            // 
            recordLifeChangesOnlyToolStripMenuItem.Checked = true;
            recordLifeChangesOnlyToolStripMenuItem.CheckOnClick = true;
            recordLifeChangesOnlyToolStripMenuItem.CheckState = CheckState.Checked;
            recordLifeChangesOnlyToolStripMenuItem.Name = "recordLifeChangesOnlyToolStripMenuItem";
            resources.ApplyResources(recordLifeChangesOnlyToolStripMenuItem, "recordLifeChangesOnlyToolStripMenuItem");
            recordLifeChangesOnlyToolStripMenuItem.CheckedChanged += OnFilterRecordOnLifePercentChangesOnlyCheckedChanged;
            // 
            // debugToolStripMenuItem
            // 
            debugToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadDemosToolStripMenuItem });
            debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            resources.ApplyResources(debugToolStripMenuItem, "debugToolStripMenuItem");
            // 
            // loadDemosToolStripMenuItem
            // 
            loadDemosToolStripMenuItem.Name = "loadDemosToolStripMenuItem";
            resources.ApplyResources(loadDemosToolStripMenuItem, "loadDemosToolStripMenuItem");
            loadDemosToolStripMenuItem.Click += OnDebugLoadDemosClick;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { chartCursorValueLabel });
            resources.ApplyResources(statusStrip, "statusStrip");
            statusStrip.Name = "statusStrip";
            // 
            // chartCursorValueLabel
            // 
            chartCursorValueLabel.Name = "chartCursorValueLabel";
            resources.ApplyResources(chartCursorValueLabel, "chartCursorValueLabel");
            // 
            // Chart
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statusStrip);
            Controls.Add(mainChart);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Chart";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem chartToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem pausedToolStripMenuItem;
        private ToolStripMenuItem autoScaleToolStripMenuItem;
        private ToolStripMenuItem filterToolStripMenuItem;
        private ToolStripMenuItem recordLifeChangesOnlyToolStripMenuItem;
        private StatusStrip statusStrip;
        protected internal ScottPlot.WinForms.FormsPlot mainChart;
        protected internal ToolStripStatusLabel chartCursorValueLabel;
        private ToolStripMenuItem debugToolStripMenuItem;
        private ToolStripMenuItem loadDemosToolStripMenuItem;
    }
}