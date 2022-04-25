using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Implementations;
using RepositoryLayer.Interfaces;
using ServiceLayer.Implementations;
using ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using ServiceLayer.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICurrenciesService, CurrenciesService>();
builder.Services.AddScoped<IExchangesHistoryService, ExchangesHistoryService>();

builder.Services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
builder.Services.AddScoped<IExchangesHistoryRepsitory, ExchangesHistoryRepository>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
options => options.SignIn.RequireConfirmedAccount = false)
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthentication("BasicAuthentication")
         .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
