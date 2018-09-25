using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMono.Models.Common.Parameters;

namespace VehicleMono.Models.Parameters
{
   public class PagingParameter : IPagingParameter
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
