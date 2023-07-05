using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SendEmalWebApi.Data;
using SendEmalWebApi.Model;
using SendEmalWebApi.Repositories;
using SendEmalWebApi.Services.EmailSenderService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SenderContext>(conf =>
{
    conf.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddSingleton<IEmailSenderService, EmailSenderService>();
builder.Services.AddScoped<IRepository<Log>, LogRepository>();

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
