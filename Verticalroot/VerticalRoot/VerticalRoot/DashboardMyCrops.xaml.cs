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

namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for DashboardMyCrops.xaml
    /// </summary>
    public partial class DashboardMyCrops : Window
    {
        public DashboardMyCrops()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            CropList plantName = new CropList();
            plantName.plantNameQuery();
            PlantNameListView.ItemsSource = plantName.plantNameList;
            PlantNameListView.Items.Refresh();
        }

        private void Name_Dashboard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Hide();
            Dashboard dash = new Dashboard();
            dash.Show();
        }

        private void Name_Logout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Hide();
            MainWindow Login = new MainWindow();
            Login.Show();
        }

        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            Hide();
            CropDetail cropDetail = new CropDetail();
            //CropList cropList = new CropList();
            //cropList.getByPlantId();
            ////Crop crop = new Crop();
            //int pid = crop.plantId;


            cropDetail.Show();
        }
    }
}
