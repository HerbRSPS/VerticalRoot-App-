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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.IO;
using System.Security.Cryptography;

namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int userId { get; set; }

        public MainWindow()
        {
            //databaseconnection d = new databaseconnection();
            //d.Show();
            this.Title = "Login";
            InitializeComponent();

            //OPENING FORMS FOR TESTING
            //databaseconnection egg = new databaseconnection();
            //egg.Show();

            //plantdetail p = new plantdetail();
            //p.Show();

            //DashboardMyCrops huts = new DashboardMyCrops();
            //huts.Show();
            

            //Dashboard dash = new Dashboard();
            //dash.Show();

            //CropDetail cropdetail = new CropDetail();
            //cropdetail.Show();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername2.Text;
            string password = tbPassword2.Text;
            Login login = new Login();
            int isLoggedIn = login.checkLogin(username, password);
            userId = isLoggedIn;
           
            //if login is succesfull
            if (isLoggedIn > 0)
            {
                MainWindow mnwindow = new MainWindow();
                mnwindow.Close();
                Dashboard dash = new Dashboard();
                dash.Show();
            }
            //if login is onsuccesfull
            if (isLoggedIn == 0)
            {
                MessageBox.Show("Login unsuccessfull, please try again");
            }
        }
        private void SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
