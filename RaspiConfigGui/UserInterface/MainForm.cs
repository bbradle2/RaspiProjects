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
        private bool _isConnected = false;
        public bool IsClosed = false;

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
                CmbHttpEndPoints.SelectedItem = httpEndPointArray!
                    .Where(s => s.HttpCallEndPoint == _config["GpioHigh"])
                    .First();

                var selectedItem = CmbHttpEndPoints.SelectedItem as HttpEndPoint;
                await _raspiApiController.CallApiAsync(selectedItem!);
                _ = _raspiApiController.DoWebSocketAsync();
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
            if (_isConnected)
            {
                _raspiApiController.CleanUp();
            }
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

        internal void UpdateGpiosCallback(List<GpioObject> gpioObjectList)
        {
            
        }
    }
}
