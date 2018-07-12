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
    public class PlaneTypeService : IPlaneTypeService
    {
		private IPlaneTypeRepository planeTypeRepository;

		public PlaneTypeService(IPlaneTypeRepository planeTypeRepository)
		{
			this.planeTypeRepository = planeTypeRepository;
		}

		public void CreatePlaneType(PlaneTypeDTO item)
		{
			planeTypeRepository.Create(Mapper.Map<PlaneTypeDTO,PlaneType>(item));
		}

		public void DeletePlaneType(int id)
		{
			planeTypeRepository.Delete(id);
		}

		public PlaneTypeDTO GetPlaneTypeById(int id)
		{
			return Mapper.Map<PlaneType,PlaneTypeDTO>(planeTypeRepository.Get(id));
		}

		public List<PlaneTypeDTO> GetPlaneTypeCollection()
		{
			return Mapper.Map<List<PlaneType>, List<PlaneTypeDTO>>(planeTypeRepository.GetAll());
		}

		public void UpdatePlaneType(int id, PlaneTypeDTO item)
		{
			planeTypeRepository.Update(id, Mapper.Map<PlaneTypeDTO, PlaneType>(item));
		}
	}
}
