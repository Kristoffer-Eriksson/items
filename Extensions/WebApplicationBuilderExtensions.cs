﻿using System.Reflection;
using items.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace items.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder SetupDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = Environment.GetEnvironmentVariable("NPGSQL_CONNECTION_STRING") 
                               ?? "Server=localhost;Port=8787;Database=postgres;Username=postgres;Password=demo";
        
        Console.WriteLine($"Connecting to postgresql with connection string: {connectionString}");
        builder.Services.AddDbContext<ItemDbContext>(options => 
            options.UseNpgsql(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(ItemDbContext).GetTypeInfo().Assembly.GetName().Name);
                sqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "dbo");
            }));

        return builder;
    }
}