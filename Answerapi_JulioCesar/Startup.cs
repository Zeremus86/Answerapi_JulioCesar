using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Answerapi_JulioCesar.Models;
using Microsoft.EntityFrameworkCore;

namespace Answerapi_JulioCesar
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

            services.AddControllers();
            //AGREGAR LA CADENA DE CONEXIÓN PARA EL PROYECTO
            //TODO: DEBEMOS GUARDAR ESTA CADENA POR MEDIO DE USERSECRETS.JSON
            //Y NO POR MEDIO DE APPSETTINGS.JSON
            var conn = @"SERVER=.\SQLEXPRESS;DATABASE= AnswersDB;User Id=AnswerUser; Password=1234";
            services.AddDbContext<AnswersDBContext>(options => options.UseSqlServer(conn));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Answerapi_JulioCesar", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Answerapi_JulioCesar v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            //TODO: REVISAR SI HACE FALTA ALGUNA CONFG PARA USO DE JWT
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
