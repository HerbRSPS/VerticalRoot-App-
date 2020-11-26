﻿using System;
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
                string connectionString = "datasource=localhost;database=vertical_root;port=3306;username=root;password="; //database server name and mysql port and username and password
                string mysql = "SELECT * FROM tbl_datadetails;";

                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand(mysql, conn);

                conn.Open();

                //MySqlDataAdapter dtb = new MySqlDataAdapter();
               // dtb.SelectCommand = command;

                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                conn.Close();

                dtGrid.DataContext = dt;
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
    }
}
