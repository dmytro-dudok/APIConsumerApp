using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Library.Api
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient _apiClient;
        public ApiHelper()
        {
            InitializeClient();
        }

        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
        }

        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //public async Task<T> GetWeather()
        //{
        //    string api = ConfigurationManager.AppSettings["weatherApi"];

        //    using (HttpResponseMessage response = await _apiClient.GetAsync(api))
        //    {
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = await response.Content.ReadAsAsync<T>();
        //            return result;
        //        }
        //        else
        //        {
        //            throw new Exception(response.ReasonPhrase);
        //        }
        //    }
        //}
    }
}
