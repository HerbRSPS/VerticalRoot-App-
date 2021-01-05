using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace VerticalRoot
{
    class Login
    {
        public bool checkLogin(string usr, string pwd)
        {
            bool success = false;
            DB db = new DB();
            db.openConnection();
            System.Data.DataTable table = new System.Data.DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE name = @usn and password = @pass", db.GetConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = usr;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pwd;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
