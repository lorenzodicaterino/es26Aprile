
using Esercitazione26Aprile.Models;
using Esercitazione26Aprile.Repository;
using Esercitazione26Aprile.Service;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione26Aprile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Esercitazione26AprileContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddScoped<UtenteRepository>();
            builder.Services.AddScoped<UtenteService>();
            builder.Services.AddScoped<RistoranteRepository>();
            builder.Services.AddScoped<RistoranteService>();
            builder.Services.AddScoped<PiattoRepository>();
            builder.Services.AddScoped<PiattoService>();

            var app = builder.Build();

            app.UseCors(builder =>
                 builder
                 .WithOrigins("*")
                 .AllowAnyMethod()
                 .AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
