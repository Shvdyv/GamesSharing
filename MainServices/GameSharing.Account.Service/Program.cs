using GameSharing.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
#if DEBUG
var connectionString = builder.Configuration.GetConnectionString("System");
#else
var connectionString = builder.Configuration.GetConnectionString("PRODUKCJA");
#endif

builder.Services.AddDbContext<Database>(x => x.UseSqlServer(connectionString));
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddAuthorization();
builder.Services.AddAntiforgery();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Home/Login";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Home/Login";
    //options.Cookie.Name = "GamesSharing";
});
// Add services to the container.

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

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

app.MapControllers();

app.Run();
