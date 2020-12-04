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
    public partial class MainWindow: Window
    {
        //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=mysql");
        //dit staat ook in de class.
        public MainWindow()
        {
            this.Title = "Login";
            InitializeComponent();
            databaseconnection egg = new databaseconnection();
            //egg.Show();

            plantdetail p = new plantdetail();
            p.Show();

            Dashboard dash = new Dashboard();
            //dash.Show();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            DB db = new DB();
            db.openConnection();
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string pwd = "$2y$10$TzCGWCoS4VY69rFm54g00e1E8A8GGwB6MVlv3SGK7u4K.i7Oc53QS";

            System.Data.DataTable table = new System.Data.DataTable(); // de DataTable hoort zonder de Systen.Data maar dan werkt het niet dus doe ik het even zo.

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            ///////////////////////////////////////////////////////////////////////////////
            // Create sha256 hash
            



            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE name = @usn and password = @pass", db.GetConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            
            adapter.SelectCommand = command;

            adapter.Fill(table);
           
            if (table.Rows.Count > 0)
            {
                //MessageBox.Show("YES");
                this.Close();

                Dashboard frm2 = new Dashboard();

                frm2.Show();
            }
            else
            {
                MessageBox.Show("Verkeerde Inloggegevens");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
       
      
    }
}
