using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tfl.Api.Presentation.Entities;

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
                HttpClient apiClient = GetTfLApiClient();

                HttpResponseMessage response = apiClient.GetAsync("Road/" + roadId + TflKeys).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    var roadStatuses = JsonConvert.DeserializeObject<RoadCorridor[]>(responseString);

                    // consider only one road
                    if (roadStatuses.Length > 0)
                    {
                        info.Valid = true;
                        info.Name = roadStatuses[0].DisplayName;
                        info.StatusSeverity = roadStatuses[0].StatusSeverity;
                        info.StatusSeverityDescription = roadStatuses[0].StatusSeverityDescription;
                    }
                }
                else
                {
                    LastErrorCode = response.StatusCode;
                    LastErrorMessage = response.ReasonPhrase;
                    info.Valid = false;
                }
            }
            else
            {
                throw new InvalidOperationException("TfL Api keys have not been initialized.");
            }
            return info;
        }

        private static HttpClient GetTfLApiClient()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpClient apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.BaseAddress = new Uri(TfLRoadUrl);
            return apiClient;
        }
    }
}
