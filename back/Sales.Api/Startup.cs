using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sales.Api.Helpers;
using Sales.Application.Dtos.Mappers;
using Sales.Infra.Context;
using Sales.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace Sales.Api
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
            services
                .AddMvc(i => i.Filters.Add(typeof(ValidateModelFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<SalesContext>(opt =>
                    opt.UseNpgsql(Configuration.GetConnectionString("Sales")));

            services.AddAutoMapper(s => s.AddProfile(new DtoMapper()));

            InjectionContainer.DoInjection(services);

            services.AddSwaggerGen(c => 
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Gerenciador de Vendas",
                        Version = "v1",
                        Description = "API do Sistema Gerenciador de Vendas",
                        Contact = new Contact
                        {
                            Name = "Ronaldo  Ribeiro",
                            Url = "https://github.com/ronaldosjr/SegImob"
                        }
                    }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(i => i.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gerenciador de Vendas"); });
           
        }

        
    }
}
