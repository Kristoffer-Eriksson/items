using items.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.SetupDatabase();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
