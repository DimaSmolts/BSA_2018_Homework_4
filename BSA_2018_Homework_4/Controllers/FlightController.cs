using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSA_2018_Homework_4.Controllers
{
	[Route("api/Flight")]
	public class FlightController : Controller
    {
		// GET: api/Flight
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/Flight/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Flight
		[HttpPost]
		public void Post([FromBody]string value)
		{
		}

		// PUT: api/Flight/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/Flight/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}