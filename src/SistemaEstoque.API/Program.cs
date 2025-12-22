using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SistemaEstoque.API.Authorization;
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
        builder.Services.AddScoped<IAuthRepository, AuthRepository>();
        builder.Services.AddScoped<VerifyAdminkeyUseCase>();
        builder.Services.AddScoped<CreateUserUseCase>();

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminKeyRequirement", policy =>
                 policy.Requirements.Add(new AdminKeyRequirement())
            );
        });

        builder.Services.AddScoped<IAuthorizationHandler, AdminKeyAuthorizationAdapter>();

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
