using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.BL.ServiceInterfaces;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using BSA_2018_Homework_4.DTOs;
using BSA_2018_Homework_4.DAL.Models;
using AutoMapper;

namespace BSA_2018_Homework_4.BL.Services
{
    public class TicketService : ITicketService
    {
		private ITicketRepository ticketRepo;

		public TicketService(ITicketRepository ticketRepo)
		{
			this.ticketRepo = ticketRepo;
		}

		public List<TicketDTO> GetTicketCollection()
		{
			return Mapper.Map<List<Ticket>, List<TicketDTO>>(ticketRepo.GetAll());
		}
		public TicketDTO GetTicketById(int id)
		{
			return Mapper.Map<Ticket, TicketDTO>(ticketRepo.Get(id));
		}
		public void DeleteTicketById(int id)
		{
			ticketRepo.Delete(id);
		}
		public void CreateTicket(TicketDTO item)
		{
			ticketRepo.Create(Mapper.Map<TicketDTO, Ticket>(item));
		}
		public void UpdateTicket(int id, TicketDTO item)
		{
			ticketRepo.Update(id, Mapper.Map<TicketDTO, Ticket>(item));
		}
	}
}
