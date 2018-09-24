﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMono.Models.Common
{
   public interface IVehicleMake
    {
         int ID { get; set; }
         string Name { get; set; }
         string Abrv { get; set; }
    }
}
