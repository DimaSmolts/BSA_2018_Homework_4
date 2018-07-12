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
	[Route("api/Flight")]
	public class FlightController : Controller
    {
		private IFlightService flightService;

		public FlightController(IFlightService flightService)
		{
			this.flightService = flightService;
		}

		// GET: api/Flight
		[HttpGet]
		public IEnumerable<FlightDTO> Get()
		{
			return flightService.GetFlightCollection();
		}

		// GET: api/Flight/5
		[HttpGet("{id}")]
		public FlightDTO Get(int id)
		{
			return flightService.GetFlightById(id);
		}

		// POST: api/Flight
		[HttpPost]
		public void Post([FromBody]FlightDTO flight)
		{
			flightService.CreateFlight(flight);
		}

		// PUT: api/Flight/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]FlightDTO flight)
		{
			flightService.UpdateFlight(id, flight);
		}

		// DELETE: api/Flight/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			flightService.DeleteFlightById(id);
		}
	}
}