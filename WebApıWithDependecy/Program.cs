using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAp�WithDependecy.Services;
using WebAp�WithDependecy.Services.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<Icrudservices,CrudServices>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SutudentContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection"));
});

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
