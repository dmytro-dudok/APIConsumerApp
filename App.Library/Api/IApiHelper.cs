using System.Net.Http;

namespace WpfUI.Library.Api
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }
    }
}