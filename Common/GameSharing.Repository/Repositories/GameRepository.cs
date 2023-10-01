using GameSharing.Model.GameService;
using GameSharing.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Repository.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private readonly Database _context;

        public GameRepository(Database context)
        {
            _context = context;
        }
        public Game Add(Game entity)
        {
            entity.Id = new Guid();
            _context.Games.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var result = _context.Games.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.IsDeleted = true;
                _context.Update(result);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Can't find object to delete");
            }
        }

        public Game? Get(Guid guid)
        {
            return _context.Games.FirstOrDefault(x => x.Id == guid&&x.IsDeleted==false);
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games.Where(x=>x.IsDeleted==false).ToList();
        }

        public IEnumerable<Game> SearchBy(string paramName, string searchString)
        {
            var result = new List<Game>();
            var property = typeof(Game).GetProperty(paramName);
            var propertyType = property.PropertyType;
            switch (propertyType.Name)
            {
                case "string":
                    result = _context.Games
                        .Where(c => property.GetValue(c).ToString().Contains(searchString))
                        .ToList();
                    break;
                default: throw new NotImplementedException();
            }
            return result;
        }

        public void Update(Game entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
