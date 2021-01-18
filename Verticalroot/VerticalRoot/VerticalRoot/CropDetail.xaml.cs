using System.Windows;
using System.Windows.Input;

namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for CropDetail.xaml
    /// </summary>
    public partial class CropDetail : Window
    {
        CropList cropList = new CropList();
        public CropDetail(int id)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            cropList.SensorQuery();
            ValueListView.ItemsSource = cropList.GetValuesByPlantId(id);
            cropList.StatusChecker(id, StatusType.Temperature, temperatureLabel);
            cropList.StatusChecker(id, StatusType.LDR, lightLabel);
            cropList.StatusChecker(id, StatusType.Humidity, humidityLabel);
            cropList.StatusChecker(id, StatusType.Moisture, soilMoistureLabel);
            cropList.StatusChecker(id, StatusType.WaterFlow, waterFlowLabel);
            ValueListView.Items.Refresh();
        }

        private void Name_Dashboard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Hide();
            Dashboard dash = new Dashboard();
            dash.Show();
        }
        private void Name_Logout_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hide();
            MainWindow login = new MainWindow();
            login.Show();
        }
    }
}
