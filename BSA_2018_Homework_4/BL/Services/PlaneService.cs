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
    public class PlaneService : IPlaneService
    {
		private IPlaneRepository planeRepo;

		public PlaneService(IPlaneRepository planeRepo)
		{
			this.planeRepo = planeRepo;
		}

		public List<PlaneDTO> GetPlaneCollection()
		{
			return Mapper.Map<List<Plane>, List<PlaneDTO>>(planeRepo.GetAll());
		}
		public PlaneDTO GetPlaneById(int id)
		{
			return Mapper.Map<Plane,PlaneDTO>(planeRepo.Get(id));
		}
		public void DeletePlaneById(int id)
		{
			planeRepo.Delete(id);
		}
		public void CreatePlane(PlaneDTO item)
		{
			planeRepo.Create(Mapper.Map<PlaneDTO, Plane>(item));
		}
		public void UpdatePlane(int id, PlaneDTO item)
		{
			planeRepo.Update(id, Mapper.Map<PlaneDTO, Plane>(item));
		}

	}
}
