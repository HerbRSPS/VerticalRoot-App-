using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace VerticalRoot
{
    class Plant
    {
        int uid = Login.userId;
        string pid = "1";
        string mysql = "SELECT * FROM tbl_plantdetails WHERE user_id = @uid AND plant_id = @pid;";
        public MySqlDataAdapter connect()
        {
            Db db = new Db();
            db.OpenConnection();

            MySqlCommand command = new MySqlCommand(mysql, db.GetConnection());
            command.Parameters.Add("@uid", MySqlDbType.VarChar).Value = uid;
            command.Parameters.Add("@pid", MySqlDbType.VarChar).Value = pid;
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            DataGrid dg = new DataGrid();
            return da;
        }
    }
}
