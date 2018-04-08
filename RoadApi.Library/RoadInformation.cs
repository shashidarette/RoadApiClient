using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadApi.Library
{
    public class RoadInformation
    {
        public object Name { get; set; }
        public object StatusSeverity { get; set; }
        public object StatusSeverityDescription { get; set; }
        public bool Valid { get; set; }
    }
}
