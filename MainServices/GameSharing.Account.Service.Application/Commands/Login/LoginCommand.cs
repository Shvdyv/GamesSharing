using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSharing.Common;

namespace GameSharing.Account.Service.Application.Commands.Login
{
    public class LoginCommand:ICommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
