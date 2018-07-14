using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using BSA_2018_Homework_4.DAL.Repositories;

namespace BSA_2018_Homework_4.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
		private ICrewRepository crewRepository;
		private IFlightRepository flightRepository;
		private IPilotRepository pilotRepository;
		private IPlaneRepository planeRepository;
		private IPlaneTypeRepository planeTypeRepository;
		private IStewardessRepository stewardessRepository;
		private ITakeOffRepository takeOffRepository;
		private ITicketRepository ticketRepository;

		public UnitOfWork(ICrewRepository crewRepository,
							IFlightRepository flightRepository,
							IPilotRepository pilotRepository,
							IPlaneRepository planeRepository,
							IPlaneTypeRepository planeTypeRepository,
							IStewardessRepository stewardessRepository,
							ITakeOffRepository takeOffRepository,
							ITicketRepository ticketRepository)
		{
			this.crewRepository = crewRepository;
			this.flightRepository = flightRepository;
			this.pilotRepository = pilotRepository;
			this.planeRepository = planeRepository;
			this.planeTypeRepository = planeTypeRepository;
			this.stewardessRepository = stewardessRepository;
			this.takeOffRepository = takeOffRepository;
			this.ticketRepository = ticketRepository;
		}

		public ICrewRepository CrewRepository
		{
			get
			{
				if (crewRepository == null)
					crewRepository = new CrewRepository();
				return crewRepository;
			}
		}
		public IFlightRepository FlightRepository
		{
			get
			{
				if (flightRepository == null)
					flightRepository = new FlightRepository();
				return flightRepository;
			}
		}
		public IPilotRepository PilotRepository
		{
			get
			{
				if (pilotRepository == null)
					pilotRepository = new PilotRepository();
				return pilotRepository;
			}
		}
		public IPlaneRepository PlaneRepository
		{
			get
			{
				if (planeRepository == null)
					planeRepository = new PlaneRepository();
				return planeRepository;
			}
		}
		public IPlaneTypeRepository PlaneTypeRepository
		{
			get
			{
				if (planeTypeRepository == null)
					planeTypeRepository = new PlaneTypeRepository();
				return planeTypeRepository;
			}
		}
		public IStewardessRepository StewardessRepository
		{
			get
			{
				if (stewardessRepository == null)
					stewardessRepository = new StewardessRepository();
				return stewardessRepository;
			}
		}
		public ITakeOffRepository TakeOffRepository
		{
			get
			{
				if (takeOffRepository == null)
					takeOffRepository = new TakeOffRepository();
				return takeOffRepository;
			}
		}
		public ITicketRepository TicketRepository
		{
			get
			{
				if (ticketRepository == null)
					ticketRepository = new TicketRepository();
				return ticketRepository;
			}
		}
	}
}
