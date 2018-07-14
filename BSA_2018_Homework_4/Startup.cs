using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BSA_2018_Homework_4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddSingleton<BL.ServiceInterfaces.IPlaneService, BL.Services.PlaneService>();
			services.AddSingleton<DAL.RepositoryInterfaces.IPlaneRepository, DAL.Repositories.PlaneRepository>();

			services.AddSingleton<BL.ServiceInterfaces.ITicketService, BL.Services.TicketService>();
			services.AddSingleton<DAL.RepositoryInterfaces.ITicketRepository, DAL.Repositories.TicketRepository>();

			services.AddSingleton<BL.ServiceInterfaces.IPilotService, BL.Services.PilotService>();
			services.AddSingleton<DAL.RepositoryInterfaces.IPilotRepository, DAL.Repositories.PilotRepository>();

			services.AddSingleton<BL.ServiceInterfaces.IStewardessService, BL.Services.StewardessService>();
			services.AddSingleton<DAL.RepositoryInterfaces.IStewardessRepository, DAL.Repositories.StewardessRepository>();

			services.AddSingleton<BL.ServiceInterfaces.ITakeOffService, BL.Services.TakeOffService>();
			services.AddSingleton<DAL.RepositoryInterfaces.ITakeOffRepository, DAL.Repositories.TakeOffRepository>();

			services.AddSingleton<BL.ServiceInterfaces.IPlaneTypeService, BL.Services.PlaneTypeService>();
			services.AddSingleton<DAL.RepositoryInterfaces.IPlaneTypeRepository, DAL.Repositories.PlaneTypeRepository>();

			services.AddSingleton<BL.ServiceInterfaces.IFlightService, BL.Services.FlightService>();
			services.AddSingleton<DAL.RepositoryInterfaces.IFlightRepository, DAL.Repositories.FlightRepository>();

			services.AddSingleton<BL.ServiceInterfaces.ICrewService, BL.Services.CrewService>();
			services.AddSingleton<DAL.RepositoryInterfaces.ICrewRepository, DAL.Repositories.CrewRepository>();


			var connection = @"Server=DESKTOP-DMYTRO\SQLEXPRESS;Initial Catalog=Academy;Trusted_Connection=True;ConnectRetryCount=0";
			services.AddDbContext<DAL.MyContext>(options => options.UseSqlServer(connection));



			services.AddSingleton<DAL.IUnitOfWork, DAL.UnitOfWork>();





			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<DAL.Models.Plane, DTOs.PlaneDTO>();
				cfg.CreateMap<DTOs.PlaneDTO, DAL.Models.Plane>();

				cfg.CreateMap<DAL.Models.Flight, DTOs.FlightDTO>();
				cfg.CreateMap<DTOs.FlightDTO, DAL.Models.Flight>();

				cfg.CreateMap<DAL.Models.Ticket, DTOs.TicketDTO>();
				cfg.CreateMap<DTOs.TicketDTO, DAL.Models.Ticket>();






				cfg.CreateMap<DAL.Models.Crew, DTOs.CrewDTO>();
					//.ForMember( cDTO => cDTO.StewardessIds,
							//	c => c.MapFrom(from i in ));
				cfg.CreateMap<DTOs.CrewDTO, DAL.Models.Crew>();






				cfg.CreateMap<DAL.Models.Pilot, DTOs.PilotDTO>();
				cfg.CreateMap<DTOs.PilotDTO, DAL.Models.Pilot>();

				cfg.CreateMap<DAL.Models.Stewardess, DTOs.StewardessDTO>();
				cfg.CreateMap<DTOs.StewardessDTO, DAL.Models.Stewardess>();

				cfg.CreateMap<DAL.Models.TakeOff, DTOs.TakeOffDTO>();
				cfg.CreateMap<DTOs.TakeOffDTO, DAL.Models.TakeOff>();

				cfg.CreateMap<DAL.Models.PlaneType, DTOs.PlaneTypeDTO>();
				cfg.CreateMap<DTOs.PlaneTypeDTO, DAL.Models.PlaneType>();
			});

			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<DAL.MyContext>();
				context.Database.Migrate();
			}

			app.UseMvc();
        }
    }
}
