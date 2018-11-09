using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMono.Models.Common.Parameters
{
    public interface IPagingParameter
    {
        int pageNumber { get; set; }
        int _pageSize { get; set; }
        int pageSize { get; set; }
    }
}
