using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_2018_Homework_4.DAL.Models;
using BSA_2018_Homework_4.DAL.RepositoryInterfaces;
using Newtonsoft.Json;
using System.IO;

namespace BSA_2018_Homework_4.DAL.Repositories
{
    public class FlightRepository : IFlightRepository
    {
		private List<Flight> flights = new List<Flight>();

		public FlightRepository()
		{
			using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\flights.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				flights = (List<Flight>)serializer.Deserialize(file, typeof(List<Flight>));
			}
		}

		public void SaveChanges()
		{
			File.WriteAllText(Environment.CurrentDirectory + @"\Data\flights.json",
				JsonConvert.SerializeObject(flights));
		}

		public IEnumerable<Flight> GetAll()
		{
			return flights;
		}

		public Flight Get(int id)
		{
			return flights.First(t => t.FlightNum == id);
		}

		public void Delete(int id)
		{
			Flight temp = flights.FirstOrDefault(t => t.FlightNum == id);
			if (temp != null)
				flights.Remove(temp);
			SaveChanges();
		}

		public void Create(Flight item)
		{
			flights.Add(item);
			SaveChanges();
		}

		public void Update(int id,Flight item)
		{
			Flight temp = flights.Find(t => t.FlightNum == id);
			if (temp != null)
			{
				flights.Remove(temp);
				flights.Add(item);
			}
			SaveChanges();
		}
	}
}
