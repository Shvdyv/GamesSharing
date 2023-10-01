using GameSharing.Model.AccountService;
using GameSharing.Model.ForumService;
using GameSharing.Model.GameService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameSharing.Repository
{
    public class Database : DbContext
    {
        private readonly IConfiguration _configuration;
        public Database()
        {
        }

        public Database(IConfiguration configuration)
        {
            _configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("Local");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
    }
}