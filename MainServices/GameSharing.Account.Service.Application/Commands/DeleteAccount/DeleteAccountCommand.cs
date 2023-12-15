using GameSharing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.Account.Service.Application.Commands.DeleteAccount
{
    public class DeleteAccountCommand : ICommand
    {
        public Guid Id { get; set; }

        public DeleteAccountCommand(Guid id)
        {
            Id = id;
        }
    }
}
