using Microsoft.Extensions.Configuration;
using Models;
using RaspiDashboard.Controllers;
using RaspiDashboard.Interfaces;
using RaspiDashboard.Models;
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;


namespace UserInterface
{

    public partial class MainForm : Form
    {

        private readonly RaspiApiController _raspiApiController;
        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;
        private volatile bool _isConnected = false;

        public MainForm(IConfiguration config, IServiceProvider serviceProvider, RaspiApiController raspiApiController)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _config = config;
            _raspiApiController = raspiApiController;

            InitMainForm().GetAwaiter();

        }

        private async Task InitMainForm()
        {
            try
            {
                ComboBoxHttpEndPoints.Enabled = false;

                Text = "Loading Endpoints.....";
                (HttpEndPoint[] endpoints, string gitSimVer) = await _raspiApiController.GetEndPointsAsync();

                _isConnected = true;

                ComboBoxHttpEndPoints.DataSource = endpoints.Where(s => s.HttpMethod == "PUT").ToList();
                ComboBoxHttpEndPoints.ValueMember = "HttpMethod";
                ComboBoxHttpEndPoints.DisplayMember = "HttpCallEndPoint";
                ComboBoxHttpEndPoints.SelectedItem = null;
                ComboBoxHttpEndPoints.Enabled = true;

                _raspiApiController.OnGpioEvent += RaspiApiController_OnGpioEvent;
                _ = _raspiApiController.GetGpioStatusAsync();

                TimeUpdateForm.Interval = 1;
                TimeUpdateForm.Enabled = true;
                TimeUpdateForm.Start();
                await Task.Delay(10);
                TimeUpdateForm.Stop();

                TimeUpdateForm.Enabled = false;
                TimeUpdateForm.Interval = 4000;
                TimeUpdateForm.Enabled = true;
                TimeUpdateForm.Start();

            }
            catch (Exception ex)
            {
                Text = "Could not connect......";
                ComboBoxHttpEndPoints.Enabled = false;
                _isConnected = false;
                MessageBox.Show(this, ex.Message, "Error");
                Close();
            }
            finally
            {
                Text = "";
            }

            return;
        }

        private async Task UpdateTemperatureInfo(TemperatureInfoObject? temperatureInfoObject)
        {
            if (!IsDisposed && IsHandleCreated && _raspiApiController.IsClosed == 0)
            {
                if (temperatureInfoObject is not null)
                {
                    var temperature = await GroupBoxTemperatureInfo.InvokeAsync(() => GroupBoxTemperatureInfo.Controls.OfType<TextBox>(), CancellationToken.None);
                    var farenh = Double.Round(temperatureInfoObject.TemperatureFahrenheit, 2);
                    var celsius = Double.Round(temperatureInfoObject.TemperatureCelcius, 2);
                    await temperature.First().InvokeAsync(() => temperature.First(s => s.Name == nameof(TextBoxTempFarenh)).Text = Convert.ToString(farenh));
                    await temperature.First().InvokeAsync(() => temperature.First(s => s.Name == nameof(TextBoxTempCelcius)).Text = Convert.ToString(celsius));
                }
            }
        }

        //private async Task UpdateSystemInfo(SystemInfoObject? systemInfoObject)
        //{
        //    if (!IsDisposed && IsHandleCreated && _raspiApiController.IsClosed == 0)
        //    {
        //        if (systemInfoObject is not null)
        //        {
        //            //    var temperature = await TempaturePanel.InvokeAsync(() => TempaturePanel.Controls.OfType<TextBox>(), CancellationToken.None);

        //            //    await temperature.First().InvokeAsync(() => temperature.First(s => s.Name == nameof(TextBoxTempFarenh)).Text = Convert.ToString(temperatureInfoObject.TemperatureFahrenheit));
        //            //    await temperature.First().InvokeAsync(() => temperature.First(s => s.Name == nameof(TextBoxTempCelcius)).Text = Convert.ToString(temperatureInfoObject.TemperatureCelcius));
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

        private async Task UpdateMemoryInfo(MemoryInfoObject? memoryInfoObject)
        {

            if (!IsDisposed && IsHandleCreated && _raspiApiController.IsClosed == 0)
            {
                if (memoryInfoObject is not null)
                {
                    BindingSource dataSource = [];
                    dataSource.DataSource = new List<MemoryInfoObject>
                    {
                        memoryInfoObject,
                    };

                    DataGridViewMemoryInfo.DataSource = dataSource;
                    DataGridViewMemoryInfo.Columns.Remove("ProductName");
                    DataGridViewMemoryInfo.Columns.Remove("Description");
                    DataGridViewMemoryInfo.Columns["MemoryTotal"]!.HeaderText = "Memory Total";
                    DataGridViewMemoryInfo.Columns["MemoryFree"]!.HeaderText = "Memory Free";
                    DataGridViewMemoryInfo.Columns["MemoryAvailable"]!.HeaderText = "Memory Available";
                    DataGridViewMemoryInfo.Columns["Cached"]!.HeaderText = "Cached";
                    DataGridViewMemoryInfo.Columns["SwapCached"]!.HeaderText = "Swap Cached";
                    DataGridViewMemoryInfo.Columns["SwapFree"]!.HeaderText = "Swap Free";
                    DataGridViewMemoryInfo.AllowUserToResizeColumns = true;
                    DataGridViewMemoryInfo.ColumnHeadersDefaultCellStyle.BackColor = Control.DefaultBackColor;
                    DataGridViewMemoryInfo.RowsDefaultCellStyle.BackColor = Control.DefaultBackColor;
                    DataGridViewMemoryInfo.EnableHeadersVisualStyles = false;
                }
            }

            await Task.FromResult(0);
        }

