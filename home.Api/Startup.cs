using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using home.Api.Data;
using home.Api.Servcie;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace home.Api
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
            services.AddControllers()
                    .AddXmlDataContractSerializerFormatters()//兼容XML格式
                    .ConfigureApiBehaviorOptions(setup => setup.InvalidModelStateResponseFactory
                     = context => {
                         var details = new ValidationProblemDetails(context.ModelState)
                         {
                             Type = "http://www.baidu.com",
                             Title = "实体验证失败",
                             Status = StatusCodes.Status422UnprocessableEntity,
                             Detail = "请看详细信息",
                             Instance = context.HttpContext.Request.Path,
                             
                         };
                         details.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);
                         return new UnprocessableEntityObjectResult(details);
                     });
            services.AddDbContext<HomeContext>(option => option.UseSqlite("Data Source=Home.db"));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
