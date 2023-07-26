using BryanGabeDAL.Models;
using BryanGabeDAL.Repositories;

namespace BryanGabeAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddScoped<ChaosSoftwareContext>();
        builder.Services.AddScoped<AdminRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

