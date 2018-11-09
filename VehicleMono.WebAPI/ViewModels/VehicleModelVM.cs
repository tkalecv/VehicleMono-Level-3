using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleMono.WebAPI.ViewModels
{
    public class VehicleModelVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Color { get; set; }
        public int vMakeID { get; set; }
    }
}