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
    public class TakeOffRepository : ITakeOffRepository
    {
		private List<TakeOff> takeoffs = new List<TakeOff>();

		public TakeOffRepository()
		{
			using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\takeoffs.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				takeoffs = (List<TakeOff>)serializer.Deserialize(file, typeof(List<TakeOff>));
			}
		}

		public void SaveChanges()
		{
			File.WriteAllText(Environment.CurrentDirectory + @"\Data\takeoffs.json",
				JsonConvert.SerializeObject(takeoffs));
		}

		public List<TakeOff> GetAll()
		{
			return takeoffs;
		}

		public TakeOff Get(int id)
		{
			return takeoffs.First(t => t.Id == id);
		}

		public void Delete(int id)
		{
			TakeOff temp = takeoffs.FirstOrDefault(t => t.Id == id);
			if (temp != null)
				takeoffs.Remove(temp);
			SaveChanges();
		}

		public void Create(TakeOff item)
		{
			takeoffs.Add(item);
			SaveChanges();
		}

		public void Update(int id, TakeOff item)
		{
			TakeOff temp = takeoffs.Find(t => t.Id == id);
			if (temp != null)
			{
				takeoffs.Remove(temp);
				takeoffs.Add(item);
			}
			SaveChanges();
		}
	}
}
