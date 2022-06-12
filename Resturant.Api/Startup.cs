using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Resturant.Api.Core;
using Resturant.Api.Extensions;
using Resturant.Application;
using Resturant.Application.Logging;
using Resturant.Application.UseCases.Commands;
using Resturant.Application.UseCases.Queries;
using Resturant.DataAccess;
using Resturant.Implementation;
using Resturant.Implementation.Logging;
using Resturant.Implementation.UseCases.Commands;
using Resturant.Implementation.UseCases.Queries;
using Resturant.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Api
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

            var settings = new AppSettings();

            Configuration.Bind(settings);

            services.AddSingleton(settings);
            services.AddApplicationUser();
            services.AddJwt(settings);

            services.AddTransient(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-KS3EQ1L\SQLEXPRESS;Initial Catalog=resturantAsp;Integrated Security=True").UseLazyLoadingProxies();

                var options = optionsBuilder.Options;

                return new ResturantDbContext(options);
            });

            #region Queries
            services.AddTransient<IFindSpecialtyQuery, EFFindSpecialtyQuery>();
            services.AddTransient<IGetCategoriesQuery, EFGetCategoriesQuery>();
            services.AddTransient<IGetOrdersQuery, EFGetOrdersQuery>();
            services.AddTransient<IGetSpecialtiesQuery, EFGetSpecialtiesQuery>();
            services.AddTransient<IGetUseCaseLogsQuery, GetUseCaseLogsQuery>();
            #endregion

            #region Commands
            services.AddTransient<ICreateCategoryCommand, EFCreateCategoryCommand>();
            services.AddTransient<ICreateIngredientCommand, EFCreateIngredientCommand>();
            services.AddTransient<ICreateOrderCommand, EFCreateOrderCommand>();
            services.AddTransient<ICreateSpecialtyCommand, EFCreateSpecialtyCommand>();
            services.AddTransient<IRegisterUserCommand, EFRegisterUserCommand>();
            services.AddTransient<IDeleteIngredientCommand, EFDeleteIngredientCommand>();
            #endregion

            #region Validators
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<CreateIngredientValidator>();
            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<CreateSpecialtyValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<SearchUseCaseLogsValidator>();
            #endregion

            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IUseCaseLogger>(x => new SpUseCaseLogger(settings.ConnString));
            services.AddTransient<UseCaseHandler>();

            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Resturant.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Resturant.Api v1"));
            }

            app.UseRouting();
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
