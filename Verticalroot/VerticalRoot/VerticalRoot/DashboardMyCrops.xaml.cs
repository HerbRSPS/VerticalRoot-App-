using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for DashboardMyCrops.xaml
    /// </summary>
    public partial class DashboardMyCrops : Window
    {
        public static int id { get; set; }
        private CropList myList = new CropList();

        public DashboardMyCrops()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            myList.PlantNameQuery();
            PlantNameListView.ItemsSource = myList.plantNameList;
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

        /// <summary>
        /// Creating a ListViewItem from sender by casting it to ListViewItem, getting the id and passing it to the cropDetail instance.
        /// </summary>
        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            Hide();
            ListViewItem click = (ListViewItem)sender;
            id = myList.ReturnPlantId(click.Content.ToString());
            CropDetail cropDetail = new CropDetail(id);
            cropDetail.Show();
            plantdetail pd = new plantdetail();
            pd.Show();
        }
    }
}
