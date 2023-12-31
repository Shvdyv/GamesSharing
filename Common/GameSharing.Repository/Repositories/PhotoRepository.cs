﻿using GameSharing.Model.GameService;
using GameSharing.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static GameSharing.Repository.Interfaces.IRepository;
using GameSharing.Model.AccountService;
using System.Security.Claims;

namespace GameSharing.Repository.Repositories
{
    public class PhotoRepository : IRepository<Photo>
    {
        private readonly Database _context;

        public PhotoRepository(Database context)
        {
            _context = context;
        }
        public Photo Add(Photo entity)
        {
            _context.Photos.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Photo? Get(Guid id)
        {
            return _context.Photos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Photo> GetAll()
        {
            return _context.Photos.Where(p => p.IsDeleted == false).ToList();
        }

        public ICollection<Photo> GetAllObjects(Guid id)
        {
            return _context.Photos.Where(p=>p.Id==id && p.IsDeleted == false).ToList();
        }

        public IEnumerable<Photo> SearchBy(string paramName, string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Photo entity)
        {
            throw new NotImplementedException();
        }

        public Photo Login(string login, string password)
        {
            throw new NotImplementedException();
        }
        public Photo GetUser(Guid id)
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
