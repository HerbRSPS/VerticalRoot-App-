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
        public List<int> getAllPlants(int id)
        {
            string selectedPlant = "SELECT * FROM tbl_datadetails WHERE plant_id = 1;";
            MySqlCommand command = new MySqlCommand(selectedPlant, this.connection);
            List<int> plantLists = new List<int>(5);
            using (MySqlDataReader plantValues = command.ExecuteReader())

                if (plantValues.HasRows)
                {
                    while (plantValues.Read())
                    {
                        int currentPlantCelsius = Convert.ToInt32(plantValues["celsius"]);
                        int currentPlantLdr = Convert.ToInt32(plantValues["ldr"]);
                        int currentPlantHumidty = Convert.ToInt32(plantValues["humidity"]);
                        int currentPlantMoisture = Convert.ToInt32(plantValues["moisture"]);
                        int currentPlantWateruse = Convert.ToInt32(plantValues["water_use"]);
                        plantLists.Add(currentPlantLdr);
                        plantLists.Add(currentPlantHumidty);
                        plantLists.Add(currentPlantCelsius);
                        plantLists.Add(currentPlantWateruse);
                        plantLists.Add(currentPlantMoisture);
                    }
                }
            // return list met al die shit hierboven
            return plantLists;
        }

        //get all the plantsdetails(with gesette waardes) for the user and specific clicked plant.
        public List<int> getAllPlantDetails(int uid, int plant_id)
        {
            string selectPlant = "SELECT * FROM tbl_plantdetails WHERE user_id = 2 AND plant_id = 1;";
                    

            MySqlCommand command = new MySqlCommand(selectPlant, this.connection);
            List<int> plantLists = new List<int>(5);
            using (MySqlDataReader plantValues = command.ExecuteReader())

                if (plantValues.HasRows)
                {
                    while (plantValues.Read())
                    {
                        int currentPlantLdr = Convert.ToInt32(plantValues["set_ldr"]);
                        int currentPlantHumidty = Convert.ToInt32(plantValues["set_humidity"]);
                        int currentPlantCelsius = Convert.ToInt32(plantValues["set_celsius"]);
                        int currentPlantWateruse = Convert.ToInt32(plantValues["set_water_use"]);
                        int currentPlantMoisture = Convert.ToInt32(plantValues["set_moisture"]);
                        plantLists.Add(currentPlantLdr);
                        plantLists.Add(currentPlantHumidty);
                        plantLists.Add(currentPlantCelsius);
                        plantLists.Add(currentPlantWateruse);
                        plantLists.Add(currentPlantMoisture);
                    }
                }

            return plantLists;
        }

    }
}
