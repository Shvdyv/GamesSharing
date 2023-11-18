using GameSharing.Model.AccountService;
using GameSharing.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace NetAuthService
{
    public class AuthService
    {
        private readonly Database database;
        public AuthService(Database database)
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
            identity.AddClaim(new Claim("Token", user.AuthToken ?? string.Empty));
            foreach (var role in user.Roles)
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Role.Name));
            return identity;
        }
    }
}
