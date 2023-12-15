using GameSharing.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using GameSharing.Model.AccountService;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.Repository.Repositories
{
    public class AuthRepository : IRepository<User>
    {
        private readonly Database database;
        public AuthRepository(Database database)
        {
            this.database = database;
        }
        public User Login(string login, string password)
        {
            try
            {
                var _return = database.Users.Include(x => x.Roles).ThenInclude(x => x.Role).First(x => x.Email.Equals(login) && x.Password.Equals(password));
                return _return;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public User GetUser(Guid id)
        {
            var _return = database.Users
                .Include(x => x.Roles)
                    .ThenInclude(x => x.Role)
            .First(x => x.Id.Equals(id));
            return _return;
        }
        public User Login(string Token)
        {
            var _return = database.Users
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
            identity.AddClaim(new Claim("Token", user.AuthToken.ToString() ?? string.Empty));
            foreach (var role in user.Roles)
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Role.Name));
            return identity;
        }

        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public User? Get(Guid guid)
        {
            throw new NotImplementedException();
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
