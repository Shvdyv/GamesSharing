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
    public class GameRepository : IRepository<Game>
    {
        private readonly Database _context;
        public GameRepository(Database context)
        {
            _context = context;
        }


        public Game Add(Game entity)
        {
            _context.Games.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var result = _context.Games.FirstOrDefault(g => g.Id == id);
            if (result != null)
            {
                result.IsDeleted = true; // we wszystkich repo
                _context.Update(result);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Can't find object to delete");
            }
        }

        public Game? Get(Guid guid)
        {
            return _context.Games.FirstOrDefault(g => g.Id == guid&&g.IsDeleted==false);
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games.Where(g=>g.IsDeleted==false).ToList(); // wszystkie getAll na false
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
                        .Where(g => property.GetValue(g).ToString().Contains(searchString))
                        .ToList();
                    break;
                default: throw new NotImplementedException();
            }
            return result;
        }

        public void Update(Game entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Update(entity);
            _context.SaveChanges();
        }
        public Game Login(string login, string password)
        {
            throw new NotImplementedException();
        }
        public Game GetUser(Guid id)
        {
            throw new NotImplementedException();
        }
        public User Login(string Token)
        {
            var _return = _context.Users
                .Include(x => x.Roles)
                    .ThenInclude(x => x.Role)
            .First(x => x.AuthToken.Equals(Token));
            return _return;
        }
        public ClaimsIdentity GetClaims(User user)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim("Token", user.AuthToken ?? string.Empty));
            foreach (var role in user.Roles)
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Role.Name));
            return identity;
        }
    }
}
