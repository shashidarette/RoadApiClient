using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RoadApi.Library
{
    public class TfLApi
    {
        private static TfLApi _instance;
        
        private const string TfL_API_URL = "https://api.tfl.gov.uk";
        private string m_AppId;
        private string m_AppKey;
        private string m_AppKeys;

        private TfLApi()
        {
            m_AppKey = string.Empty;
            m_AppId = string.Empty;
            m_AppKeys = string.Empty;
        }

        public static TfLApi GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TfLApi();
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
            m_AppKeys = "?app_id=" + m_AppId + "&" + "?app_key=" + m_AppKey;
        }

        public HttpClient GetApiClient()
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
