using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Model.AccountService
{
    public class UserRole
    {
        [Key]
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
