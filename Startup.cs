using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationWithMediatr_task.Application.Interfaces;
using ValidationWithMediatr_task.Application.Models.Query;
using ValidationWithMediatr_task.Application.UseCases.Customer.Command.CreateCustomer;
using ValidationWithMediatr_task.Application.UseCases.Customer.Queries.GetCustomer;
using ValidationWithMediatr_task.Application.UseCases.Payment.Command.CreatePayment;
using ValidationWithMediatr_task.Application.UseCases.Payment.Queries.GetPayment;
using ValidationWithMediatr_task.Application.UseCases.Merchant.Command.CreateMerchant;
using ValidationWithMediatr_task.Application.UseCases.Merchant.Queries.GetMerchant;
using ValidationWithMediatr_task.Application.UseCases.Product.Command.CreateProduct;
using ValidationWithMediatr_task.Application.UseCases.Product.Queries.GetProduct;
using ValidationWithMediatr_task.Domain.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ValidationWithMediatr_task.Infrastructure.Presistence;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


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
            services.AddDbContext<dbContext>(option => option.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=sayangkamu;Database=dbtokosederhana"));
            services.AddControllers();

            services.AddMvc().AddFluentValidation();

            services.AddMediatR(typeof(GetCustomerQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetPaymentQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetMerchantQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetProdcutQueryHandler).GetTypeInfo().Assembly);

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option => {
                option.SaveToken = false;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ini secret key")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddTransient<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>()
                .AddTransient<IValidator<CreatePaymentCommand>, CreatePaymentCommandValidator>()
                .AddTransient<IValidator<CreateMerchantCommand>, CreateMerchantCommandValidator>()
                .AddTransient<IValidator<CreateProductCommand>, CreateProductCommandValidator>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidator<,>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
