using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDataManager.Library.DataAccess;
using AppDataManager.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppDataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoxController : ControllerBase
    {
        private readonly ImageData _data;

        public FoxController(ImageData data)
        {
            _data = data;
        }

        // GET: api/Fox
        [HttpGet]
        public IEnumerable<FoxImageModel> Get()
        {
            return _data.GetFoxImages();
        }

        // GET: api/Fox/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Fox
        [HttpPost]
        public void Post(FoxImageModel item)
        {
            _data.SaveFoxImageRecord(item);
        }

        // PUT: api/Fox/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
