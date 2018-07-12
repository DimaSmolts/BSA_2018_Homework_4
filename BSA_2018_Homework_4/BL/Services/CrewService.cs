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
    public class CrewService : ICrewService
    {
		private ICrewRepository crewRepository;

		public CrewService(ICrewRepository crewRepository)
		{
			this.crewRepository = crewRepository;
		}

		public void CreateCrew(CrewDTO item)
		{
			crewRepository.Create(Mapper.Map<CrewDTO,Crew>(item));
		}

		public void DeleteCrewById(int id)
		{
			crewRepository.Delete(id);
		}

		public CrewDTO GetCrewById(int id)
		{
			return Mapper.Map<Crew, CrewDTO>(crewRepository.Get(id));
		}

		public List<CrewDTO> GetCrewCollection()
		{
			return Mapper.Map<List<Crew>, List<CrewDTO>>(crewRepository.GetAll());
		}

		public void UpdateCrew(int id, CrewDTO item)
		{
			crewRepository.Update(id,Mapper.Map<CrewDTO, Crew>(item));
		}
	}
}
