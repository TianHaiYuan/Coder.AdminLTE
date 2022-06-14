using GrpcService1.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlSugar.ORM;
using SqlSugar.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService1
{
    public class Startup
    {

        readonly private IConfiguration _Configuration;
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddScoped<StudentService>();
            DbContext.ConnStringDic = new Dictionary<string, string>()
            {                
                { "AccountDb",_Configuration.GetConnectionString("AccountDb") },
                { "OrderDb", _Configuration.GetConnectionString("OrderDb") },
            };
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterAPI>();
                endpoints.MapGrpcService<StudentAPI>();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
