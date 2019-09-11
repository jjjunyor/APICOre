using CorporateCore.Domain.Interface.Repository;
using CorporateCore.Domain.Interface.Services;
using CorporateCore.Domain.Service;
using CorporateCore.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            string connectionString = Configuration.GetConnectionString("Default");

            services.AddDbContext<CorporateCore.Infrastructure.Data.CorporateContext>(options =>
              options.UseSqlServer(connectionString)
            );

            services.AddTransient<ITipoOcorrenciaService, TipoOcorrenciaService>();
            services.AddTransient<ITipoOcorrenciaRepository, TipoOcorrenciaRepository>();
            services.AddTransient<ITipoSolucaoRepository, TipoSolucaoRepository>();
            services.AddTransient<IAreaAfetadaRepository, AreaAfetadaRepository>();
            services.AddTransient<ITipoDiagnosticoTipoSolucaoRepository, TipoDiagnosticoTipoSolucaoRepository>();
            services.AddTransient<ITipoDiagnosticoAreaAfetadaRepository, TipoDiagnosticoAreaAfetadaRepository>();
            services.AddTransient<ITipoOcorrenciaEquipamentoService, TipoOcorrenciaEquipamentoService>();
            services.AddTransient<ITipoOcorrenciaEquipamentoRepository, TipoOcorrenciaEquipamentoRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Corporate Core", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "../..";

                    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Corporate");
                    c.RoutePrefix = "";
                });
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
               {
                   string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : ".";

                   c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Corporate");
                   c.RoutePrefix = "";
               });

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
