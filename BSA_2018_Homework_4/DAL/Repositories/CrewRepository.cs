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
    public class CrewRepository : ICrewRepository
    {
		private List<Crew> crews = new List<Crew>();

		public CrewRepository()
		{
		//	using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\crews.json"))
			//{
			//	JsonSerializer serializer = new JsonSerializer();
			//	crews = (List<Crew>)serializer.Deserialize(file, typeof(List<Crew>));
			//}
		}

		public void SaveChanges()
		{
		//	File.WriteAllText(Environment.CurrentDirectory + @"\Data\crews.json",
			//	JsonConvert.SerializeObject(crews));
		}

		public List<Crew> GetAll()
		{
			return crews;
		}

		public Crew Get(int id)
		{
			return crews.FirstOrDefault(t => t.Id == id);
		}

		public void Delete(int id)
		{
			Crew temp = crews.FirstOrDefault(t => t.Id == id);
			if (temp != null)
			{
				crews.Remove(temp);
				SaveChanges();
			}				
		}

		public void Create(Crew item)
		{
			crews.Add(item);
			SaveChanges();
		}

		public void Update(int id, Crew item)
		{
			Crew temp = crews.FirstOrDefault(t => t.Id == id);
			if (temp != null)
			{
				temp.Id = item.Id;
				temp.PilotId = item.PilotId;
				temp.StewardessIds = item.StewardessIds;

				SaveChanges();
			}			
		}
	}
}
