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
    public class PilotRepository : IPilotRepository
    {
		private List<Pilot> pilots = new List<Pilot>();

		public PilotRepository()
		{
			using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\pilots.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				pilots = (List<Pilot>)serializer.Deserialize(file, typeof(List<Pilot>));
			}
		}

		public void SaveChanges()
		{
			File.WriteAllText(Environment.CurrentDirectory + @"\Data\pilots.json",
				JsonConvert.SerializeObject(pilots));
		}

		public List<Pilot> GetAll()
		{
			return pilots;
		}

		public Pilot Get(int id)
		{
			return pilots.FirstOrDefault(t => t.Id == id);
		}

		public void Delete(int id)
		{
			Pilot temp = pilots.FirstOrDefault(t => t.Id == id);
			if (temp != null)
				pilots.Remove(temp);
			SaveChanges();
		}

		public void Create(Pilot item)
		{
			pilots.Add(item);
			SaveChanges();
		}

		public void Update(int id, Pilot item)
		{
			Pilot temp = pilots.Find(t => t.Id == id);
			if (temp != null)
			{
				pilots.Remove(temp);
				pilots.Add(item);
			}
			SaveChanges();
		}
	}
}
