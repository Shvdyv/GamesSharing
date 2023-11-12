using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSharing.Repository.Repositories;

namespace GameSharing.Repository
{
    public class Repository
    {
        private readonly IConfiguration _configuration;
        private Database _context;
        /// <summary>
        /// Use only for development
        /// </summary>
        public Repository()
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("developer_settings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            new Repository(configuration);

        }

        public Repository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Local");
            var builder = new DbContextOptionsBuilder().UseSqlServer(connectionString);
            _configuration = configuration;
            var options = new DbContextOptions<Database>();
            _context = new Database(configuration);


            PostRepository = new PostRepository(_context);
            PhotoRepository = new PhotoRepository(_context);
            GameRepository = new GameRepository(_context);
            UserRepository = new UserRepository(_context);
            CommentRepository = new CommentRepository(_context);
            RateRepository = new RateRepository(_context);
            RoleRepository = new RoleRepository(_context);

        }
        public virtual UserRepository UserRepository { get; }
        public virtual PostRepository PostRepository { get; }
        public virtual GameRepository GameRepository { get; }
        public virtual PhotoRepository PhotoRepository { get; }
        public virtual CommentRepository CommentRepository { get; }
        public virtual RateRepository RateRepository { get; }
        public virtual RoleRepository RoleRepository { get; }
    }
}

