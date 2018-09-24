using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLevel3.Entities
{
   public class VehicleModelEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Color { get; set; }

        public int? VehicleMakeID { get; set; }
        public VehicleMakeEntity VehicleMake { get; set; }
    }
}
