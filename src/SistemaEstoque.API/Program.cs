using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.Ports;
using SistemaEstoque.Application.UseCases;
using SistemaEstoque.Infrastructure.Persistence;
using SistemaEstoque.Infrastructure.Repositories;

namespace SistemaEstoque.API;

public sealed class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<CreateUserUseCase>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        if (app.Environment.IsProduction())
        {
            app.UseHttpsRedirection();
        }

        app.MapControllers();

        app.Run();

    }
}
