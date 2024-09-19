using ToolMonitoringServices.Controllers;
using ToolMonitoringServices.DataAccess;
using ToolMonitoringServices.Services;
using Microsoft.EntityFrameworkCore;
using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.DataAccess.Repository;
using ToolMonitoringService.DataAccess.Repository;
using ToolMonitoringService.Controllers;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using Serilog.Events;



namespace ToolMonitoringServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            //Logger service
            Log.Logger = new LoggerConfiguration().MinimumLevel
              .Information().WriteTo.File("C:\\TEMP\\Log.txt", rollingInterval: RollingInterval.Hour).CreateLogger();

            Log.Logger = new LoggerConfiguration().MinimumLevel
           .Error().WriteTo.File("C:\\TEMP\\LogError.txt", rollingInterval: RollingInterval.Hour).CreateLogger();
           
            
            /*  Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .Enrich.FromLogContext()

// for debug file sink I want the override to be Debug
           .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Debug)

            .WriteTo.File("debug.txt", restrictedToMinimumLevel: LogEventLevel.Debug)*/

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "joinedTableHealth", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Jwt Authorized",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {

                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });


            // Add JWT authentication
            // Configure JWT authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {   //It will generate the token
                       ValidateIssuer = true,

                       //check if the reciever is authorized or not
                       ValidateAudience = true,

                       //validate the expiry of token
                       ValidateLifetime = true,


                       ValidateIssuerSigningKey = true,
                       ValidIssuer = builder.Configuration["Jwt:Issuer"],
                       ValidAudience = builder.Configuration["Jwt:Audience"],

                       //validate signature of the token
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                   };
               });


            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure()));

            // Configure CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",

                    builder =>
                    {
                        builder.WithOrigins("http://example.com", "http://anotherdomain.com", "http://localhost:3002", "http://localhost:3001", "http://localhost:3000", "http://localhost:7074/").AllowAnyHeader().AllowAnyMethod();

                    });
            });

            // Register the AppDbContext and repositories
            builder.Services.AddScoped<AppDbContext>();

            //Get Regions
            builder.Services.AddScoped<IGetRegionsRepository, GetRegionsRepository>();
            builder.Services.AddScoped<IGetRegionsService, GetRegionsService>();
            builder.Services.AddScoped<GetRegionsController>();

            //For toolList
            builder.Services.AddScoped<IGetToolListRepository, GetToolListRepository>();
            builder.Services.AddScoped<IGetToolListService, GetToolListService>();
            //builder.Services.AddScoped<IGetToolDetailsRepository, GetToolListRepository>();
            builder.Services.AddScoped<GetToolListController>();

            //ToolCategoryCount
            builder.Services.AddScoped<IGetToolCategoryCountService, GetToolCategoryCountService>();
            builder.Services.AddScoped<IGetToolCategoryCountRepository, GetToolCategoryCountRepository>();
            builder.Services.AddScoped<GetToolCategoryCountController>();

            //ToolDetails
            builder.Services.AddScoped<IGetToolDetailsService, GetToolDetailsService>();
            builder.Services.AddScoped<IGetToolDetailsRepository, GetToolDetailsRepository>();
            builder.Services.AddScoped<GetToolDetailsController>();

            //ToolHierarchy
            builder.Services.AddScoped<IGetToolHierarchyRepository, GetToolHierarchyRepository>();
            builder.Services.AddScoped<IGetToolHierarchyService, GetToolHierarchyService>();
            builder.Services.AddScoped<GetToolHierarchyController>();

            //ToolCategories
            builder.Services.AddScoped<IGetCategoriesRepository, GetCategoriesRepository>();
            builder.Services.AddScoped<IGetCategoriesService, GetCategoriesService>();
            builder.Services.AddScoped<GetCategoriesController>();

            //Location
            builder.Services.AddScoped<IGetLocationRepository, GetLocationRepository>();
            builder.Services.AddScoped<IGetLocationService, GetLocationService>();
            builder.Services.AddScoped<GetLocationController>();

           // builder.Services.AddControllers().AddNewtonsoftJson();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
                });
                //app.UseSwaggerUI();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();


            app.UseHttpsRedirection();
            // Use CORS policy

            app.UseCors("MyAllowSpecificOrigins");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}