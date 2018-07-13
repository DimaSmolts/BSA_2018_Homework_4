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
    public class StewardessService : IStewardessService
    {
		private IStewardessRepository stewardessRepo;

		public StewardessService(IStewardessRepository stewardessRepo)
		{
			this.stewardessRepo = stewardessRepo;
		}

		public void CreateStewardess(StewardessDTO item)
		{
			stewardessRepo.Create(Mapper.Map<StewardessDTO, Stewardess>(item));
		}

		public void DeleteStewardessById(int id)
		{
			stewardessRepo.Delete(id);
		}

		public StewardessDTO GetStewardessById(int id)
		{
			return Mapper.Map<Stewardess,StewardessDTO>(stewardessRepo.Get(id));
		}

		public List<StewardessDTO> GetStewardessCollection()
		{
			return Mapper.Map<List<Stewardess>,List<StewardessDTO>>(stewardessRepo.GetAll());
		}

		public void UpdateStewardess(int id, StewardessDTO item)
		{
			stewardessRepo.Update(id,Mapper.Map<StewardessDTO,Stewardess>(item));
		}
	}
}
