using Microsoft.Extensions.Configuration;
using Models;
using RaspiDashboard.Interfaces;

namespace UserInterface
{

    public partial class MainForm : Form
    {

        private readonly IRaspiApiController _raspiApiController;
        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;
        private volatile bool _isConnected = false;
        public volatile bool IsClosed = false;

        public MainForm(IConfiguration config, IServiceProvider serviceProvider, IRaspiApiController raspiApiController)
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
                var httpEndPointArray = await _raspiApiController.GetEndPointsAsync();

                CmbHttpEndPoints.DataSource = httpEndPointArray;
                CmbHttpEndPoints.ValueMember = "HttpMethod";
                CmbHttpEndPoints.DisplayMember = "HttpCallEndPoint";
                //CmbHttpEndPoints.SelectedItem = httpEndPointArray!
                //    .Where(s => s.HttpCallEndPoint == _config["GpioHigh"])
                //    .First();

                CmbHttpEndPoints.SelectedItem = null;
                var selectedItem = CmbHttpEndPoints.SelectedItem as HttpEndPoint;
                _ = _raspiApiController.RunWebSocketAsync();
                _isConnected = true;

                CmbHttpEndPoints.Enabled = true;
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsClosed = true;
        }

        private async void cmbHttpEndPoints_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                CmbHttpEndPoints.Enabled = false;
                var httpEndPoint = CmbHttpEndPoints.SelectedItem as HttpEndPoint;
                var response = await _raspiApiController.CallApiAsync(httpEndPoint!);

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

                if (response is GpioObject[] gpioObjects)
                {

                }

                CmbHttpEndPoints.Enabled = true;
            }
        }
         
        public async Task UpdateGpiosEventHandler(IList<GpioObject> gpioObjectList)
        {
            if (!IsDisposed && IsHandleCreated && !IsClosed)
            { 
                foreach (GpioObject gpioObject in gpioObjectList)
                {
                    await InvokeAsync(() => TextGpioStatus.AppendText($"Gpio Number={gpioObject.GpioNumber}:Gpio Value={gpioObject.GpioValue},"));
                }

                if(gpioObjectList.Count > 0) await InvokeAsync(() => TextGpioStatus.AppendText(Environment.NewLine)); 
               
                if (TextGpioStatus.Text == "") await InvokeAsync(() => TextGpioStatus.AppendText("No Gpios are Open" + Environment.NewLine));

            }
        }
    }
}
