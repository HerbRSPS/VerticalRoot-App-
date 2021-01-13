namespace VerticalRoot
{
    class Crop
    {
        /// <summary>
        /// instanciate a crop with the provided parameters.
        /// </summary>
        /// <param name="plantId">a plant id</param>
        /// <param name="temperatureStatus">a temperature</param>
        /// <param name="ldrStatus">a ldr status</param>
        /// <param name="humidityStatus">a humidity status</param>
        /// <param name="waterFlowStatus">a waterflow status</param>
        /// <param name="moistureStatus">a moisture status</param>
        public Crop(int plantId,int temperatureStatus, int ldrStatus, int humidityStatus,  int waterFlowStatus ,int moistureStatus)
        {
            this.plantId = plantId;
            this.temperatureStatus = temperatureStatus;
            this.ldrStatus = ldrStatus;
            this.humidityStatus = humidityStatus;
            this.moistureStatus = moistureStatus;
            this.water_flowStatus = waterFlowStatus;
        }
        public int plantId;
        public int humidityStatus;
        public int ldrStatus;
        public int temperatureStatus;
        public int moistureStatus;
        public int water_flowStatus;
    }
}
