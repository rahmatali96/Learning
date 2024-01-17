using Learning.DbContextSetup;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<LearningDbContext>(options => options.UseSqlServer("Data Source=HP\\SQLEXPRESS;Initial Catalog=learning;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False"));
builder.Services.AddDbContext<LearningDbContext>(options =>
            options.UseSqlite("Data Source=learning.db;"));

var app = builder.Build();

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
