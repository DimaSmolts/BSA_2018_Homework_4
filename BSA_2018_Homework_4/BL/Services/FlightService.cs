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
    public class FlightService : IFlightService
    {
		private IFlightRepository flightRepository;

		public FlightService(IFlightRepository flightRepository)
		{
			this.flightRepository = flightRepository;
		}

		public void CreateFlight(FlightDTO item)
		{
			flightRepository.Create(Mapper.Map<FlightDTO, Flight>(item));
		}

		public void DeleteFlightById(int id)
		{
			flightRepository.Delete(id);
		}

		public FlightDTO GetFlightById(int id)
		{
			return Mapper.Map<Flight, FlightDTO>(flightRepository.Get(id)); 
		}

		public List<FlightDTO> GetFlightCollection()
		{
			return Mapper.Map<List<Flight>, List<FlightDTO>>(flightRepository.GetAll());
		}

		public void UpdateFlight(int id, FlightDTO item)
		{
			flightRepository.Update(id,Mapper.Map<FlightDTO, Flight>(item));
		}
	}
}
