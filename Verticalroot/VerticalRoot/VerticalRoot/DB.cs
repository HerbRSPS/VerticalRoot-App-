using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace VerticalRoot
{
    class DB
    {
        //LOCAL DATABASE
        //MySqlConnection connection = new MySqlConnection("Server=localhost;Uid=root;Database=dbi467376;Pwd=;");
        //MYSQL DATABASE
        MySqlConnection connection = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi467376;Database=dbi467376;Pwd=password123;");
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
