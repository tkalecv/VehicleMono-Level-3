using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMono.Models.Common.Parameters;

namespace VehicleMono.Models.Parameters
{
   public class FilteringParameter : IFilteringParameter
    {
        public string Search { get; set; }
    }
}
