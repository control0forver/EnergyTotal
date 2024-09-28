using EnergyTotal.Primitives;
using System.Diagnostics;

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
        public bool IsAutoScalingEnabled
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


        internal float _mainChartCrosshairSize = 15f;
        internal float MainChartCrosshairSize { get => _mainChartCrosshairSize; set => _mainChartCrosshairSize = value; }


        internal bool isFilterEnabled = default;
        internal bool useFilter_RecordOnLifePercentChangesOnly = default;

        /// <summary>
        /// Object Lock for <see cref="IsPaused"/>, <see cref="IsAutoScalingEnabled"/>, <see cref="IsMainChartInteracting"/>
        /// </summary>
        internal object MainChartInteractionLock = new();

        internal readonly List<EnergyRecord> energyRecords = [];
        internal readonly Stack<EnergyRecord> delayedEnergyRecords = [];

        public Chart()
        {
            InitializeComponent();

#if DEBUG
            debugToolStripMenuItem.Visible = true;
#else
            debugToolStripMenuItem.Visible = false;
#endif

            IsPaused = pausedToolStripMenuItem.Checked;
            IsAutoScalingEnabled = autoScaleToolStripMenuItem.Checked;
            IsMainChartInteracting = false;

            isFilterEnabled = filterToolStripMenuItem.Checked;
            useFilter_RecordOnLifePercentChangesOnly = recordLifeChangesOnlyToolStripMenuItem.Checked;

            Clear();
        }

        public void AddRecords(bool filter = true, params EnergyRecord[] records)
        {
            foreach (var record in records)
            {

                if (filter && !Filter(record))
                    return;

                if (IsPaused)
                {
                    delayedEnergyRecords.Push(record);
                }
                else
                {
                    RestoreAllDelayedRecords();

                    energyRecords.Add(record);
                }
            }

            if (!IsPaused)
                UpdateChart();
        }

        public void Clear()
        {
            energyRecords.Clear();
            delayedEnergyRecords.Clear();

            UpdateChart();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        /// <returns><c>false</c> if recordScatter should not be used.</returns>
        protected virtual bool Filter(EnergyRecord record)
        {
            bool use = true;

            if (!isFilterEnabled)
                return use;

            if (useFilter_RecordOnLifePercentChangesOnly)
            {
                try
                {
                    if (record.LifePercent == energyRecords.Last().LifePercent)
                        use = false;
                }
                catch { }
            }

            return use;
        }

        internal void RestoreAllDelayedRecords()
        {
            while (delayedEnergyRecords.Count > 0)
                energyRecords.Add(delayedEnergyRecords.Pop());
        }

        internal void StyleChart(bool scale)
        {
            lock (MainChartInteractionLock)
            {
                var plot = mainChart.Plot;

                var dateTimeXAxis = plot.Axes.DateTimeTicksBottom();

                if (scale)
                {
                    plot.Axes.SetLimits(
                        bottom: 0,
                        top: 100,
                        left: dateTimeXAxis.Min,
                        right: dateTimeXAxis.Max);
                }

                plot.Title($"Last Fetched: {DateTime.Now}");
                plot.XLabel("Time");
                plot.YLabel("Battery Percent");
            }
        }

        internal IReadOnlyList<ScottPlot.Plottables.Scatter> UpdateChart(bool clear = true, bool present = true)
        {
            lock (MainChartInteractionLock)
            {
                var shouldBackupAndRestore = !IsAutoScalingEnabled && !IsMainChartInteracting;

                var plot = mainChart.Plot;

                var axisLimitsBackup = plot.Axes.GetLimits();

                if (clear)
                {
                    plot.Clear<ScottPlot.Plottables.VerticalLine>();
                    plot.Clear<ScottPlot.Plottables.Scatter>();
                }

                List<ScottPlot.Plottables.Scatter> scatters = [];

                IEnumerable<EnergyRecord>? _lastRecords = null;
                foreach (var records in energyRecords.SplitRecordsByStatus())
                {
                    if (records.Count <= 0)
                        continue;

                    var color = (records[0].Status switch
                    {
                        EnergyStatus.Status.Discharging => ScottPlot.Colors.Orange,
                        EnergyStatus.Status.Charging => ScottPlot.Colors.Green,
                        _ => ScottPlot.Colors.Gray
                    });

                    var px = (_lastRecords?.Last().Time ?? records[0].Time).ToOADate();
                    var py = (_lastRecords?.Last().LifePercent ?? records[0].LifePercent) * 100;
                    double[] xs = [px, .. records.Select(_ => _.Time.ToOADate())];
                    float[] ys = [py, .. records.Select(_ => _.LifePercent * 100)];

                    plot.Add.VerticalLine(px, 1, color, ScottPlot.LinePattern.DenselyDashed);

                    var batteryLifeRecord = plot.Add.Scatter(xs, ys);
                    batteryLifeRecord.Smooth = true;
                    batteryLifeRecord.SmoothTension = 1;

                    batteryLifeRecord.Color = color;

                    batteryLifeRecord.LineWidth = 2f;

                    batteryLifeRecord.MarkerShape = ScottPlot.MarkerShape.Cross;
                    batteryLifeRecord.MarkerSize = _mainChartCrosshairSize;

                    batteryLifeRecord.FillY = true;
                    batteryLifeRecord.FillYColor = color.WithAlpha(0.15);

                    if (batteryLifeRecord is not null)
                        scatters.Add(batteryLifeRecord);

                    _lastRecords = records;
                }

                if (present)
                    StyleChart(IsAutoScalingEnabled);

                if (shouldBackupAndRestore)
                    plot.Axes.SetLimits(axisLimitsBackup);

                if (present)
                    mainChart.Refresh();

                return scatters.AsReadOnly();
            }
        }

        internal IReadOnlyList<ScottPlot.Plottables.Crosshair> UpdateChartCrosshair(bool clear = true, bool present = true, params ((double X, double Y) Coordinates, Action<ScottPlot.Plottables.Crosshair>? CrosshairCustom)[] crosshairs)
        {
            var _crosshairs = new List<ScottPlot.Plottables.Crosshair>();

            var plot = mainChart.Plot;

            if (clear)
                plot.Clear<ScottPlot.Plottables.Crosshair>();

            foreach (var (coordinates, callback) in crosshairs)
            {
                var crosshair = plot.Add.Crosshair(coordinates.X, coordinates.Y);
                callback?.Invoke(crosshair);
                _crosshairs.Add(crosshair);
            }

            if (present)
                mainChart.Refresh();

            return _crosshairs.AsReadOnly();
        }

        #region Private Events

        private bool isPausedBackup = default;
        private bool isMainChartInteractingBackup = default;
        private bool isAutoScaleEnabledBackup = default;
        private void OnMainChartMouseDown(object sender, MouseEventArgs e)
        {
            lock (MainChartInteractionLock)
            {
                isPausedBackup = IsPaused;
                isMainChartInteractingBackup = IsMainChartInteracting;
                isAutoScaleEnabledBackup = IsAutoScalingEnabled;

                IsPaused = true;
                IsAutoScalingEnabled = false;
                IsMainChartInteracting = true;
            }
        }

        private void OnMainChartMouseUp(object sender, MouseEventArgs e)
        {
            lock (MainChartInteractionLock)
            {
                IsPaused = isPausedBackup;
                IsMainChartInteracting = isMainChartInteractingBackup;
                IsAutoScalingEnabled = isAutoScaleEnabledBackup;
            }
        }

        private (Task, CancellationTokenSource)? chartLabelUpdater = null;
        private readonly Stopwatch chartLabelUpdateCounter = new();
        private readonly TimeSpan chartLabelUpdateRateLimit = TimeSpan.FromMilliseconds(15);
        private void OnMainChartMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is not ScottPlot.WinForms.FormsPlot chart)
                return;

            // Rate Limit
            if (chartLabelUpdateCounter.IsRunning && chartLabelUpdateCounter.Elapsed < chartLabelUpdateRateLimit)
                return;

            chartLabelUpdateCounter.Restart();

            try { chartLabelUpdater?.Item2.Cancel(); }
            finally { chartLabelUpdater?.Item2.Dispose(); }

            var cancellationTokenSource = new CancellationTokenSource();
            chartLabelUpdater = (
                Task.Run(
                    cancellationToken: cancellationTokenSource.Token,
                    action: () =>
                    Invoke(() =>
                    {
                        try { this.DrawRecordInfo(e.Location, this._mainChartCrosshairSize); } catch (OperationCanceledException) { }
                    })),
                cancellationTokenSource);
        }

        private void OnRefreshClick(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void OnPausedCheckedChanged(object sender, EventArgs e)
        {
            IsPaused = pausedToolStripMenuItem.Checked;
        }

        private void OnAutoScaleCheckedChanged(object sender, EventArgs e)
        {
            IsAutoScalingEnabled = autoScaleToolStripMenuItem.Checked;
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

        private void OnDebugLoadDemosClick(object sender, EventArgs e)
        {
            AddRecords(
                filter: false,
                records:
                [
                    new(DateTime.Now+TimeSpan.FromSeconds(1), EnergyStatus.Status.Unknown, 0.25f),
                    new(DateTime.Now+TimeSpan.FromSeconds(2), EnergyStatus.Status.Unknown, 0.25f),
                    new(DateTime.Now+TimeSpan.FromSeconds(3), EnergyStatus.Status.Charging, 0.3f),
                    new(DateTime.Now+TimeSpan.FromSeconds(4), EnergyStatus.Status.Charging, 0.4f),
                    new(DateTime.Now+TimeSpan.FromSeconds(5), EnergyStatus.Status.Charging, 0.5f),
                    new(DateTime.Now+TimeSpan.FromSeconds(6), EnergyStatus.Status.Charging, 0.5f),
                    new(DateTime.Now+TimeSpan.FromSeconds(7), EnergyStatus.Status.Discharging, 0.4f),
                    new(DateTime.Now+TimeSpan.FromSeconds(8), EnergyStatus.Status.Discharging, 0.3f),
                    new(DateTime.Now+TimeSpan.FromSeconds(9), EnergyStatus.Status.Discharging, 0.2f)
                ]
            );

            UpdateChart();
        }

        #endregion

    }

    public static class ChartExtensions
    {
        public static void DrawRecordInfo(this Chart @this, Point cursorInChart, float maxDistance = 15f)
        {
            var plot = @this.mainChart.Plot;

            var cursorCoordinatesInPlot = plot.GetCoordinates(cursorInChart.X, cursorInChart.Y);

            var crosshair = new ScottPlot.Coordinates(cursorCoordinatesInPlot.X, cursorCoordinatesInPlot.Y);
            var hitNearest = @this.GetNearestRecordCoordinates(cursorCoordinatesInPlot, out var nearestRecordCoordinates, maxDistance);

            plot.Clear<ScottPlot.Plottables.Annotation>();
            if (hitNearest && nearestRecordCoordinates.HasValue)
            {
                crosshair = nearestRecordCoordinates.Value.Record;

                plot.Add.Annotation($"{DateTime.FromOADate(crosshair.X)}\n{crosshair.Y}%");
            }

            @this.UpdateChartCrosshair(
                clear: true,
                present: true,
                crosshairs: [
                    (
                        (crosshair.X, crosshair.Y),
                        (ScottPlot.Plottables.Crosshair custom) =>
                        {
                            custom.MarkerStyle = ScottPlot.MarkerStyle.Default;

                            custom.LineColor = ScottPlot.Colors.Gray.WithAlpha(0.45);

                            custom.MarkerShape = ScottPlot.MarkerShape.OpenCircle;
                            custom.MarkerSize = maxDistance;
                            custom.MarkerFillColor = ScottPlot.Colors.CornflowerBlue.WithAlpha(0.45);

                            if (hitNearest){
                                custom.LineColor = ScottPlot.Colors.CornflowerBlue;

                                custom.MarkerShape = ScottPlot.MarkerShape.FilledCircle;
                                custom.MarkerSize /= 1.6f;

                                //custom.Y += (float)(custom.MarkerSize * @this.mainChart.Plot.LastRender.UnitsPerPxY);
                            }
                        }
                    )
                ]);

            @this.chartCursorValueLabel.Text = $"{DateTime.FromOADate(crosshair.X)} | {crosshair.Y}%";
        }

        public static bool GetNearestRecordCoordinates(this Chart @this, ScottPlot.Coordinates mouseLocation, out (ScottPlot.Plottables.Scatter RecordScatter, ScottPlot.Coordinates Record)? result, float? maxPixelDistance = null)
        {
            var plot = @this.mainChart.Plot;
            var recordScatters = @this.UpdateChart(
                clear: true,
                present: false);

            result = null;

            if (recordScatters is null)
            {
                return false;
            }

            var _result = result ?? new();
            _result.Record = ScottPlot.Coordinates.Infinity;

            var closestDistance = double.PositiveInfinity;
            var set = false;
            foreach (var recordScatter in recordScatters)
            {
                var record = recordScatter.Data.GetNearest(mouseLocation, @this.mainChart.Plot.LastRender).Coordinates;

                var dX = (record.X - mouseLocation.X) * @this.mainChart.Plot.LastRender.PxPerUnitX;
                var dY = (record.Y - mouseLocation.Y) * @this.mainChart.Plot.LastRender.PxPerUnitY;
                var distance = dX * dX + dY * dY;

                if (maxPixelDistance.HasValue)
                {
                    var pixelDistance = plot.GetPixel(record).DistanceFrom(plot.GetPixel(mouseLocation));
                    if (pixelDistance > maxPixelDistance)
                        continue;
                }

                if (distance <= closestDistance)
                {
                    _result.Record = record;
                    _result.RecordScatter = recordScatter;

                    closestDistance = distance;
                    set = true;
                }
            }

            if (set)
            {
                result = _result;
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
    }
}
