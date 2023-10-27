using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSharing.Common;

namespace GameSharing.GameInfo.Service.Application.Commands.DeleteRate
{
    public class DeleteRateCommand : ICommand
    {
        public Guid Id { get; set; }

        public DeleteRateCommand(Guid id)
        {
            Id = id;
        }
    }
}
