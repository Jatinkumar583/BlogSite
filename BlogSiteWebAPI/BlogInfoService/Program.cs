using BlogInfoService.Models;
using BlogInfoService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BlogStoreDBSetting>(builder.Configuration.GetSection(nameof(BlogStoreDBSetting)));

builder.Services.AddSingleton<IBlogStoreDBSetting>(sp=>sp.GetRequiredService<IOptions<BlogStoreDBSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(m => new MongoClient(builder.Configuration.GetValue<string>("BlogStoreDBSetting:ConnectionString")) );

builder.Services.AddScoped<IUserRegistrationService, UserRegistrationService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
