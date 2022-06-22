using AutoMapper;
using MazaNetCOreFw.Common.Utils.Cryptos;
using MazaNetCOreFw.TicketingPersistence.Contracts;
using MazaNetCOreFw.TicketingPersistence.Database;
using MazaNetCOreFw.TicketingPersistence.Implementations;
using MazaNetCOreFw.TicketingPersistence.Mapping;
using MazaNetCOreFw.TicketingPersistence.Repository.Implementations;
using MazaNetCOreFw.TicketingPersistence.Repository.Interfaces;
using MazaNetCOreFw.TicketingService.Contracts;
using MazaNetCOreFw.TicketingService.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketing_Webapi
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

           

           

            #region Db Context
            services.AddDbContext<TicketingDbContext>(options =>
            {
                options.UseSqlServer(Cryptography.DecryptUsingSha256(Configuration.GetConnectionString("TicketingConnectionStr")));
            });

            #endregion
        
            #region IoC
            var mappingConfig = new MapperConfiguration(mc =>
            {
                var profiles = new List<Profile>
                {
                    new TicketingProfile(),
                };
                mc.AddProfiles(profiles);


            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<ICodeSequenceRepository, CodeSequenceRepository>();
            services.AddScoped<ITicketConversationRepository, TicketConversationRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ITicketingUnitOfWork, TicketingUnitOfWork>();
            services.AddScoped<IRootTicketingService, RootTicketingService>();
            #endregion
           // services.AddCors(o =>
           //    o.AddPolicy("MyPolicy", builder =>
           //    {
           //        builder.WithOrigins("http://127.0.0.1:8887")
           //                         .AllowAnyHeader()
           //                         .AllowCredentials()
           //                        .AllowAnyMethod();
           //    })
           //);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCors("MyPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(configurePolicy: (options) =>
            {
                options.WithOrigins("http://127.0.0.1:8887")
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .AllowAnyMethod();
            });
            //app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
