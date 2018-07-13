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
    public class TakeOffService : ITakeOffService
    {
		private ITakeOffRepository takeOffRepo;

		public TakeOffService(ITakeOffRepository takeOffRepo)
		{
			this.takeOffRepo = takeOffRepo;
		}

		public void CreateTakeOff(TakeOffDTO item)
		{
			takeOffRepo.Create(Mapper.Map<TakeOffDTO, TakeOff>(item));
		}

		public void DeleteTakeOffById(int id)
		{
			takeOffRepo.Delete(id);
		}

		public TakeOffDTO GetTakeOffById(int id)
		{
			return Mapper.Map<TakeOff,TakeOffDTO>(takeOffRepo.Get(id));
		}

		public List<TakeOffDTO> GetTakeOffCollection()
		{
			return Mapper.Map<List<TakeOff>,List<TakeOffDTO>>(takeOffRepo.GetAll());
		}

		public void UpdateTakeOff(int id, TakeOffDTO item)
		{
			takeOffRepo.Update(id, Mapper.Map<TakeOffDTO, TakeOff>(item));
		}
	}
}
