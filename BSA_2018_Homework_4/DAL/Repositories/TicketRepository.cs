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
    public class TicketRepository : ITicketRepository
    {
		private List<Ticket> tickets = new List<Ticket>();

		public TicketRepository()
		{
			using (StreamReader file = File.OpenText(Environment.CurrentDirectory + @"\Data\tickets.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				tickets = (List<Ticket>)serializer.Deserialize(file, typeof(List<Ticket>));
			}
		}

		public void SaveChanges()
		{
			File.WriteAllText(Environment.CurrentDirectory + @"\Data\tickets.json",
				JsonConvert.SerializeObject(tickets));
		}

		public IEnumerable<Ticket> GetAll()
		{
			return tickets;
		}

		public Ticket Get(int id)
		{
			return tickets.First(t => t.Id == id);
		}

		public void Delete(int id)
		{
			Ticket temp = tickets.FirstOrDefault(t => t.Id == id);
			if (temp != null)
				tickets.Remove(temp);
			SaveChanges();
		}

		public void Create(Ticket item)
		{
			tickets.Add(item);
			SaveChanges();
		}

		public void Update(int id, Ticket item)
		{
			Ticket temp = tickets.Find(t => t.Id == id);
			if (temp != null)
			{
				tickets.Remove(temp);
				tickets.Add(item);
			}
			SaveChanges();
		}
	}
}
