using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;

namespace VerticalRoot
{
    /// <summary>
    /// Interaction logic for plantdetail.xaml
    /// </summary>
    public partial class plantdetail : Window
    {
        public plantdetail()
        {
            string uid = "2";
            string pid = "1";
            try
            {

                DB db = new DB();
                db.openConnection();
                InitializeComponent();
                string mysql = "SELECT * FROM tbl_plantdetails WHERE user_id = @uid AND plant_id = @pid;";  

                
                MySqlCommand command = new MySqlCommand(mysql, db.GetConnection());
                command.Parameters.Add("@uid", MySqlDbType.VarChar).Value = uid;
                command.Parameters.Add("@pid", MySqlDbType.VarChar).Value = pid;
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dtt = new DataTable();
                da.Fill(dtt);
                DataGrid dg = new DataGrid();
                dt_plantdetail.ItemsSource = dtt.AsDataView();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Dt_plantdetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
