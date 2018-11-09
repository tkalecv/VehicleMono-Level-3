using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMono.Models.Common;

namespace VehicleMono.Models
{
    public class VehicleModel : IVehicleModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Color { get; set; }
        public int vMakeID { get; set; }
    }
}
