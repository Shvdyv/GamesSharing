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
            throw new Exception("Ma się się inicjować z pliku conf");
        }

        public Repository(IConfiguration configuration)
        {

#if DEBUG
            string connectionString = configuration.GetConnectionString("Debug");
#else
                        string connectionString = configuration.GetConnectionString("Local");
#endif


            var builder = new DbContextOptionsBuilder().UseSqlServer(connectionString);
            _configuration = configuration;
            var options = new DbContextOptions<Database>();
            _context = new Database(options, configuration);
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

