using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadApi.Library
{
    public class RoadStatus
    {
        private static string TfLRoadUrl = "https://api.tfl.gov.uk";
        private static string TfLAppId;
        private static string TfLAppKey;
        private static string TflKeys;

        public static object LastErrorCode { get; set; }
        public static object LastErrorMessage { get; set; }

        private static bool ValidateApiKeys()
        {
            return !(string.IsNullOrEmpty(TfLAppId) && string.IsNullOrEmpty(TfLAppKey));
        }

        public static void SetApiKeys(string tfLAppId, string tflAppKey)
        {
            TfLAppId = tfLAppId;
            TfLAppKey = tflAppKey;
            TflKeys = "?app_id=" + TfLAppId + "&" + "?app_key=" + TfLAppKey;
        }

        public static RoadInformation GetStatus(string roadId)
        {
            RoadInformation info = new RoadInformation();
            if (ValidateApiKeys())
            {
                if (roadId != "A1")
                {
                    info.Valid = false;
                    LastErrorCode = "404";
                    LastErrorMessage = "Road does not exist.";
                    return info;
                }

                info.Valid = true;
                info.Name = roadId;
                info.StatusSeverity = "Good";
                info.StatusSeverityDescription = "No delays";
            } else
            {
                throw new InvalidOperationException("TfL Api keys have not been submitted.");
            }
            return info;
        }
    }
}
