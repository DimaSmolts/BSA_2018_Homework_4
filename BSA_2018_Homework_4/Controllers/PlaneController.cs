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
    [Route("api/Plane")]
    public class PlaneController : Controller
    {
		private IPlaneService planeService;

		public PlaneController(IPlaneService planeService)
		{
			this.planeService = planeService;
		}

        // GET: api/Plane
        [HttpGet]
        public IEnumerable<PlaneDTO> Get()
        {
			return planeService.GetPlaneCollection();
        }

        // GET: api/Plane/5
        [HttpGet("{id}")]
        public PlaneDTO Get(int id)
        {
            return planeService.GetPlaneById(id);
        }
        
        // POST: api/Plane
        [HttpPost]
        public void Post([FromBody]PlaneDTO plane)
        {
			planeService.CreatePlane(plane);
        }
        
        // PUT: api/Plane/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PlaneDTO plane)
        {
			planeService.UpdatePlane(id, plane);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			planeService.DeletePlaneById(id);
        }
    }
}
