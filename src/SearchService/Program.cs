using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
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

app.UseAuthorization();
app.MapControllers();

await DB.InitAsync("SearchDB", MongoClientSettings.FromConnectionString(builder.Configuration.GetConnectionString("MongoDbConnection")));
await DB.Index<Item>().Key(a => a.Make, KeyType.Text)
.Key(a => a.Model, KeyType.Text)
.Key(a => a.Color, KeyType.Text).CreateAsync();

app.Run();

