using Timer = System.Windows.Forms.Timer;

namespace EnergyTotal.WinForm.Forms;

public partial class Main : Form
{
    internal bool shouldClose = false;
    internal bool isMonitoring = default;
    internal TimeSpan monitorInterval = default;

    internal readonly Timer monitorTimer;

    internal readonly Dialogs.About aboutForm;
    internal readonly Dialogs.Chart chartForm;

    internal readonly string intervalCurrentValueTextFormat = "Current: {0}";

    public bool IsMonitoring
    {
        get => isMonitoring;

        set
        {
            isMonitoring = value;

            if (isMonitoring) ResetMonitorTimer();
            else StopMonitorTimer();
        }
    }
    public TimeSpan MonitorInterval
    {
        get => monitorInterval;

        set
        {
            monitorInterval = value;
            intervalCurrentValueToolStripMenuItem.Text = string.Format(intervalCurrentValueTextFormat, monitorInterval);

            if (isMonitoring)
                ResetMonitorTimer();
        }
    }

    public Main()
    {
        InitializeComponent();

        MonitorInterval = TimeSpan.FromSeconds(5);

        monitorTimer = new();
        monitorTimer.Tick += OnMonitorTimerTick;

        aboutForm = new();
        aboutForm.FormClosing += OnAboutFormClosing;
        chartForm = new();
        chartForm.Activated += OnChartFormActivated;
        chartForm.FormClosing += OnChartFormClosing;

        // Auto-Start Monitoring if checked
        IsMonitoring = enabledToolStripMenuItem.Checked;
    }

    /// <summary>
    /// Display info to user view. (New line)
    /// </summary>
    /// <param name="log"></param>
    public void UserLog(string log)
    {
        LogTextBox.AppendText($"[{DateTime.Now}] {log}{Environment.NewLine}");
    }

    /// <summary>
    /// Reset and start monitor timer.
    /// </summary>
    internal void ResetMonitorTimer()
    {
        monitorTimer.Stop();
        monitorTimer.Interval = (int)monitorInterval.TotalMilliseconds;
        monitorTimer.Start();

        UserLog($"Monitor Resetting, Interval: {monitorInterval}.");
        UserLog("Monitor Reset. (Running)");
    }

    /// <summary>
    /// Stop monitor timer.
    /// </summary>
    internal void StopMonitorTimer()
    {
        monitorTimer.Stop();

        UserLog("Monitor Stopped.");
    }

    #region Private Events

    private void OnMonitorTimerTick(object? sender, EventArgs e)
    {
        var powerInfo = SystemInformation.PowerStatus;

        chartForm.AddRecords(true, new Primitives.EnergyRecord(powerInfo));
    }

    private void OnEnabledCheckedChanged(object sender, EventArgs e)
    {
        IsMonitoring = enabledToolStripMenuItem.Checked;
    }

    private void OnViewChartClick(object sender, EventArgs e)
    {
        chartForm.Show();
    }

    private void OnAboutClick(object sender, EventArgs e)
    {
        aboutForm.ShowDialog();
    }

    private void OnMainClosing(object sender, FormClosingEventArgs e)
    {
        shouldClose = true;

        aboutForm.Close();
        aboutForm.Dispose();
        chartForm.Close();
        chartForm.Dispose();
    }

    private void OnChartFormClosing(object? sender, FormClosingEventArgs e)
    {
        if (sender is not Dialogs.Chart chartForm || shouldClose)
        {
            e.Cancel = false;
            return;
        }

        chartForm.Hide();
        chartForm.IsPaused = true;
        e.Cancel = true;
    }

    private void OnChartFormActivated(object? sender, EventArgs e)
    {
        chartForm.IsPaused = false;
    }

    private void OnAboutFormClosing(object? sender, FormClosingEventArgs e)
    {
        if (sender is not Dialogs.About aboutForm || shouldClose)
        {
            e.Cancel = false;
            return;
        }

        e.Cancel = true;
        aboutForm.Hide();
    }

    private void OnSetNewMonitorIntervalClick(object sender, EventArgs e)
    {
        new Dialogs.Input(
            content: "Enter the interval: ",
            title: "Set Monitor Interval",
            defaultInput: monitorInterval.ToString(),
            confirmCallback: (_, input) =>
            {
                if (!TimeSpan.TryParse(input, out TimeSpan parse))
                {
                    MessageBox.Show($"Error parsing \"{input}\", please check and try again.", "Setting New Interval");
                    return false;
                }

                MonitorInterval = parse;
                return true;
            },
            cancelCallback: (_, input) => { return true; })
        .ShowDialog();
    }

    #endregion
}
