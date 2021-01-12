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
    class Plant
    {


        int uid = MainWindow.userId;
        string pid = "1";
        string mysql = "SELECT * FROM tbl_plantdetails WHERE user_id = @uid AND plant_id = @pid;";
        public MySqlDataAdapter connect()
        {
            DB db = new DB();
            db.openConnection();
            //db.GetConnection();

            MySqlCommand command = new MySqlCommand(mysql, db.GetConnection());
            command.Parameters.Add("@uid", MySqlDbType.VarChar).Value = uid;
            command.Parameters.Add("@pid", MySqlDbType.VarChar).Value = pid;
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            DataGrid dg = new DataGrid();
            return da;
        }

    }
}
