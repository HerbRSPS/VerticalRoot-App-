using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using Dapper;
using Brushes = System.Windows.Media.Brushes;

namespace VerticalRoot
{
    enum StatusType
    {
        Temperature,
        Humidity,
        Moisture,
        WaterFlow,
        LDR
    }
    class CropList
    {
        public List<Crop> cropList;
        public List<string> plantNameList;
        public List<int> plantIdList;
        DBUtils plantDetails = new DBUtils();
        int userIds = Login.userId;
        public static int plantID { get; set; }

        public class showTable
        {
            public string Name { get; set; }

            public override string ToString()
            {
                return this.Name.ToString();
            }
        }

        ///// <summary>
        ///// fills the cropList.
        ///// </summary>
        public void SensorQuery()
        {
            Db databaseConnection = new Db();
            databaseConnection.OpenConnection();
            MySqlConnection sql = databaseConnection.GetConnection();
            plantIdList = sql.Query<int>("SELECT plant_id FROM tbl_datadetails WHERE user_id = " + Login.userId).ToList();
            List<int> value_celsius = sql.Query<int>("select celsius from tbl_datadetails WHERE user_id = " + Login.userId).ToList();
            List<int> value_ldr = sql.Query<int>("select ldr from tbl_datadetails WHERE user_id = " + Login.userId).ToList();
            List<int> value_humidity = sql.Query<int>("select humidity from tbl_datadetails WHERE user_id = " + Login.userId).ToList();
            List<int> value_moisture = sql.Query<int>("select moisture from tbl_datadetails WHERE user_id = " + Login.userId).ToList();
            List<int> value_water_flow = sql.Query<int>("select water_use from tbl_datadetails WHERE user_id = " + Login.userId).ToList();
            cropList = new List<Crop>(value_water_flow.Count);
            int index = 0;
            foreach (int value in value_celsius)
            {
                Crop newCrop = new Crop(plantIdList[index], value, value_ldr[index], value_humidity[index], value_water_flow[index], value_moisture[index]);
                cropList.Add(newCrop);
                index++;
            }
            databaseConnection.CloseConnection();
        }

