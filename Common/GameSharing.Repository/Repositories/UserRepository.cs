﻿using GameSharing.Model.AccountService;
using GameSharing.Repository.Interfaces;
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
            entity.Roles.Add(_context.UserRoles.FirstOrDefault(r => r.Role.Name=="User"));
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var result = _context.Users.FirstOrDefault(u => u.Id == id);
            if (result != null)
            {
                //result.IsDeleted = true;
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
            return _context.Users.Include(x=>x.Roles).ThenInclude(x=>x.Role).FirstOrDefault(x => x.Id == guid);
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
        public User Login(string login, string password)
        {
            throw new NotImplementedException();
        }
        public User GetUser(Guid id)
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
        public User Logout()
        {
            throw new NotImplementedException();
        }
    }
}
