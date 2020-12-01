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
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for databaseconnection.xaml
    /// </summary>
    public partial class databaseconnection : Window
    {
        public databaseconnection()
        {
            InitializeComponent();
            try
            {
                //online connection database
                string connectionString = "Server=studmysql01.fhict.local;Uid=dbi467376;Database=dbi467376;Pwd=password123;"; //database server name and mysql port and username and password

                // Local connection database
                //string connectionString = "Server=localhost;Uid=root;Database=vertical_root;Password=;"; //database server name and mysql port and username and password

                string mysql = "SELECT * FROM tbl_datadetails;";

                //MySqlDataAdapter dtb = new MySqlDataAdapter();
                //dtb.SelectCommand = command;
                DataTable dt = new DataTable();
                //dt.Load(command.ExecuteReader());
                
                //dtb.Fill(dt);

              
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.i467376.hera.fhict.nl/public/login");
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
