using MongoDB.Driver.Core.Configuration;
using MovieStore.Api.Infrastructure.Database;
using MovieStore.Api.Repositories;
using MovieStore.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbConnectionSettings>(builder.Configuration.GetSection(DbConnectionSettings.DatabaseConfig));
builder.Services.AddSingleton<MovieRepository>();
builder.Services.AddSingleton<MovieService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();