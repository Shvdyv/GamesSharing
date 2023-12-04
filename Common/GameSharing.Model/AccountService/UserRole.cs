using GameSharing.Model.GameService;
using GameSharing.Model.Prototype;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Model.AccountService
{
    public class UserRole : DbDataEntity
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        public UserRole(Guid id, User user, Role role)
        {
            Id = id;
            User = user ?? throw new ArgumentNullException(nameof(user));
            Role = role ?? throw new ArgumentNullException(nameof(role));
        }
        public UserRole() { }
    }
}
