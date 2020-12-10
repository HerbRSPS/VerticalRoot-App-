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

            var poep = word.GetConnection();
            var list = poep.Query<int>("select * from tbl_datadetails").ToList();
            var sensorName = new List<showTable>();
            var value = new List<showTable>();
            var status = new List<showTable>();
            //get user id,


            for (int i = 0; i < list.Count; ++i)
            {
                sensorName.Add(new showTable { ID = i, Name = list[i] });
            }

            for (int i = 0; i < list.Count; ++i)
            {
                value.Add(new showTable { ID = i, Name = list[i] });
            }

            for (int i = 0; i < list.Count; ++i)
            {
                status.Add(new showTable { ID = i, Name = list[i] });
            }

            TitleListView.ItemsSource = sensorName;
            ValueListView.ItemsSource = value;
            StatusListView.ItemsSource = status;
            
        }

        public class showTable
        {
            public int ID { get; set; }
            public int Name { get; set; }
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
