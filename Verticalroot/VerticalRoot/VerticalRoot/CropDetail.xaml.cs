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

            var list = conn.Query<int>("select * from tbl_datadetails").ToList();
            var users = new List<showTable>();
            //get user id,
            
            for (int i = 0; i < list.Count; ++i)
            {
                users.Add(new showTable { ID = i, Name = list[i] });
            }
            myListView.ItemsSource = users;
        }

        public class showTable
        {
            public int ID { get; set; }
            public int Name { get; set; }
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
