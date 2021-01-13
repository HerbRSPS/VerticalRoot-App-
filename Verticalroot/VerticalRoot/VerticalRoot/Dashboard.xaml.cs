using System.Windows;
using System.Windows.Input;

namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void MyCrops_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Hide();
            DashboardMyCrops dash = new DashboardMyCrops();
            dash.Show();
        }
        private void Logout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Hide();
            MainWindow Login = new MainWindow();
            Login.Show();
        }
    }
}
