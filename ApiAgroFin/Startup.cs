using ApiAgroFin.Contratos;
using ApiAgroFin.Contratos.Persistence;
using ApiAgroFin.Contratos.Persistence.GeralPersistence;
using ApiAgroFin.Contratos.Persistence.PessoaPersistence;
using ApiAgroFin.Contratos.Persistence.TituloPersistence;
using ApiAgroFin.Data;
using ApiAgroFin.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace ApiAgroFin {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers().AddNewtonsoftJson(options =>
           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<AppDbContext>(opts => opts
            //.UseLazyLoadingProxies()
            .UseSqlServer(Configuration.GetConnectionString("AgroFin")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<ITituloService, TituloService>();
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<IPessoaPersist, PessoaPersist>();
           services.AddScoped<ITituloPersist, TituloPersist>();

            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiAgroFin", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiAgroFin v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(access => access.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
            );

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
