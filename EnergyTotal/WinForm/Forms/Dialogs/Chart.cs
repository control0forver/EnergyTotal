using EnergyTotal.Primitives;
using ScottPlot;
using ScottPlot.AxisPanels;

namespace EnergyTotal.WinForm.Forms.Dialogs
{
    public partial class Chart : Form
    {
        internal bool _isPaused;
        public bool IsPaused
        {
            get
            {
                lock (MainChartInteractionLock)
                    return _isPaused;
            }
            set
            {
                lock (MainChartInteractionLock)
                    _isPaused = value;
            }
        }

        internal bool _isAutoScaleEnabled;
        public bool IsAutoScaleEnabled
        {
            get
            {
                lock (MainChartInteractionLock)
                    return _isAutoScaleEnabled;
            }
            set
            {
                lock (MainChartInteractionLock)
                    _isAutoScaleEnabled = value;
            }
        }

        internal bool _isMainChartInteracting;
        internal bool IsMainChartInteracting
        {
            get
            {
                lock (MainChartInteractionLock)
                    return _isMainChartInteracting;
            }
            set
            {
                lock (MainChartInteractionLock)
                    _isMainChartInteracting = value;
            }
        }

        internal bool isFilterEnabled = default;
        internal bool useFilter_RecordOnLifePercentChangesOnly = default;

        /// <summary>
        /// Object Lock for <see cref="IsPaused"/>, <see cref="IsAutoScaleEnabled"/>, <see cref="IsMainChartInteracting"/>
        /// </summary>
        internal object MainChartInteractionLock = new();

        internal readonly List<DateTime> xs = [];
        internal readonly List<float> ys = [];

        public Chart()
        {
            InitializeComponent();

            IsPaused = pausedToolStripMenuItem.Checked;
            IsAutoScaleEnabled = autoScaleToolStripMenuItem.Checked;
            IsMainChartInteracting = false;

            isFilterEnabled = filterToolStripMenuItem.Checked;
            useFilter_RecordOnLifePercentChangesOnly = recordLifeChangesOnlyToolStripMenuItem.Checked;

            Clear();
        }

        public void AddRecord(EnergyRecord record, bool filter = true)
        {
            if (filter && !Filter(record))
                return;

            xs.Add(record.Time);
            ys.Add(record.LifePercent * 100);
            //var color = record.Status switch
            //{
            //    EnergyStatus.Status.Discharging => Color.Orange,
            //    EnergyStatus.Status.Charging => Color.Green,
            //    _ => Color.Gray
            //};

            UpdateChart();
        }

        public void Clear()
        {
            xs.Clear();
            ys.Clear();
            UpdateChart(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        /// <returns><c>false</c> if record should not be used.</returns>
        protected virtual bool Filter(EnergyRecord record)
        {
            bool use = true;

            if (!isFilterEnabled)
                return use;

            if (useFilter_RecordOnLifePercentChangesOnly)
            {
                try
                {
                    if (record.LifePercent*100 == ys.Last())
                        use = false;
                }
                catch { }
            }

            return use;
        }

        internal void StyleChart()
        {
            lock (MainChartInteractionLock)
            {
                var plot = mainChart.Plot;

                var dateTimeXAxis = plot.Axes.DateTimeTicksBottom();

                if (IsAutoScaleEnabled)
                {
                    plot.Axes.SetLimits(
                        bottom: 0,
                        top: 100,
                        left: dateTimeXAxis.Min,
                        right: dateTimeXAxis.Max);
                }

                plot.Title($"Last Fetched: {DateTime.Now}");
                plot.XLabel("Time");
                plot.YLabel("Life Percent");
            }
        }

        /// <summary>
        /// (Operation will be cancelled if value of <see cref="IsPaused"/> property is <c>true</c>)
        /// </summary>
        internal void UpdateChart(bool force = false)
        {
            lock (MainChartInteractionLock)
            {
                if (IsPaused && !force)
                    return;

                var plot = mainChart.Plot;

                var axisLimitsBackup = plot.Axes.GetLimits();

                // Problems on UI if we don't rebind scatters.
                plot.Clear();
                plot.Add.Scatter(xs, ys);

                StyleChart();

                if (!IsAutoScaleEnabled && !IsMainChartInteracting)
                    plot.Axes.SetLimits(axisLimitsBackup);

                mainChart.Refresh();
            }
        }

        #region Private Events

        internal bool isPausedBackup = default;
        internal bool isMainChartInteractingBackup = default;
        internal bool isAutoScaleEnabledBackup = default;
        private void OnMainChartMouseDown(object sender, MouseEventArgs e)
        {
            lock (MainChartInteractionLock)
            {
                isPausedBackup = IsPaused;
                isMainChartInteractingBackup = IsMainChartInteracting;
                isAutoScaleEnabledBackup = IsAutoScaleEnabled;

                IsPaused = true;
                IsAutoScaleEnabled = false;
                IsMainChartInteracting = true;
            }
        }

        private void OnMainChartMouseUp(object sender, MouseEventArgs e)
        {
            lock (MainChartInteractionLock)
            {
                IsPaused = isPausedBackup;
                IsMainChartInteracting = isMainChartInteractingBackup;
                IsAutoScaleEnabled = isAutoScaleEnabledBackup;
            }
        }

        private void OnRefreshClick(object sender, EventArgs e)
        {
            UpdateChart(force: true);
        }

        private void OnPausedCheckedChanged(object sender, EventArgs e)
        {
            IsPaused = pausedToolStripMenuItem.Checked;
        }

        private void OnAutoScaleCheckedChanged(object sender, EventArgs e)
        {
            IsAutoScaleEnabled = autoScaleToolStripMenuItem.Checked;
        }

        private void OnClearClick(object sender, EventArgs e)
        {
            Clear();
        }

        private void OnFilterCheckedChanged(object sender, EventArgs e)
        {
            isFilterEnabled = filterToolStripMenuItem.Checked;
        }

        private void OnFilterRecordOnLifePercentChangesOnlyCheckedChanged(object sender, EventArgs e)
        {
            useFilter_RecordOnLifePercentChangesOnly = recordLifeChangesOnlyToolStripMenuItem.Checked;
        }

        #endregion
    }
}
