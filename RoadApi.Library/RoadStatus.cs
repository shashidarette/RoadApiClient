using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using Tfl.Api.Presentation.Entities;

namespace RoadApi.Library
{
    public class RoadStatus
    {
        public static string LastErrorMessage { get; private set; }
        public static HttpStatusCode LastErrorCode { get; private set; }

        public static RoadInformation GetStatus(string roadId)
        {
            TfLApi tFLApi = TfLApi.GetInstance();
            RoadInformation info = new RoadInformation();

            HttpClient apiClient = tFLApi.GetApiClient();
            string query = tFLApi.FormatQueryString("Road/" + roadId);
            HttpResponseMessage response = apiClient.GetAsync(query).Result;

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
            
            return info;
        }
    }
}
