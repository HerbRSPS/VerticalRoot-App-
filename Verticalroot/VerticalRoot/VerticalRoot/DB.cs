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
        //get all the plants connected to the given user
        public MySqlCommand getAllPlants(int id)
        {
            string selectedPlant = "SELECT * FROM tbl_datadetails WHERE plant_id = 1;";
            MySqlCommand command = new MySqlCommand(selectedPlant, this.connection);
            //MySqlDataAdapter da = new MySqlDataAdapter(command);
            return command;
        }

        //get all the plantsdetails(with gesette waardes) for the user and specific clicked plant.
        public void getAllPlantDetails(int id, int plant_id)
        {
            string selectPlant = "SELECT * FROM tbl_plantdetails WHERE user_id = 2 AND plant_id = 1;";
                    

            MySqlCommand command2 = new MySqlCommand(selectPlant, this.connection);
        }

    }
}
