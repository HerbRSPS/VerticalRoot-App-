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
    public partial class databaseconnection : Window
    {
        public databaseconnection()
        {
            InitializeComponent();
            try
            {
                string connectionString = "Server=studmysql01.fhict.local;Uid=dbi467376;Database=dbi467376;Pwd=password123;"; //database server name and mysql port and username and password
                string mysql = "SELECT * FROM tbl_datadetails;";

                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand(mysql, conn);

                conn.Open();

                //MySqlDataAdapter dtb = new MySqlDataAdapter();
                // dtb.SelectCommand = command;

                //datatable dt = new datatable();
                //dt.load(command.executereader());
                


                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dtt = new DataTable();
                da.Fill(dtt);
                DataGrid dg = new DataGrid();
                dtGrid.ItemsSource = dtt.AsDataView();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 
    }
}