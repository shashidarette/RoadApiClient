using RoadApi.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadApi.Client
{
    class Program
    {
        static int Main(string[] args)
        {
            int status = 0;

            string tflAppId = ConfigurationManager.AppSettings["TflAppId"];
            string tflAppKey = ConfigurationManager.AppSettings["TflAppKey"];
            RoadStatus.SetApiKeys(tflAppId, tflAppKey);

            if (args != null && args.Length > 0)
            {
                string roadId = args[0];
                string msg = string.Empty;

                RoadInformation info = RoadStatus.GetStatus(roadId);
                if (info.Valid)
                {
                    msg = string.Format("The status of the {0} is as follows\r\n" +
                                                "Road Status is {1}\r\n" +
                                                "Road Status Description is {2}.",
                                                info.Name, info.StatusSeverity, info.StatusSeverityDescription);
                }
                else
                {
                    msg = string.Format("{0} is not a valid road\r\n", roadId);
                    status = 1;

                }
                Console.WriteLine(msg);
            }
            return status;
        }
    }
}
