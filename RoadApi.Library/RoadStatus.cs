using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadApi.Library
{
    public class RoadStatus
    {
        public static bool GetStatus(string roadId)
        {
            if (roadId != "A1")
            {
                return false;
            }
            return true;
        }
    }
}
