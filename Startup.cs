using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ValidationWithMediatr_task.Models;
using FluentValidation.AspNetCore;
using FluentValidation;
using ValidationWithMediatr_task.Validator;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ValidationWithMediatr_task
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
            services.AddDbContext<dbContext>(options => options.UseNpgsql("Host=localhost;Database=dbtokosederhana;Username=postgres;Password=docker"));
            services.AddControllers();
            services.AddMvc()
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CustomerValidator>())
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CustomerpayValidator>())
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductValidator>())
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<MerchantValidator>());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidator<,>));
            // services.AddAuthentication( options => {
            //     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            // }).AddJwtBearer(option => {
            //     option.RequireHttpsMetadata = false;
            //     option.TokenValidationParameters = new TokenValidationParameters{
            //         ValidateIssuerSigningKey = true,
            //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ini secret key nya harus panjang")),
            //         ValidateIssuer = false,
            //         ValidateAudience = false,
            //     };
            // });
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
