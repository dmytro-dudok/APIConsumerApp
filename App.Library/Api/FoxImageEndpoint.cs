using App.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Library.Api;

namespace App.Library.Api
{
    public class FoxImageEndpoint : IFoxImageEndpoint
    {
        private readonly IApiHelper _apiHelper;

        public FoxImageEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<FoxImageModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/Fox"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<FoxImageModel>>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

        public async Task SaveFoxImage(FoxImageModel item)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("api/Fox", item))
            {
                if (response.IsSuccessStatusCode)
                {
                    //Log successful call?
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
