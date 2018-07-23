using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CardManage.DTO;
using CardManage.IService;
using CardManage.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardManage.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/CardApi")]
    public class CardApiController : Controller
    {
        ICardService cardSvc = new CardService();

        // GET: api/CardApi
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/CardApi/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/CardApi
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/CardApi/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [Route("GetAllCards")]
        public async Task<IEnumerable<CardDTO>> GetAllCards()
        {
            return await cardSvc.GetAllCards();
        }
    }
}
