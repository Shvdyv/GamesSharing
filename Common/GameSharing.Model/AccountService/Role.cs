using GameSharing.Model.Prototype;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Model.AccountService
{
    public class Role : DbDataEntity
    {
        public string Name { get; set; }

        public Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Role() { }
    }




}
