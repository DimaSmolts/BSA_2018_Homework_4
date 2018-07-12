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
    public class PlaneRepository : IPlaneRepository
    {
		private List<Plane> planes = new List<Plane>();

		public PlaneRepository()
		{
			using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\planes.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				planes = (List<Plane>)serializer.Deserialize(file, typeof(List<Plane>));
			}
		}

		public void SaveChanges()
		{
			File.WriteAllText(Environment.CurrentDirectory + @"\Data\planes.json",
				JsonConvert.SerializeObject(planes));
		}

		public List<Plane> GetAll()
		{
			return planes;
		}

		public Plane Get(int id)
		{
			return planes.First(t => t.Id == id);
		}

		public void Delete(int id)
		{
			Plane temp = planes.FirstOrDefault(t => t.Id == id);
			if (temp != null)
				planes.Remove(temp);
			SaveChanges();
		}

		public void Create(Plane item)
		{
			planes.Add(item);
			SaveChanges();
		}

		public void Update(int id, Plane item)
		{
			Plane temp = planes.Find(t => t.Id == id);
			if (temp != null)
			{
				planes.Remove(temp);
				planes.Add(item);
			}
			SaveChanges();
		}
	}
}