        private async void CmbHttpEndPoints_SelectionChangeCommitted(object? sender, EventArgs? e)
        {
            if (_isConnected)
            {
                ComboBoxHttpEndPoints.Enabled = false;
                var httpEndPoint = ComboBoxHttpEndPoints.SelectedItem as HttpEndPoint;

                if (httpEndPoint!.HttpMethod!.Equals("PUT"))
                {
                    var response = await _raspiApiController.PutGpioAsync(httpEndPoint!);
                    if (response is ConcurrentQueue<GpioObject> gpioObjects)
                    {

                    }
                }

                ComboBoxHttpEndPoints.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimeUpdateForm.Stop();
            TimeUpdateForm.Enabled = false;
            Interlocked.Exchange(ref _raspiApiController.IsClosed, 1);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (0 == Interlocked.Exchange(ref _raspiApiController.IsClosed, 1))
            {
                _raspiApiController.OnGpioEvent -= RaspiApiController_OnGpioEvent;
                _raspiApiController.CleanUp();
            }
        }

        private async Task UpdateGpioRadioButtonAsync(bool? gpioValue, RadioButton radioButton)
        {
            try
            {
                if (radioButton is null) return;

                if (!IsDisposed && IsHandleCreated && _raspiApiController.IsClosed == 0)
                {
                    if (gpioValue == true)
                    {
                        await radioButton.InvokeAsync(() => radioButton.BackColor = Color.Green);
                        await radioButton.InvokeAsync(() => radioButton.Text = "Gpio " + radioButton.Tag + " On");
                    }
                    else if (gpioValue == false)
                    {
                        await radioButton.InvokeAsync(() => radioButton.BackColor = Color.Red);
                        await radioButton.InvokeAsync(() => radioButton.Text = "Gpio " + radioButton.Tag + " Off");
                    }
                    else
                    {
                        await radioButton.InvokeAsync(() => radioButton.BackColor = Color.Yellow);
                        await radioButton.InvokeAsync(() => radioButton.Text = "Gpio " + radioButton.Tag + " NOP");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void RaspiApiController_OnGpioEvent(object sender, ConcurrentQueue<GpioObject>? gpioObjectsQueue)
        {
            try
            {
                if (!IsDisposed && IsHandleCreated && _raspiApiController.IsClosed == 0)
                {
                    var options = new ParallelOptions()
                    {
                        MaxDegreeOfParallelism = 12,
                        CancellationToken = CancellationToken.None,
                    };

                    Parallel.ForEachAsync(gpioObjectsQueue!, options, async (gpioObject, _) =>
                    {
                        if (GroupBoxLed is null && !GroupBoxLed!.IsHandleCreated && !GroupBoxLed!.IsDisposed) { return; }

                        var radioButtons = await GroupBoxLed.InvokeAsync(() => GroupBoxLed.Controls.OfType<RadioButton>(), CancellationToken.None);

                        if (radioButtons != null)
                        {
                            var radioButton = await GroupBoxLed.InvokeAsync(() => radioButtons.First(s => Convert.ToInt32(s.Tag) == gpioObject.GpioNumber), CancellationToken.None);

                            if (radioButton != null && radioButton.IsHandleCreated && !radioButton.IsDisposed)
                                radioButton?.InvokeAsync(async () => await UpdateGpioRadioButtonAsync(gpioObject.GpioValue, radioButton), CancellationToken.None);
                            else
                                return;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void TimerTemperature_Tick(object sender, EventArgs e)
        {
            HttpEndPoint endPoint = new()
            {
                HttpCallEndPoint = _config["TemperatureInfo"],
                HttpMethod = "GET"
            };

            if (endPoint.HttpCallEndPoint != null)
            {
                var response = await _raspiApiController.GetInfoAsync(endPoint!);
                await UpdateTemperatureInfo((TemperatureInfoObject?)response!);

                //endPoint.HttpCallEndPoint = _config["SystemInfo"];              
                //response = await _raspiApiController.GetInfoAsync(endPoint!);
                //UpdateSystemInfo((SystemInfoObject?)response!);

                //endPoint.HttpCallEndPoint = _config["CpuInfo"];
                //response = await _raspiApiController.GetInfoAsync(endPoint!);
                //UpdateCpuInfo((CPUInfoObject?)response!);

                endPoint.HttpCallEndPoint = _config["MemoryInfo"];
                response = await _raspiApiController.GetInfoAsync(endPoint!);
                await UpdateMemoryInfo((MemoryInfoObject?)response!);
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
                thread.Join(); //Wait for the thread to end

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
                thread.Join(); //Wait for the thread to end

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
