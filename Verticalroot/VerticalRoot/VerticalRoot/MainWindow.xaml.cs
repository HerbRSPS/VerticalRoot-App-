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
        //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=mysql");
        public MainWindow()
        {

            this.Title = "Login";
            InitializeComponent();
            databaseconnection egg = new databaseconnection();
            egg.Show();

            plantdetail p = new plantdetail();
            p.Show();

            Dashboard dash = new Dashboard();
            //dash.Show();

            CropDetail cropdetail = new CropDetail();
            cropdetail.Show();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;


            //tbUsername.Text = "Enter text here...";

            //tbUsername.GotFocus += GotFocus.EventHandle(RemoveText);
            //tbUsername.LostFocus += LostFocus.EventHandle(AddText);
        }
        //public void RemoveText(object sender, EventArgs e)
        //{
        //    if (tbUsername.Text == "Enter text here...")
        //    {
        //        tbUsername.Text = "";
        //    }
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            //string username = tbUsername.Text;
            //string password = tbPassword.Text;

            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE name = @usn and password = @pass", db.GetConnection());

            //command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            //command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Close();
                Dashboard frm2 = new Dashboard();
                frm2.Show();
            }
            else
            {
                MessageBox.Show("Verkeerde Inloggegevens");
            }

        }

        private void SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
