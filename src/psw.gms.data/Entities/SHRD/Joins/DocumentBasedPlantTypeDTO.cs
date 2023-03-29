using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Data.Entities
{
    public class DocumentBasedPlantTypeDTO
    {
        public short ID { get; set; }
        public short PlantTypeID { get; set; }
        public string Name { get; set; }
    }
}