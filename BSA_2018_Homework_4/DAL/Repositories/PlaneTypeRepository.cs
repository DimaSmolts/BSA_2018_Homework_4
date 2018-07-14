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
    public class PlaneTypeRepository : IPlaneTypeRepository
    {
		private List<PlaneType> planetypes = new List<PlaneType>();

		public PlaneTypeRepository()
		{
		//	using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\planetypes.json"))
			//{
		//		JsonSerializer serializer = new JsonSerializer();
		//		planetypes = (List<PlaneType>)serializer.Deserialize(file, typeof(List<PlaneType>));
		//	}
		}

		public void SaveChanges()
		{
		//	File.WriteAllText(Environment.CurrentDirectory + @"\Data\planetypes.json",
			//	JsonConvert.SerializeObject(planetypes));
		}

		public List<PlaneType> GetAll()
		{
			return planetypes;
		}

		public PlaneType Get(int id)
		{
			return planetypes.FirstOrDefault(t => t.Id == id);
		}

		public void Delete(int id)
		{
			PlaneType temp = planetypes.FirstOrDefault(t => t.Id == id);
			if (temp != null)
			{
				planetypes.Remove(temp);
				SaveChanges();
			}				
		}

		public void Create(PlaneType item)
		{
			planetypes.Add(item);
			SaveChanges();
		}

		public void Update(int id, PlaneType item)
		{
			PlaneType temp = planetypes.FirstOrDefault(t => t.Id == id);
			if (temp != null)
			{
				temp.Id = item.Id;
				temp.Model = item.Model;
				temp.Places = item.Places;
				temp.CarryCapacity = item.CarryCapacity;

				SaveChanges();
			}
		}
	}
}
