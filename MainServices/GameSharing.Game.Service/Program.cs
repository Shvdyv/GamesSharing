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



