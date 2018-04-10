using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using Tfl.Api.Presentation.Entities;

namespace RoadApi.Library
{
    /**
     * Class responsible for RoadStatus api calls
     * */
    public class RoadStatus
    {
        public static string LastErrorMessage { get; private set; }
        public static HttpStatusCode LastErrorCode { get; private set; }

        // Responsible to the required call to get the RoadStatus
        public static RoadInformation GetStatus(string roadId)
        {
            TfLApiClient tFLApi = TfLApiClient.GetInstance();
            RoadInformation info = new RoadInformation();

            HttpClient apiClient = tFLApi.GetApiConnection();
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
