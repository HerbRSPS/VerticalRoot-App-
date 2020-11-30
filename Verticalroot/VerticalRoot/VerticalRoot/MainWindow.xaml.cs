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

namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            databaseconnection egg = new databaseconnection();
            egg.Show();

            Dashboard dash = new Dashboard();
            dash.Show();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Fontys\Proftaak\GroepsProjectArduino\Git Kraken\C#\VerticalRoot-App-\Verticalroot\VerticalRoot\VerticalRoot\Database voor inlog\inlogDB.mdf;Integrated Security=True;Connect Timeout=30");
            String query = "Select * from tbl_login Where username = '" + tbUsername.Text.Trim() + "' and password = '" + tbPassword.Text.Trim()+"'";
                    //query = "SELECT * From TableName WHERE Title = @Title";
                    //command.Parameters.Add("@Title", SqlDbType.VarChar).Value = someone;
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            System.Data.DataTable dtbl = new System.Data.DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                frmDashboard objfrmDashboard = new frmDashboard();
                this.Hide();
                objfrmDashboard.Show();
            }
            else
            {
                MessageBox.Show("Foutieve inloggegevens");
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
