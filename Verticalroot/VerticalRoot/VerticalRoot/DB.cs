using MySql.Data.MySqlClient;

namespace VerticalRoot
{
    class Db
    {
        MySqlConnection connection = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi467376;Database=dbi467376;Pwd=password123;");
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void CloseConnection()
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
