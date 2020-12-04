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
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
        }




//        DB db = new DB();
//        db.openConnection();
//            string username = tbUsername.Text;
//        string password = tbPassword.Text;

//        System.Data.DataTable table = new System.Data.DataTable(); // de DataTable hoort zonder de Systen.Data maar dan werkt het niet dus doe ik het even zo.

//        MySqlDataAdapter adapter = new MySqlDataAdapter();
//            try
//            {
//                // Create Aes that generates a new key and initialization vector (IV).    
//                // Same key must be used in encryption and decryption    
//                using (AesManaged aes = new AesManaged())
//                {
//                    byte[] bytes = Encoding.ASCII.GetBytes(password);

//        // Encrypt string    
//        byte[] encryptedpw = Encrypt(password, aes.Key, aes.IV);

//        MessageBox.Show(System.Text.Encoding.UTF8.GetString(encryptedpw));
                      
//                    // Decrypt the bytes to a string.   
                    
//                    string decryptedpw = Decrypt(encryptedpw, aes.Key, aes.IV);
//        MessageBox.Show(decryptedpw);
//                    password = decryptedpw;
//                    // Print decrypted string. It should be same as raw data    
//                }
//}
//            catch (Exception exp)
//            {
//                MessageBox.Show(exp.Message);
//            }
//            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE name = @usn and password = @pass", db.GetConnection());

//command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
//            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            
//            adapter.SelectCommand = command;

//            adapter.Fill(table);
           
//            if (table.Rows.Count > 0)
//            {
//                //MessageBox.Show("YES");
//                this.Close();

//                Dashboard frm2 = new Dashboard();

//                frm2.Show();
//            }
//            else
//            {
//                MessageBox.Show("Verkeerde Inloggegevens");
//            }
    }
 
}