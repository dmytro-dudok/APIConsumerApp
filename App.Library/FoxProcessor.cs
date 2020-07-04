using WpfUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Library
{
    public class FoxProcessor : IFoxProcessor
    {
        private readonly IApiHelper _apiHelper;

        public FoxProcessor(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<RandomFoxModel> LoadRandomFox()
        {
            string url = $"https://randomfox.ca/floof/";


            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<RandomFoxModel>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
