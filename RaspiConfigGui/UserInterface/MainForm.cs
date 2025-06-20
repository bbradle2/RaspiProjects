using Microsoft.Extensions.Configuration;
using RaspiDashboard.Controllers;
using RaspiDashboard.Models;
using System.Collections.Concurrent;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace UserInterface
{

    public partial class MainForm : Form
    {
        private readonly RaspiApiService _raspiApiService;
        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;
        private volatile bool _isConnected = false;
        private readonly System.Timers.Timer _pollingTimerUpdate;

        public MainForm(IConfiguration config, IServiceProvider serviceProvider, RaspiApiService raspiApiService)
        {
            InitializeComponent();
            
            _serviceProvider = serviceProvider;
            _config = config;
            _raspiApiService = raspiApiService;
            _pollingTimerUpdate = new System.Timers.Timer();
            _pollingTimerUpdate.Elapsed += PollingTimerUpdate_Elapsed;

            SetStyle(ControlStyles.DoubleBuffer, true);

            InitMainForm().GetAwaiter();

        }

        private async Task InitMainForm()
        {
            try
            {
                Log($"Info : Starting", EventLogEntryType.Information);
                ComboBoxHttpEndPoints.Enabled = false;

                Text = "Loading Endpoints.....";
                (HttpEndPoint[] endpoints, string gitSimVer) = await _raspiApiService.GetEndPointsAsync();

                _isConnected = true;

                await InvokeAsync(() => ComboBoxHttpEndPoints.DataSource = endpoints.Where(s => s.HttpMethod == "PUT").ToList());
                await InvokeAsync(() => ComboBoxHttpEndPoints.ValueMember = "HttpMethod");
                await InvokeAsync(() => ComboBoxHttpEndPoints.DisplayMember = "HttpCallEndPoint");
                await InvokeAsync(() => ComboBoxHttpEndPoints.SelectedItem = null);
                await InvokeAsync(() => ComboBoxHttpEndPoints.Enabled = true);

                _raspiApiService.OnGpioChangeEvent += RaspiApiService_OnGpioChangeEvent;
               
                await _raspiApiService.GetGpioStatusAsync();

                _pollingTimerUpdate.Enabled = false;
                PollingTimerUpdate_Elapsed(null,null);
                _pollingTimerUpdate.Interval = 10000;
                _pollingTimerUpdate.Enabled = true;
                _pollingTimerUpdate.Start();
                               
                Log($"Info : Start Complete ", EventLogEntryType.Information);

            }
            catch (Exception ex)
            {
                Log($"Error : {ex.Message}", EventLogEntryType.Error);
                await InvokeAsync(() => Text = "Could not connect......");
                await InvokeAsync(() => ComboBoxHttpEndPoints.Enabled = false);
                _isConnected = false;
                await InvokeAsync(() => MessageBox.Show(this, ex.Message, "Error"));

                Close();
            }
            finally
            {
                await InvokeAsync(() => Text = "");
            }

            return;
        }

        public static void Log(string message, EventLogEntryType eventType)
        {
            var source = "RaspiDashboard";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "RaspiApiGui");
                return;
            }


            EventLog.WriteEntry(
                            source,
                            message,
                            type: eventType,
                            eventID: 6001);
        }

        private async Task UpdateViewTemperatureInfo(TemperatureInfoObject? temperatureInfoObject)
        {

            if (!IsDisposed && IsHandleCreated && _raspiApiService.IsClosed == 0)
            {
                if (temperatureInfoObject is not null)
                {
                    var temperature = await GroupBoxTemperatureInfo.InvokeAsync(() => GroupBoxTemperatureInfo.Controls.OfType<TextBox>(), CancellationToken.None);
                    var farenh = decimal.Round(temperatureInfoObject.TemperatureFahrenheit, 2);
                    var celsius = decimal.Round(temperatureInfoObject.TemperatureCelcius, 2);
                    await temperature.First().InvokeAsync(() => temperature.First(s => s.Name == nameof(TextBoxTempFarenh)).Text = Convert.ToString(farenh));
                    await temperature.First().InvokeAsync(() => temperature.First(s => s.Name == nameof(TextBoxTempCelcius)).Text = Convert.ToString(celsius));
                    await InvokeAsync(() => Text = temperatureInfoObject.ProductName);

                } 
            }
        }

        //private async Task UpdateSystemInfo(SystemInfoObject? systemInfoObject)
        //{
        //    if (!IsDisposed && IsHandleCreated && _raspiApiController.IsClosed == 0)
        //    {
        //        if (systemInfoObject is not null)
        //        {
       
        //        }
        //    }

        //}

        //private async Task UpdateCpuInfo(CPUInfoObject? cpuInfoObject)
        //{
        //    if (!IsDisposed && IsHandleCreated && _raspiApiController.IsClosed == 0)
        //    {
        //        if (cpuInfoObject is not null)
        //        {
        //            //    var temperature = await TempaturePanel.InvokeAsync(() => TempaturePanel.Controls.OfType<TextBox>(), CancellationToken.None);

        //            //    await temperature.First().InvokeAsync(() => temperature.First(s => s.Name == nameof(TextBoxTempFarenh)).Text = Convert.ToString(temperatureInfoObject.TemperatureFahrenheit));
        //            //    await temperature.First().InvokeAsync(() => temperature.First(s => s.Name == nameof(TextBoxTempCelcius)).Text = Convert.ToString(temperatureInfoObject.TemperatureCelcius));
        //        }
        //    }
        //}

        private async Task UpdateViewMemoryInfo(MemoryInfoObject? memoryInfoObject)
        {

            if (!IsDisposed && IsHandleCreated && _raspiApiService.IsClosed == 0)
            {
                if (memoryInfoObject is not null)
                {
                    BindingSource dataSource = [];
                    dataSource.DataSource = new List<MemoryInfoObject>
                    {
                        memoryInfoObject,
                    };

                    if (dataSource.Count != 1)
                    {
                        var problemText = "Problem Getting Memory Info";
                        await InvokeAsync(() => Text = problemText);
                        Log($"Error : {problemText}", EventLogEntryType.Error);
                        return;
                    }

                    var suffix = "(GiB)";
                    
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.DataSource = dataSource);
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.Columns.Remove("ProductName"));
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.Columns.Remove("Description"));
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.Columns["MemoryTotal"]!.HeaderText = "Memory Total" + suffix);
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.Columns["MemoryFree"]!.HeaderText = "Memory Free" + suffix);
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.Columns["MemoryAvailable"]!.HeaderText = "Memory Available" + suffix);
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.Columns["Cached"]!.HeaderText = "Cached" + suffix);
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.Columns["SwapCached"]!.HeaderText = "Swap Cached" + suffix);
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.Columns["SwapFree"]!.HeaderText = "Swap Free" + suffix);
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.AllowUserToResizeColumns = true);
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.ColumnHeadersDefaultCellStyle.BackColor = Control.DefaultBackColor);
                    //await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.RowsDefaultCellStyle.BackColor = Color.Coral);
                    await DataGridViewMemoryInfo.InvokeAsync(() => DataGridViewMemoryInfo.EnableHeadersVisualStyles = false);

                }
            }
        }

        private async void CmbHttpEndPoints_SelectionChangeCommitted(object? sender, EventArgs? e)
        {
            if (_isConnected)
            {
                await InvokeAsync(() => ComboBoxHttpEndPoints.Enabled = false);
                var httpEndPoint = await InvokeAsync(() => ComboBoxHttpEndPoints.SelectedItem as HttpEndPoint);

                if (httpEndPoint!.HttpMethod!.Equals("PUT"))
                {
                    var response = await _raspiApiService.PutGpioAsync(httpEndPoint!);
                    if (response is ConcurrentQueue<GpioObject> gpioObjects)
                    {

                    }
                }

                await InvokeAsync(() => ComboBoxHttpEndPoints.Enabled = true);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pollingTimerUpdate.Stop();
            _pollingTimerUpdate.Enabled = false;
            Interlocked.Exchange(ref _raspiApiService.IsClosed, 1);
            Log("Info : Stopping Program", EventLogEntryType.Information);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(0 == Interlocked.Exchange(ref _raspiApiService.IsClosed, 1))
            {
                _raspiApiService.OnGpioChangeEvent -= RaspiApiService_OnGpioChangeEvent;
                _raspiApiService.CleanUp();
            }
            
            Log("Info : Stopped Program", EventLogEntryType.Information);
        }

        private async Task UpdateViewGpioLabelAsync(bool? gpioValue, Label labelGpio)
        {
            try
            {
                if (labelGpio is null) return;

                if (!IsDisposed && IsHandleCreated && _raspiApiService.IsClosed == 0)
                {
                    if (gpioValue == true)
                    {
                        await labelGpio.InvokeAsync(() => labelGpio.BackColor = Color.Green);
                        await labelGpio.InvokeAsync(() => labelGpio.Text = "Gpio " + labelGpio.Tag + " High");
                    }
                    else if (gpioValue == false)
                    {
                        await labelGpio.InvokeAsync(() => labelGpio.BackColor = Color.Red);
                        await labelGpio.InvokeAsync(() => labelGpio.Text = "Gpio " + labelGpio.Tag + " Low");
                    }
                    else
                    {
                        await labelGpio.InvokeAsync(() => labelGpio.BackColor = Color.Yellow);
                        await labelGpio.InvokeAsync(() => labelGpio.Text = "Gpio " + labelGpio.Tag + " Not Open");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Error : {ex.Message}", EventLogEntryType.Error);
            }
        }

        private void RaspiApiService_OnGpioChangeEvent(object sender, ConcurrentQueue<GpioObject>? gpioObjectsQueue)
        {
            try
            {
                if (!IsDisposed && IsHandleCreated && _raspiApiService.IsClosed == 0)
                {
                    var options = new ParallelOptions()
                    {
                        MaxDegreeOfParallelism = 12,
                        CancellationToken = CancellationToken.None,
                    };

                    if (gpioObjectsQueue?.Count == 0)
                    {
                        var gpios = _config.GetSection("Gpios").Get<GpioObject[]>()!;
                        foreach (var gp in gpios)
                        {
                            gpioObjectsQueue!.Enqueue(gp);
                        }
                    }

                    Parallel.ForEachAsync(gpioObjectsQueue!, options, async (gpioObject, _) =>
                    {
                        if (GroupBoxGpioStatus is null && !GroupBoxGpioStatus!.IsHandleCreated && !GroupBoxGpioStatus!.IsDisposed) { return; }

                        var labelGpios = await GroupBoxGpioStatus.InvokeAsync(() => GroupBoxGpioStatus.Controls.OfType<Label>(), CancellationToken.None);

                        if (labelGpios != null)
                        {
                            var labelGpio = await GroupBoxGpioStatus.InvokeAsync(() => labelGpios.First(s => Convert.ToInt32(s.Tag) == gpioObject.GpioNumber), CancellationToken.None);

                            if (labelGpio != null && labelGpio.IsHandleCreated && !labelGpio.IsDisposed)
                                labelGpio?.InvokeAsync(async () => await UpdateViewGpioLabelAsync(gpioObject.GpioValue, labelGpio), CancellationToken.None);
                            else
                                return;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Log($"Error : {ex.Message}", EventLogEntryType.Error);
            }
        }

        private async void PollingTimerUpdate_Elapsed(object? sender, System.Timers.ElapsedEventArgs? e)
        {
            HttpEndPoint endPoint = new()
            {
                HttpCallEndPoint = _config["TemperatureInfo"],
                HttpMethod = "GET"
            };

            if (endPoint.HttpCallEndPoint != null)
            {
                var response = await _raspiApiService.GetInfoAsync(endPoint!);
                await UpdateViewTemperatureInfo((TemperatureInfoObject?)response!);

                //endPoint.HttpCallEndPoint = _config["SystemInfo"];              
                //response = await _raspiApiController.GetInfoAsync(endPoint!);
                //UpdateSystemInfo((SystemInfoObject?)response!);

                //endPoint.HttpCallEndPoint = _config["CpuInfo"];
                //response = await _raspiApiController.GetInfoAsync(endPoint!);
                //UpdateCpuInfo((CPUInfoObject?)response!);

                endPoint.HttpCallEndPoint = _config["MemoryInfo"];
                response = await _raspiApiService.GetInfoAsync(endPoint!);
                await UpdateViewMemoryInfo((MemoryInfoObject?)response!);
            }

        }

        private void ContextMenuStripDataGrid_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem?.Text == "Copy" && DataGridViewMemoryInfo?.CurrentCell?.Value != null)
            {
                var val = DataGridViewMemoryInfo?.CurrentCell?.Value?.ToString();

                Thread thread = new(() => Clipboard.SetDataObject(val!, true));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();

            }
        }

        private void DataGridViewMemoryInfo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                DataGridViewMemoryInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ContextMenuStrip = ContextMenuStripDataGrid;
                DataGridViewMemoryInfo.CurrentCell = DataGridViewMemoryInfo.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void DataGridViewMemoryInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Control)
            {
                var val = DataGridViewMemoryInfo?.CurrentCell?.Value?.ToString();

                Thread thread = new(() => Clipboard.SetDataObject(val!, true));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();

            }
        }

        private void DataGridViewMemoryInfo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            DataGridView? dgv = sender as DataGridView;
            SortOrder sort = dgv!.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection;

            if (e.RowIndex == -1 && sort == SortOrder.None)
            {
                string headerText = dgv.Columns[e.ColumnIndex].HeaderText;
                Font headerFont = e.CellStyle!.Font;
                Brush headerBrush = new SolidBrush(e.CellStyle.ForeColor);
                DataGridViewContentAlignment headerAlignment = e.CellStyle.Alignment;

                e.Paint(e.ClipBounds, (DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground));

                SizeF stringSize = TextRenderer.MeasureText(e.Graphics!, headerText, e.CellStyle.Font, e.CellBounds.Size);
                Rectangle p = e.CellBounds;
                switch (headerAlignment)
                {
                    case DataGridViewContentAlignment.TopCenter:
                        p.Offset(
                            e.CellBounds.Width / 2 - (int)(stringSize.Width / 2),
                            0
                        );
                        break;
                    case DataGridViewContentAlignment.TopRight:
                        p.Offset(
                            e.CellBounds.Width - (int)stringSize.Width,
                            0
                        );
                        break;
                    case DataGridViewContentAlignment.MiddleLeft:
                        p.Offset(
                            0,
                            e.CellBounds.Height / 2 - (int)(stringSize.Height / 2)
                        );
                        break;
                    case DataGridViewContentAlignment.MiddleCenter:
                        p.Offset(
                            e.CellBounds.Width / 2 - (int)(stringSize.Width / 2),
                            e.CellBounds.Height / 2 - (int)(stringSize.Height / 2)
                        );
                        break;
                    case DataGridViewContentAlignment.MiddleRight:
                        p.Offset(
                            e.CellBounds.Width - (int)stringSize.Width,
                            e.CellBounds.Height / 2 - (int)(stringSize.Height / 2)
                        );
                        break;
                    case DataGridViewContentAlignment.BottomLeft:
                        p.Offset(
                            0,
                            e.CellBounds.Height - (int)stringSize.Height
                        );
                        break;
                    case DataGridViewContentAlignment.BottomCenter:
                        p.Offset(
                            e.CellBounds.Width / 2 - (int)(stringSize.Width / 2),
                            e.CellBounds.Height - (int)stringSize.Height
                        );
                        break;
                    case DataGridViewContentAlignment.BottomRight:
                        p.Offset(
                            e.CellBounds.Width - (int)stringSize.Width,
                            e.CellBounds.Height - (int)stringSize.Height
                        );
                        break;
                    default:
                        p.Offset(
                            0,
                            0
                        );
                        break;
                }

                e.Graphics!.DrawString(headerText, headerFont, headerBrush, new PointF(p.X, p.Y));
                e.Handled = true;
            }
        }
    }
}
