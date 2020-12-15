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
        public CropDetail()
        {
            InitializeComponent();

            DB word = new DB();
            word.openConnection();

            var sql = word.GetConnection();
            var value_celsius = sql.Query<int>("select celsius from tbl_datadetails WHERE plant_id = 1").ToList();
            var value_ldr = sql.Query<int>("select ldr from tbl_datadetails WHERE plant_id = 1").ToList();
            var value_humidity = sql.Query<int>("select humidity from tbl_datadetails WHERE plant_id = 1").ToList();
            var value_moisture = sql.Query<int>("select moisture from tbl_datadetails WHERE plant_id = 1").ToList();
            var value_water_flow = sql.Query<int>("select water_use from tbl_datadetails WHERE plant_id = 1").ToList();
            var value_list = new List<showTable>();
            //get user id,


            for (int i = 0; i < value_celsius.Count; ++i)
            {
                string temperatureNaming = $"{value_celsius[i]} °";
                string ldrNaming = $"{value_ldr[i]} LX";
                string humidityNaming = $"{value_humidity[i]} %";
                string moistureNaming = $"{value_moisture[i]} %";
                string water_useNaming = $"{value_water_flow[i]} L/H";

                value_list.Add(new showTable { Name = temperatureNaming });
                value_list.Add(new showTable { Name = ldrNaming });
                value_list.Add(new showTable { Name = humidityNaming });
                value_list.Add(new showTable { Name = moistureNaming });
                value_list.Add(new showTable { Name = water_useNaming });

                int temperatureStatus = value_celsius[0];
                int ldrStatus = value_ldr[0];
                int humidityStatus = value_humidity[0];
                int moistureStatus = value_moisture[0];
                int water_flowStatus = value_water_flow[0];

                if (temperatureStatus < 20)
                {
                    int valueDifference1 = 20 - temperatureStatus;
                    temperatureLabel.Content = "Your temperature is to low! Add " + valueDifference1 + "°";
                    temperatureLabel.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 62, 62, 100));
                    
                    temperatureLabe2.Visibility = Visibility.Hidden;
                    
                    if (temperatureStatus > 20)
                    {
                        int valueDifference2 = temperatureStatus - 20;
                        temperatureLabel.Content = "Your temperature is to low! Add " + valueDifference2 + "°";
                        temperatureLabe2.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    temperatureLabel.Content = "Perfect!";
                    temperatureLabel.Visibility = Visibility.Hidden;
                }

            }

            //for (int i = 0; i < value_ldr.Count; ++i)
            //{
            //}

            ValueListView.ItemsSource = value_list;


        }

        public class showTable
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Text { get; set; }
            public int Pid { get; set; }

            public override string ToString()
            {
                return this.Name.ToString();
            }
        }

        private void Name_Copy8_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Hide();
            DashboardMyCrops MyCrops = new DashboardMyCrops();
            MyCrops.Show();
        }

        private void Name_Copy10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hide();
            MainWindow Login = new MainWindow();
            Login.Show();
        }
    }
}
