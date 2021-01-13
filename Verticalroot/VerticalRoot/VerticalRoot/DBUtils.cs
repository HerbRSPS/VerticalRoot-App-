using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace VerticalRoot
{
    class DBUtils
    {
        //get all the plantsdetails(with gesette waardes) for the user and specific clicked plant.
        public List<int> getAllPlantDetails(int uid, int plant_id)
        {
            Db word = new Db();
            word.OpenConnection();

            int id = DashboardMyCrops.id;
            MySqlCommand command = new MySqlCommand("SELECT * FROM tbl_plantdetails WHERE plant_id = @pid AND user_id = " + Login.userId, word.GetConnection());
            command.Parameters.Add("@pid", MySqlDbType.VarChar).Value = id;

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
