using App.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Library.Api
{
    public interface IFoxImageEndpoint
    {
        Task<List<FoxImageModel>> GetAll();
        Task SaveFoxImage(FoxImageModel item);
    }
}