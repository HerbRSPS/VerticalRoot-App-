using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace VerticalRoot
{
    public class Login
    {
        public int userId;
        public int checkLogin(string usr, string pwd)
        {
            DB db = new DB();

            db.openConnection();
            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE name = @usn and password = @pass", db.GetConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = usr;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pwd;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            using (MySqlDataReader getUserId = adapter.SelectCommand.ExecuteReader())
            {
                if (getUserId.HasRows)
                {
                    while (getUserId.Read())
                    {
                        if (table.Rows.Count > 0)
                        {
                            userId = Convert.ToInt32(getUserId["id"]);
                            return userId;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                return 0;
            }
        }
        public int getUserID(int uid)
        {
            
            return uid;
        }
    }
}
