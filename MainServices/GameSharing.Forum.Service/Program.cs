using GameSharing.Forum.Service.Application.Commands.AddPost;
using GameSharing.Forum.Service.Application.Commands.DeletePost;
using GameSharing.Forum.Service.Application.Queries.DisplayPosts;
using GameSharing.Repository.Repositories;
using static GameSharing.Repository.Interfaces.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IRepository<GameSharing.Model.ForumService.Post>>(new PostRepository(new GameSharing.Repository.Database(builder.Configuration)));
builder.Services.AddCors(o => o.AddPolicy("NotSecure", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
}));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddPostCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DisplayPostsQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeletePostCommandHandler).Assembly));
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
