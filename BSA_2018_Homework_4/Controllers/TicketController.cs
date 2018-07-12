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
    [Route("api/Ticket")]
    public class TicketController : Controller
    {
		private ITicketService ticketService;

		public TicketController(ITicketService ticketService)
		{
			this.ticketService = ticketService;
		}

        // GET: api/Ticket
        [HttpGet]
        public IEnumerable<TicketDTO> Get()
        {
            return ticketService.GetTicketCollection();
        }

        // GET: api/Ticket/5
        [HttpGet("{id}")]
        public TicketDTO Get(int id)
        {
            return ticketService.GetTicketById(id);
        }
        
        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody]TicketDTO ticket)
        {
			ticketService.CreateTicket(ticket);
        }
        
        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TicketDTO ticket)
        {
			ticketService.UpdateTicket(id, ticket);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			ticketService.DeleteTicketById(id);
        }
    }
}
