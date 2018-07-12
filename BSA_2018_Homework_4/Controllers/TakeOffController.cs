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
    [Route("api/TakeOff")]
    public class TakeOffController : Controller
    {
		private ITakeOffService takeOffService;

		public TakeOffController(ITakeOffService takeOffService)
		{
			this.takeOffService = takeOffService;
		}

        // GET: api/TakeOff
        [HttpGet]
        public IEnumerable<TakeOffDTO> Get()
        {
            return takeOffService.GetTakeOffCollection();
        }

        // GET: api/TakeOff/5
        [HttpGet("{id}")]
        public TakeOffDTO Get(int id)
        {
            return takeOffService.GetTakeOffById(id);
        }
        
        // POST: api/TakeOff
        [HttpPost]
        public void Post([FromBody]TakeOffDTO takeOff)
        {
			takeOffService.CreateTakeOff(takeOff);
        }
        
        // PUT: api/TakeOff/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TakeOffDTO takeOff)
        {
			takeOffService.UpdateTakeOff(id, takeOff);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			takeOffService.DeleteTakeOffById(id);
        }
    }
}
