using Microsoft.EntityFrameworkCore;
using System;
using UserService.Database;
using UserService.Interfaces;
using UserService.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=OnlineStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddTransient<IUser, User>();

app.MapGet("/", () => "Hello World!");

app.Run();
