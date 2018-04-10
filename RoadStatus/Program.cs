using RoadApi.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadApi.Client
{
    /**
     * Comand client responsible for communication with TflAPi and RoadStatus
     * */
    class Program
    {
        private const string ValidaRoadMessage = "The status of the {0} is as follows\r\n" +
                                                        "Road Status is {1}\r\n" +
                                                        "Road Status Description is {2}.";
        private const string InvalidRoadMessage = "{0} is not a valid road\r\n";

        static int Main(string[] args)
        {
            int status = 0;

            string tflAppId = ConfigurationManager.AppSettings["TflAppId"];
            string tflAppKey = ConfigurationManager.AppSettings["TflAppKey"];
            TfLApiClient.GetInstance().SetApiKeys(tflAppId, tflAppKey);

            if (args != null && args.Length > 0)
            {
                string roadId = args[0];
                string msg = string.Empty;

                RoadInformation info = RoadStatus.GetStatus(roadId);
                if (info.Valid)
                {
                    msg = string.Format(ValidaRoadMessage,
                                                info.Name, info.StatusSeverity, info.StatusSeverityDescription);
                }
                else
                {
                    msg = string.Format(InvalidRoadMessage, roadId);
                    status = 1;

                }
                Console.WriteLine(msg);
            }
            return status;
        }
    }
}
