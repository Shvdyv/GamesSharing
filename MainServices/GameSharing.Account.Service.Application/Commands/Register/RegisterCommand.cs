using GameSharing.Common;
using GameSharing.Model.AccountService;
using GameSharing.Model.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Account.Service.Application.Commands.Register
{
    public class RegisterCommand : ICommand
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid AuthToken { get; set; }

        public RegisterCommand(string name, string email, string password, Guid authToken)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            AuthToken = Guid.NewGuid();
        }   
    }
}
