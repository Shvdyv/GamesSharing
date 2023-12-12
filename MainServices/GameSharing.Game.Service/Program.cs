using GameSharing.Repository.Repositories;
using static GameSharing.Repository.Interfaces.IRepository;
//using System.Configuration;
//using MediatR;
using GameSharing.GameInfo.Service.Application.Commands.AddGame;
using GameSharing.GameInfo.Service.Application.Commands.DeleteGame;
using GameSharing.GameInfo.Service.Application.Commands.EditGame;
using GameSharing.GameInfo.Service.Application.Queries.GetAllGames;
using GameSharing.GameInfo.Service.Application.Queries.DisplayDetailsGame;
using GameSharing.GameInfo.Service.Application.Queries.DownloadGame;
using GameSharing.GameInfo.Service.Application.Commands.CommentGame;
using GameSharing.GameInfo.Service.Application.Commands.RateGame;
using GameSharing.GameInfo.Service.Application.Commands.AddPhotos;
using GameSharing.GameInfo.Service.Application.Commands.DeleteComment;
using GameSharing.GameInfo.Service.Application.Commands.DeleteRate;
using GameSharing.GameInfo.Service.Application.Queries.AuthenticateByToken;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IRepository<GameSharing.Model.GameService.Game>>(new GameRepository(new GameSharing.Repository.Database(builder.Configuration)));
builder.Services.AddSingleton<IRepository<GameSharing.Model.GameService.Comment>>(new CommentRepository(new GameSharing.Repository.Database(builder.Configuration)));
builder.Services.AddSingleton<IRepository<GameSharing.Model.GameService.Photo>>(new PhotoRepository(new GameSharing.Repository.Database(builder.Configuration)));
builder.Services.AddSingleton<IRepository<GameSharing.Model.GameService.Rate>>(new RateRepository(new GameSharing.Repository.Database(builder.Configuration)));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddAuthorization();
builder.Services.AddAntiforgery();
builder.Services.AddCors(o => o.AddPolicy("NotSecure", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
}));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddGameCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EditGameCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteGameCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllGamesQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DisplayDetailsGameQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DownloadGameQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CommentGameCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RateGameCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddPhotosCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteCommentCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteRateCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuthenticateByTokenQueryHandler).Assembly));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials());
app.MapControllers();
app.Run();



