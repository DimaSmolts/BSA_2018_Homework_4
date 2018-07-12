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
		private List<Plane> crews = new List<Plane>();

		public PlaneRepository()
		{
			using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\planes.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				crews = (List<Plane>)serializer.Deserialize(file, typeof(List<Plane>));
			}
		}

		public void SaveChanges()
		{
			File.WriteAllText(Environment.CurrentDirectory + @"\Data\planes.json",
				JsonConvert.SerializeObject(crews));
		}

		public IEnumerable<Plane> GetAll()
		{
			return crews;
		}

		public Plane Get(int id)
		{
			return crews.First(t => t.Id == id);
		}

		public void Delete(int id)
		{
			Plane temp = crews.FirstOrDefault(t => t.Id == id);
			if (temp != null)
				crews.Remove(temp);
			SaveChanges();
		}

		public void Create(Plane item)
		{
			crews.Add(item);
			SaveChanges();
		}

		public void Update(int id, Plane item)
		{
			Plane temp = crews.Find(t => t.Id == id);
			if (temp != null)
			{
				crews.Remove(temp);
				crews.Add(item);
			}
			SaveChanges();
		}
	}
}
