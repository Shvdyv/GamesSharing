using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Model.Prototype
{
    public abstract class DbDataEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
