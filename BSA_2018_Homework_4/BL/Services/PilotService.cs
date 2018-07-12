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
    public class PilotService : IPilotService
    {
		private IPilotRepository pilotRepo;

		public PilotService(IPilotRepository pilotRepo)
		{
			this.pilotRepo = pilotRepo;
		}

		public void CreatePilot(PilotDTO item)
		{
			pilotRepo.Create(Mapper.Map<PilotDTO, Pilot>(item));
		}

		public void DeletePilotById(int id)
		{
			pilotRepo.Delete(id);
		}

		public PilotDTO GetPilotById(int id)
		{
			return Mapper.Map<Pilot,PilotDTO>(pilotRepo.Get(id));
		}

		public List<PilotDTO> GetPilotCollection()
		{
			return Mapper.Map<List<Pilot>, List<PilotDTO>>(pilotRepo.GetAll());
		}

		public void UpdatePilot(int id, PilotDTO item)
		{
			pilotRepo.Update(id, Mapper.Map<PilotDTO, Pilot>(item));
		}
	}
}
