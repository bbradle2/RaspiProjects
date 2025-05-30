using Microsoft.Extensions.Configuration;
using Models;
using RaspiDashboard.Controllers;
using RaspiDashboard.Interfaces;
using RaspiDashboard.Models;
using System.Collections.Concurrent;
using System.Diagnostics;


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
                CmbHttpEndPoints.Enabled = false;

                Text = "Loading Endpoints.....";
                (HttpEndPoint[] endpoints, string gitSimVer) = await _raspiApiController.GetEndPointsAsync();
                
                _isConnected = true;
                               
                CmbHttpEndPoints.DataSource = endpoints;
                CmbHttpEndPoints.ValueMember = "HttpMethod";
                CmbHttpEndPoints.DisplayMember = "HttpCallEndPoint";
                CmbHttpEndPoints.SelectedItem = null;
                CmbHttpEndPoints.Enabled = true;

                _raspiApiController.OnGpioEvent += RaspiApiController_OnGpioEvent;
                _ = _raspiApiController.GetGpioStatusAsync();
            }
            catch (Exception ex)
            {
                Text = "Could not connect......";
                CmbHttpEndPoints.Enabled = false;
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

        private async void CmbHttpEndPoints_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                CmbHttpEndPoints.Enabled = false;
                var httpEndPoint = CmbHttpEndPoints.SelectedItem as HttpEndPoint;

                if (httpEndPoint!.HttpMethod!.Equals("GET"))  
                {
                    var response = await _raspiApiController.GetInfoAsync(httpEndPoint!);
               

                    if (response is TemperatureInfoObject temperatureInfoObject)
                    {

                    }

                    if (response is CPUInfoObject cpuInfoObject)
                    {

                    }

                    if (response is MemoryInfoObject memoryInfoObject)
                    {

                    }

                    if (response is SystemInfoObject systemInfoObject)
                    {

                    }
                }

                if (httpEndPoint!.HttpMethod.Equals("PUT"))
                {
                    var response = await _raspiApiController.PutGpioAsync(httpEndPoint!);
                    if (response is ConcurrentQueue<GpioObject> gpioObjects)
                    {
                        
                    }
                }

                CmbHttpEndPoints.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        { 

            Interlocked.Exchange(ref _raspiApiController.IsClosed, 1);

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(0 == Interlocked.Exchange(ref _raspiApiController.IsClosed, 1)) 
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
                        await radioButton.InvokeAsync(() => radioButton.Text = "On");
                    }
                    else if (gpioValue == false)
                    {
                        await radioButton.InvokeAsync(() => radioButton.BackColor = Color.Red);
                        await radioButton.InvokeAsync(() => radioButton.Text = "Off");
                    }
                    else
                    {
                        await radioButton.InvokeAsync(() => radioButton.BackColor = Color.Yellow);
                        await radioButton.InvokeAsync(() => radioButton.Text = "");
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
                        if (LedPanel is null && !LedPanel!.IsHandleCreated && !LedPanel!.IsDisposed) { return; }          

                        var radioButtons = await LedPanel.InvokeAsync(() => LedPanel.Controls.OfType<RadioButton>(), CancellationToken.None);

                        if (radioButtons != null)
                        {
                            var radioButton = await LedPanel.InvokeAsync(() => radioButtons.First(s => Convert.ToInt32(s.Tag) == gpioObject.GpioNumber), CancellationToken.None);
                            
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
    }
}
