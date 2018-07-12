using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DTOs;

namespace BSA_2018_Homework_4.Controllers
{
    //[Produces("application/json")]
    [Route("api/Stewardess")]
    public class StewardessController : Controller
    {
		private IStewardessService stewardessService;

		public StewardessController(IStewardessService stewardessService)
		{
			this.stewardessService = stewardessService; 
		}

        // GET: api/Stewardess
        [HttpGet]
        public IEnumerable<StewardessDTO> Get()
        {
            return stewardessService.GetStewardessCollection();
        }

        // GET: api/Stewardess/5
        [HttpGet("{id}")]
        public StewardessDTO Get(int id)
        {
			return stewardessService.GetStewardessById(id);
        }
        
        // POST: api/Stewardess
        [HttpPost]
        public void Post([FromBody]StewardessDTO stewardess)
        {
			stewardessService.CreateStewardess(stewardess);
        }
        
        // PUT: api/Stewardess/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]StewardessDTO stewardess)
        {
			stewardessService.UpdateStewardess(id, stewardess);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			stewardessService.DeleteStewardessById(id);
        }
    }
}
