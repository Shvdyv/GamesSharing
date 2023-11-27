using GameSharing.Model.AccountService;
using GameSharing.Model.ForumService;
using GameSharing.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Repository.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private readonly Database _context;

        public PostRepository(Database context)
        {
            _context = context;
        }
        public Post Add(Post entity)
        {
            _context.Posts.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (post != null) 
            {
                post.IsDeleted = true;
                _context.Posts.Update(post);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Can't find object to delete");
            }
        }

        public Post? Get(Guid guid)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == guid);
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.Where(p => p.IsDeleted == false).ToList();
        }

        public IEnumerable<Post> SearchBy(string paramName, string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Post entity)
        {
            throw new NotImplementedException();
        }
        public Post Login(string login, string password)
        {
            throw new NotImplementedException();
        }
        public Post GetUser(Guid id)
        {
            throw new NotImplementedException();
        }
        public Post Login(string Token)
        {
            throw new NotImplementedException();
        }
        public ClaimsIdentity GetClaims(User user)
        {
            throw new NotImplementedException();
        }
    }
}