        ///// <summary>
        ///// Creates 2 lists, where one is for the plant names and the other for the plant id's.
        ///// </summary>
        public List<string> PlantNameQuery()
        {
            Db db = new Db();
            db.OpenConnection();
            int uid = Login.userId;
            string getPLantName = "SELECT plant_name FROM tbl_datadetails WHERE user_id = " + Login.userId;
            string getPlantId = "SELECT plant_id FROM tbl_datadetails WHERE user_id =" + Login.userId;
            MySqlCommand getPlantNameCommand = new MySqlCommand(getPLantName, db.GetConnection());
            MySqlCommand getPlantIdCommand = new MySqlCommand(getPlantId, db.GetConnection());
            plantNameList = new List<string>();
            plantIdList = new List<int>();

            using (MySqlDataReader reader = getPlantNameCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string plantName = reader.GetString("plant_name");
                    plantNameList.Add(plantName);
                }
            }
            using (MySqlDataReader reader = getPlantIdCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    int plantId = reader.GetInt32("plant_id");
                    plantIdList.Add(plantId);
                }
            }
            return plantNameList;
        }

        /// <summary>
        /// Returns that row 1 in plantNameList = row 1 plantIdList.
        /// </summary>
        /// <param name="get">plant id</param>
        /// <returns>plantId</returns>
        public int ReturnPlantId(string get)
        {
            int index = 0;
            foreach (string plantName in plantNameList)
            {
                if (plantName == get)
                {
                    return plantIdList[index];
                }
                index++;
            }
            return -1;
        }

        /// <summary>
        /// returns a Showtable of the crop by the plant id specified.
        /// </summary>
        /// <param name="id">plant id</param>
        /// <returns>List-ShowTable</returns>
        public List<showTable> GetValuesByPlantId(int id)
        {
            foreach (Crop crop in cropList)
            {
                if (crop.plantId == id)
                {
                    string temperatureNaming = $"{crop.temperatureStatus} °";
                    string ldrNaming = $"{crop.ldrStatus} LX";
                    string humidityNaming = $"{crop.humidityStatus} %";
                    string moistureNaming = $"{crop.moistureStatus} %";
                    string water_useNaming = $"{crop.water_flowStatus} L/H";
                    List<showTable> value_list = new List<showTable>(5);
                    value_list.Add(new showTable { Name = temperatureNaming });
                    value_list.Add(new showTable { Name = ldrNaming });
                    value_list.Add(new showTable { Name = humidityNaming });
                    value_list.Add(new showTable { Name = moistureNaming });
                    value_list.Add(new showTable { Name = water_useNaming });
                    return value_list;
                }
            }
            return null;
        }

        /// <summary>
        /// returns the crops by the plant id specified.
        /// </summary>
        /// <param name="id">plant id</param>
        /// <returns>a crop</returns>
        public Crop GetByPlantId(int id)
        {
            foreach (Crop crop in cropList)
            {
                if (crop.plantId == id)
                {
                    plantID = crop.plantId;
                    return crop;
                }
            }
            return null;
        }

        /// <summary>
        /// validates the parameters for the specified type for a crop by plant id
        /// </summary>
        /// <param name="id">plant id</param>
        /// <param name="type"> a statusType enum</param>
        /// <returns>correct label string for the specified type</returns>
        public void StatusChecker(int id, StatusType type, System.Windows.Controls.Label xLabel)
        {
            string toReturn = "";
            Crop myCrop = this.GetByPlantId(id);
            switch (type)
            {
                case StatusType.Temperature:
                    toReturn = StatusTemperature(myCrop);
                    break;
                case StatusType.Humidity:
                    toReturn = StatusHumidity(myCrop);
                    break;
                case StatusType.LDR:
                    toReturn = StatusLdr(myCrop);
                    break;
                case StatusType.Moisture:
                    toReturn = StatusMoisture(myCrop);
                    break;
                case StatusType.WaterFlow:
                    toReturn = StatusWaterFlow(myCrop);
                    break;
            }
            if (toReturn == "Perfect!")
                xLabel.Foreground = Brushes.ForestGreen;
            xLabel.Content = toReturn;
        }

        /// <summary>
        /// Validates the parameter for the LDR of a given crop
        /// </summary>
        /// <param name="myCrop">a crop to check</param>
        /// <returns>the correct label string</returns>
        private string StatusLdr(Crop myCrop)
        {
            List<int> setValues = plantDetails.getAllPlantDetails(userIds, myCrop.plantId);
            if (myCrop.ldrStatus != setValues[0])
            {
                if (myCrop.ldrStatus < setValues[0])
                {
                    int valueDifference1 = setValues[0] - myCrop.ldrStatus;
                    return "Your LDR is to low! Add " + valueDifference1 + "LUX";
                }
                else if (myCrop.ldrStatus > setValues[0])
                {
                    int valueDifference2 = myCrop.ldrStatus - setValues[0];
                    return "Your LDR is to high! Lower " + valueDifference2 + "LUX";
                }
            }
            return "Perfect!";
        }

        /// <summary>
        /// Validates the parameter for the Humidity of a given crop
        /// </summary>
        /// <param name="myCrop">a crop to check</param>
        /// <returns>the correct label string</returns>
        private string StatusHumidity(Crop myCrop)
        {
            List<int> setValues = plantDetails.getAllPlantDetails(userIds, myCrop.plantId);
            if (myCrop.humidityStatus != setValues[1])
            {
                if (myCrop.humidityStatus < setValues[1])
                {
                    int valueDifference1 = setValues[1] - myCrop.humidityStatus;
                    return "Your humidity is to low! Add " + valueDifference1 + "%";
                }
                else if (myCrop.humidityStatus > setValues[1])
                {
                    int valueDifference2 = myCrop.humidityStatus - setValues[1];
                    return "Your humidity is to high! Lower " + valueDifference2 + "%";
                }
            }
            return "Perfect!";
        }

        /// <summary>
        /// Validates the parameter for the temperature of a given crop
        /// </summary>
        /// <param name="myCrop">a crop to check</param>
        /// <returns>the correct label string</returns>
        private string StatusTemperature(Crop myCrop)
        {
            List<int> setValues = plantDetails.getAllPlantDetails(userIds, myCrop.plantId);
            if (myCrop.temperatureStatus != setValues[2])
            {
                if (myCrop.temperatureStatus < setValues[2])
                {
                    int valueDifference1 = setValues[2] - myCrop.temperatureStatus;
                    return "Your temperature is to low! Add " + valueDifference1 + "°";
                }
                else if (myCrop.temperatureStatus > setValues[2])
                {
                    int valueDifference2 = myCrop.temperatureStatus - setValues[2];
                    return "Your temperature is to high! Lower " + valueDifference2 + "°";
                }
            }
            return "Perfect!";
        }

        /// <summary>
        /// Validates the parameter for the WaterFlow of a given crop
        /// </summary>
        /// <param name="myCrop">a crop to check</param>
        /// <returns>the correct label string</returns>
        private string StatusWaterFlow(Crop myCrop)
        {
            List<int> setValues = plantDetails.getAllPlantDetails(userIds, myCrop.plantId);
            if (myCrop.water_flowStatus != setValues[3])
            {
                if (myCrop.water_flowStatus < setValues[3])
                {
                    int valueDifference1 = setValues[3] - myCrop.water_flowStatus;
                    return "Your Water flow is to slow! Add " + valueDifference1 + "L/H";
                }
                else if (myCrop.water_flowStatus > setValues[3])
                {
                    int valueDifference2 = myCrop.water_flowStatus - setValues[3];
                    return "Your Water flow is to fast! Lower " + valueDifference2 + "L/H";
                }
            }
            return "Perfect!";
        }

        /// <summary>
        /// Validates the parameter for the Moisture of a given crop
        /// </summary>
        /// <param name="myCrop">a crop to check</param>
        /// <returns>the correct label string</returns>
        private string StatusMoisture(Crop myCrop)
        {
            List<int> setValues = plantDetails.getAllPlantDetails(userIds, myCrop.plantId);
            if (myCrop.moistureStatus != setValues[4])
            {
                if (myCrop.moistureStatus < setValues[4])
                {
                    int valueDifference1 = setValues[4] - myCrop.moistureStatus;
                    return "Your moisture is to low! Add " + valueDifference1 + "%";
                }
                else if (myCrop.moistureStatus > setValues[4])
                {
                    int valueDifference2 = myCrop.moistureStatus - setValues[4];
                    return "Your moisture is to high! Lower " + valueDifference2 + "%";
                }
            }
            return "Perfect!";
        }
    }
}

