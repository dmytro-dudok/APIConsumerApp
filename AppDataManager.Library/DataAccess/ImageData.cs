using AppDataManager.Library.Internal.DataAccess;
using AppDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDataManager.Library.DataAccess
{
    public class ImageData
    {
        private readonly SqlDataAccess _sql;

        public ImageData(SqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<FoxImageModel> GetFoxImages()
        {
            var output = _sql.LoadData<FoxImageModel, dynamic>("dbo.spFoxImage_GetAll", new { }, "AppData");

            return output;
        }

        public void SaveFoxImageRecord(FoxImageModel item)
        {
            _sql.SaveData("dbo.spFoxImage_Insert", item, "AppData");
        }
    }
}
