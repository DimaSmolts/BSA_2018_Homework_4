using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BSA_2018_Homework_4.DAL.Models;

namespace BSA_2018_Homework_4.DAL
{
    public class MyContext : DbContext
    {
		public DbSet<Crew> Crew { get; set; }
		public DbSet<Flight> Flight { get; set; }
		public DbSet<TakeOff> TakeOff { get; set; }
		public DbSet<Ticket> Ticket { get; set; }
		public DbSet<Stewardess> Stewardess { get; set; }
		public DbSet<Pilot> Pilot { get; set; }
		public DbSet<Plane> PLane { get; set; }
		public DbSet<PlaneType> PlaneType { get; set; }

		public MyContext(DbContextOptions<MyContext> options) : base(options)
		{
			//Database.Se
		}

	}
}
