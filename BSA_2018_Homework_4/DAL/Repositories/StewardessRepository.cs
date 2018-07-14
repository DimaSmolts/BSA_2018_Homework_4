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
    public class StewardessRepository : IStewardessRepository
    {
		private List<Stewardess> stewardesses = new List<Stewardess>();

		public StewardessRepository()
		{
		//	using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\stewardesses.json"))
		//	{
		//		JsonSerializer serializer = new JsonSerializer();
		//		stewardesses = (List<Stewardess>)serializer.Deserialize(file, typeof(List<Stewardess>));
		//	}
		}

		public void SaveChanges()
		{
			//File.WriteAllText(Environment.CurrentDirectory + @"\Data\stewardesses.json",
			//	JsonConvert.SerializeObject(stewardesses));
		}

		public List<Stewardess> GetAll()
		{
			return stewardesses;
		}

		public Stewardess Get(int id)
		{
			return stewardesses.FirstOrDefault(t => t.Id == id);
		}

		public void Delete(int id)
		{
			Stewardess temp = stewardesses.FirstOrDefault(t => t.Id == id);
			if (temp != null)
			{
				stewardesses.Remove(temp);
				SaveChanges();
			}				
		}

		public void Create(Stewardess item)
		{
			stewardesses.Add(item);
			SaveChanges();
		}

		public void Update(int id, Stewardess item)
		{
			Stewardess temp = stewardesses.FirstOrDefault(t => t.Id == id);
			if (temp != null)
			{
				temp.Id = item.Id;
				temp.Name = item.Name;
				temp.Surname = item.Surname;
				temp.Birth = item.Birth;

				SaveChanges();
			}
		}
	}
}
