using GameSharing.Model.AccountService;
using GameSharing.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Repository.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly Database _context;

        public UserRepository(Database context)
        {
            _context = context;
        }
        public User Add(User entity)
        {
            entity.Id = new Guid();
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var result = _context.Users.FirstOrDefault(u => u.Id == id);
            if (result != null)
            {
                result.IsDeleted = true;
                _context.Users.Remove(result);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Can't find object to delete");
            }
        }

        public User? Get(Guid guid)
        {
            return _context.Users.FirstOrDefault(u => u.Id == guid);
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> SearchBy(string paramName, string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
