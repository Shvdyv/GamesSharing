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
        public Database(DbContextOptions<Database> options, IConfiguration configuration) : base(options)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            // Build the configuration
            IConfiguration config = builder.Build();
            _configuration = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("Debug")
                                   ?? throw new Exception("Invalid connection string name.");
            optionsBuilder.UseSqlServer(connectionString);
        }
        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            var builder = new ConfigurationBuilder()
        //                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //            var configuration = builder.Build();
        //#if DEBUG
        //            string connectionString = configuration.GetConnectionString("Debug");
        //#else
        //            string connectionString = configuration.GetConnectionString("Local");
        //#endif
        //            optionsBuilder.UseSqlServer(connectionString);
        //        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
    }
}