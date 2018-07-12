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
    [Route("api/Pilot")]
    public class PilotController : Controller
    {
		private IPilotService pilotService;

		public PilotController(IPilotService pilotService)
		{
			this.pilotService = pilotService;
		}

        // GET: api/Pilot
        [HttpGet]
        public IEnumerable<PilotDTO> Get()
        {
			return pilotService.GetPilotCollection();
        }

        // GET: api/Pilot/5
        [HttpGet("{id}")]
        public PilotDTO Get(int id)
        {
            return pilotService.GetPilotById(id);
        }
        
        // POST: api/Pilot
        [HttpPost]
        public void Post([FromBody]PilotDTO pilot)
        {
			pilotService.CreatePilot(pilot);
        }
        
        // PUT: api/Pilot/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PilotDTO pilot)
        {
			pilotService.UpdatePilot(id, pilot);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			pilotService.DeletePilotById(id);
        }
    }
}
