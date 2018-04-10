using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RoadApi.Library
{
    /**
     * Singleton class responsible to setup communiction with TflApi
     * */
    public class TfLApiClient
    {
        private static TfLApiClient _instance;
        
        // main TfL api URL
        private const string TfL_API_URL = "https://api.tfl.gov.uk";
        private string m_AppId;
        private string m_AppKey;
        private string m_AppKeys;

        private TfLApiClient()
        {
            m_AppKey = string.Empty;
            m_AppId = string.Empty;
            m_AppKeys = string.Empty;
        }

        public static TfLApiClient GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TfLApiClient();
            }

            return _instance;
        }

        private bool ValidateApiKeys()
        {
            return !(string.IsNullOrEmpty(m_AppId) && string.IsNullOrEmpty(m_AppKey));
        }

        public void SetApiKeys(string appId, string appKey)
        {
            m_AppId = appId;
            m_AppKey = appKey;

            if (ValidateApiKeys())
            {
                m_AppKeys = "?app_id=" + m_AppId + "&" + "?app_key=" + m_AppKey;
            } else
            {
                m_AppKeys = string.Empty;
            }
        }

        public HttpClient GetApiConnection()
        {
            if (ValidateApiKeys())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpClient apiClient = new HttpClient();
                apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                apiClient.BaseAddress = new Uri(TfL_API_URL);
                return apiClient;
            }
            else
            {
                throw new InvalidOperationException("TfL Api keys have not been initialized.");
            }
        }

        public string FormatQueryString(string query)
        {
            return query + m_AppKeys;
        }
    }
}
