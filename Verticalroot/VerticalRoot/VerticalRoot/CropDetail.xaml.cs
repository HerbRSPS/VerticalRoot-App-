using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Dapper;

namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for CropDetail.xaml
    /// </summary>
    public partial class CropDetail : Window
    {
        CropList cropList = new CropList();
        public CropDetail()
        {
            int id = 1;
            InitializeComponent();
            cropList.SensorQuery();
            ValueListView.ItemsSource = cropList.getValuesByPlantId(id);
            cropList.StatusChecker(id, StatusType.Temperature, temperatureLabel);
            cropList.StatusChecker(id, StatusType.LDR, lightLabel);
            cropList.StatusChecker(id, StatusType.Humidity, humidityLabel);
            cropList.StatusChecker(id, StatusType.Moisture, soilMoistureLabel);
            cropList.StatusChecker(id, StatusType.WaterFlow, waterFlowLabel);
            ValueListView.Items.Refresh();
        }
        public static object Current { get; internal set; }
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
