using CarRental.Entities;
using CarRental.Services;
using CarRental.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add CORS policy
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });

            // Add DbContext service

            builder.Services.AddDbContext<CarRentalDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("CarRentalConnectionString")));

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IRentalService, RentalService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}