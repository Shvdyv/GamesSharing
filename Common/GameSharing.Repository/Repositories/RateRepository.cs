using GameSharing.Model.GameService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Repository.Repositories
{
    public class RateRepository : IRepository<Rate>
    {
        private readonly Database _context;

        public RateRepository(Database context)
        {
            _context = context;
        }
        public Rate Add(Rate entity)
        {
            entity.Id = new Guid();
            _context.Rates.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Rate? Get(Guid guid)
        {
            return _context.Rates.FirstOrDefault(x => x.Id == guid);
        }
        public float? GetRate(Guid id)
        {
            return _context.Rates.Where(x => x.GameRate != null&&x.Game.Id==id).Select(x => x.GameRate).Average();
        }

        public IEnumerable<Rate> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<Rate> GetAllObjects(Guid id)
        {
            return _context.Rates.Where(x => x.GameRate != null && x.Game.Id == id).ToList();
        }

        public IEnumerable<Rate> SearchBy(string paramName, string searchString)
        {
            throw new NotImplementedException();
        }

        public void Update(Rate entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
