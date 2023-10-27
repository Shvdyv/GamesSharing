using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Model.AccountService
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }
    }
}
