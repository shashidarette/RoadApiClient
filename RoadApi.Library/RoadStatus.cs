using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadApi.Library
{
    public class RoadStatus
    {
        public static RoadInformation GetStatus(string roadId)
        {
            RoadInformation info = new RoadInformation();
            if (roadId != "A1")
            {
                info.Valid = false;
                return info;
            }

            info.Valid = true;
            info.Name = roadId;
            info.StatusSeverity = "Good";
            info.StatusSeverityDescription = "No delays";
            return info;
        }
    }
}
