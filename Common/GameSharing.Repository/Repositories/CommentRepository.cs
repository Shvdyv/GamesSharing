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
    public class CommentRepository : IRepository<Comment>
    {
        private readonly Database _context;

        public CommentRepository(Database context)
        {
            _context = context;
        }

        public Comment Add(Comment entity)
        {
            entity.Id = new Guid();
            _context.Comments.Add(entity);
            _context.SaveChanges();
            return entity;
        }


        public void Delete(Guid id)
        {
            var result = _context.Comments.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                _context.Comments.Remove(result);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Can't find object to delete");
            }
        }


        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }

        Comment? IRepository<Comment>.Get(Guid id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == id);
        }

        IEnumerable<Comment> IRepository<Comment>.GetAll()
        {
            return _context.Comments.ToList();
        }

        ICollection<Comment> IRepository<Comment>.GetAllObjects(Guid id)
        {
            return _context.Comments.Where(x=>x.Game.Id==id).ToList();
        }

        IEnumerable<Comment> IRepository<Comment>.SearchBy(string paramName, string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
