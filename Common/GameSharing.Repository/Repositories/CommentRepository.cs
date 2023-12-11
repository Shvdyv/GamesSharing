using GameSharing.Model.AccountService;
using GameSharing.Model.GameService;
using GameSharing.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Repository.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly Database _context;

        public CommentRepository(Database context)
        {
            _context = context;
        }

        public Comment Add(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var result = _context.Comments.FirstOrDefault(c => c.Id == id);
            if (result != null)
            {
                result.IsDeleted = true;
                _context.Comments.Remove(result);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Can't find object to delete");
            }
        }

        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }

        Comment? IRepository<Comment>.Get(Guid id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }

        IEnumerable<Comment> IRepository<Comment>.GetAll()
        {
            return _context.Comments.Where(c => c.IsDeleted == false).ToList();
        }

        ICollection<Comment> IRepository<Comment>.GetAllObjects(Guid id)
        {
            return _context.Comments.Where(c=>c.Game.Id==id && c.IsDeleted == false).ToList();
        }

        IEnumerable<Comment> IRepository<Comment>.SearchBy(string paramName, string searchString)
        {
            throw new NotImplementedException();
        }
        public Comment Login(string login, string password)
        {
            throw new NotImplementedException();
        }
        public Comment GetUser(Guid id)
        {
            throw new NotImplementedException();
        }
        public User Login(string Token)
        {
            throw new NotImplementedException();
        }
        public ClaimsIdentity GetClaims(User user)
        {
            throw new NotImplementedException();
        }
    }
}
