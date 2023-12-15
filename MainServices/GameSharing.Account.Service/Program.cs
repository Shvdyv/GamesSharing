using GameSharing.Account.Service.Application.Commands.Logout;
using GameSharing.Account.Service.Application.Commands.Register;
using GameSharing.Account.Service.Application.Queries.Authenticate;
using GameSharing.Account.Service.Application.Queries.AuthenticateByToken;
using GameSharing.Model.AccountService;
using GameSharing.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Configuration;
using static GameSharing.Repository.Interfaces.IRepository;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();
//var connectionString = builder.Configuration.GetConnectionString("System");
//var connectionString = builder.Configuration.GetConnectionString("Local");

//builder.Services.AddDbContext<Database>(x => x.UseSqlServer(connectionString));
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IRepository<GameSharing.Model.AccountService.User>>(new UserRepository(new GameSharing.Repository.Database(builder.Configuration)));
builder.Services.AddSingleton<IRepository<GameSharing.Model.AccountService.Role>>(new RoleRepository(new GameSharing.Repository.Database(builder.Configuration)));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddAuthorization();
builder.Services.AddAntiforgery();
builder.Services.AddCors(o => o.AddPolicy("NotSecure", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
}));

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.AccessDeniedPath = "/Home/Login";
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
//    options.LoginPath = "/Home/Login";
//    //options.Cookie.Name = "GamesSharing";
//});
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

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LogoutCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuthenticateQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuthenticateByTokenQueryHandler).Assembly));

app.MapControllers();

app.Run();
