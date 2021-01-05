using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;

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
        private List<Crop> cropList;
        public class showTable
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Text { get; set; }
            public int Pid { get; set; }

            public override string ToString()
            {
                return this.Name.ToString();
            }
        }

        /// <summary>
        /// fills the cropList.
        /// </summary>
        public void SensorQuery()
        {
            DB word = new DB();
            word.openConnection();
            var sql = word.GetConnection();

            List<int> plantIds = sql.Query<int>("select plant_id from tbl_datadetails").ToList();
            List<int> value_celsius = sql.Query<int>("select celsius from tbl_datadetails").ToList();
            List<int> value_ldr = sql.Query<int>("select ldr from tbl_datadetails").ToList();
            List<int> value_humidity = sql.Query<int>("select humidity from tbl_datadetails").ToList();
            List<int> value_moisture = sql.Query<int>("select moisture from tbl_datadetails").ToList();
            List<int> value_water_flow = sql.Query<int>("select water_use from tbl_datadetails").ToList();
            cropList = new List<Crop>(value_water_flow.Count);
            int index = 0;
            foreach (var v in value_celsius)
            {
                Crop newCrop = new Crop(plantIds[index], v, value_ldr[index], value_humidity[index], value_water_flow[index], value_moisture[index]);
                cropList.Add(newCrop);
                index++;
            }
        }

        /// <summary>
        /// returns a Showtable of the crop by the plant id specified.
        /// </summary>
        /// <param name="id">plant id</param>
        /// <returns>List-ShowTable</returns>
        public List<showTable> getValuesByPlantId(int id)
        {
            foreach (var vCrop in cropList)
            {
                if (vCrop.plantId == id)
                {
                    string temperatureNaming = $"{vCrop.temperatureStatus} °";
                    string ldrNaming = $"{vCrop.ldrStatus} LX";
                    string humidityNaming = $"{vCrop.humidityStatus} %";
                    string moistureNaming = $"{vCrop.moistureStatus} %";
                    string water_useNaming = $"{vCrop.water_flowStatus} L/H";
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
        public Crop getByPlantId(int id)
        {
            foreach (var vCrop in cropList)
            {
                if (vCrop.plantId == id)
                {

                    return vCrop;
                }
            }
            return null;
        }

        /// <summary>
        /// returns the crop based on the id in the list. (starts at 0)
        /// </summary>
        /// <param name="id">id in list</param>
        /// <returns>a crop</returns>
        public Crop getCrop(int id)
        {
            return cropList[id];
        }

        /// <summary>
        /// validates the parameters for the specified type for a crop by plant id
        /// </summary>
        /// <param name="id">plant id</param>
        /// <param name="type"> a statusType enum</param>
        /// <returns>correct label string for the specified type</returns>
        public string StatusChecker(int id, StatusType type)
        {
            string toReturn = "";
            Crop myCrop = this.getByPlantId(id);
            switch (type)
            {
                case StatusType.Temperature:
                    toReturn = StatusTemperature(myCrop);
                    break;
                case StatusType.Humidity:
                    toReturn = StatusHumidity(myCrop);
                    break;
                case StatusType.LDR:
                    toReturn = StatusLDR(myCrop);
                    break;
                case StatusType.Moisture:
                    toReturn = StatusMoisture(myCrop);
                    break;
                case StatusType.WaterFlow:
                    toReturn = StatusWaterFlow(myCrop);
                    break;
            }
            return toReturn;
        }

        /// <summary>
        /// Validates the parameter for the WaterFlow of a given crop
        /// </summary>
        /// <param name="myCrop">a crop to check</param>
        /// <returns>the correct label string</returns>
        private string StatusWaterFlow(Crop myCrop)
        {
            if (myCrop.water_flowStatus != 20)
            {
                //temp is not 20 degrees
                if (myCrop.water_flowStatus < 20)
                {
                    //temp is under 20
                    int valueDifference1 = 20 - myCrop.water_flowStatus;
                    return "Your Water flow is to slow! Add " + valueDifference1 + "L/H";
                }
                else if (myCrop.water_flowStatus > 20)
                {
                    //temp is above 20
                    int valueDifference2 = myCrop.water_flowStatus - 20;
                    return "Your Water flow is to fast! Lower " + valueDifference2 + "L/H";
                }
            }
            //temp == 20
            return "Perfect!";
        }

        /// <summary>
        /// Validates the parameter for the Moisture of a given crop
        /// </summary>
        /// <param name="myCrop">a crop to check</param>
        /// <returns>the correct label string</returns>
        private string StatusMoisture(Crop myCrop)
        {
            if (myCrop.moistureStatus != 20)
            {
                //temp is not 20 degrees
                if (myCrop.moistureStatus < 20)
                {
                    //temp is under 20
                    int valueDifference1 = 20 - myCrop.moistureStatus;
                    return "Your moisture is to low! Add " + valueDifference1 + "%";
                }
                else if (myCrop.moistureStatus > 20)
                {
                    //temp is above 20
                    int valueDifference2 = myCrop.moistureStatus - 20;
                    return "Your moisture is to high! Lower " + valueDifference2 + "%";
                }
            }
            //temp == 20
            return "Perfect!";
        }

        /// <summary>
        /// Validates the parameter for the LDR of a given crop
        /// </summary>
        /// <param name="myCrop">a crop to check</param>
        /// <returns>the correct label string</returns>
        private string StatusLDR(Crop myCrop)
        {
            if (myCrop.ldrStatus != 20000)
            {
                //temp is not 20 degrees
                if (myCrop.ldrStatus < 20000)
                {
                    //temp is under 20
                    int valueDifference1 = 20000 - myCrop.ldrStatus;
                    return "Your LDR is to low! Add " + valueDifference1 + "LUX";
                }
                else if (myCrop.ldrStatus > 20000)
                {
                    //temp is above 20
                    int valueDifference2 = myCrop.ldrStatus - 20000;
                    return "Your LDR is to high! Lower " + valueDifference2 + "LUX";
                }
            }
            //temp == 20
            return "Perfect!";
        }

        /// <summary>
        /// Validates the parameter for the Humidity of a given crop
        /// </summary>
        /// <param name="myCrop">a crop to check</param>
        /// <returns>the correct label string</returns>
        private string StatusHumidity(Crop myCrop)
        {
            if (myCrop.humidityStatus != 20)
            {
                //temp is not 20 degrees
                if (myCrop.humidityStatus < 20)
                {
                    //temp is under 20
                    int valueDifference1 = 20 - myCrop.humidityStatus;
                    return "Your humidity is to low! Add " + valueDifference1 + "%";
                }
                else if (myCrop.humidityStatus > 20)
                {
                    //temp is above 20
                    int valueDifference2 = myCrop.humidityStatus - 20;
                    return "Your humidity is to high! Lower " + valueDifference2 + "%";
                }
            }
            //temp == 20
            return "Perfect!";
        }

        /// <summary>
        /// Validates the parameter for the temperature of a given crop
        /// </summary>
        /// <param name="myCrop">a crop to check</param>
        /// <returns>the correct label string</returns>
        private string StatusTemperature(Crop myCrop)
        {
            if (myCrop.temperatureStatus != 20)
            {
                //temp is not 20 degrees
                if (myCrop.temperatureStatus < 20)
                {
                    //temp is under 20
                    int valueDifference1 = 20 - myCrop.temperatureStatus;
                    return "Your temperature is to low! Add " + valueDifference1 + "°";
                }
                else if (myCrop.temperatureStatus > 20)
                {
                    //temp is above 20
                    int valueDifference2 = myCrop.temperatureStatus - 20;
                    return "Your temperature is to high! Lower " + valueDifference2 + "°";
                }
            }
            //temp == 20
            return "Perfect!";
        }
    }
}

