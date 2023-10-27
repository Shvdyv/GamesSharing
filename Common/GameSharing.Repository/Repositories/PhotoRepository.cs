using GameSharing.Model.GameService;
using GameSharing.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static GameSharing.Repository.Interfaces.IRepository;

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
            return _context.Photos.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Photo> GetAll()
        {
            return _context.Photos.ToList();
        }

        public ICollection<Photo> GetAllObjects(Guid id)
        {
            return _context.Photos.Where(x=>x.Id==id).ToList();
        }

        public IEnumerable<Photo> SearchBy(string paramName, string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Photo entity)
        {
            throw new NotImplementedException();
        }
    }
}
