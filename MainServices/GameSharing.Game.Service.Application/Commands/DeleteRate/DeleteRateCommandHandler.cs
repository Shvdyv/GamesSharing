using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameSharing.Common;
using GameSharing.GameInfo.Service.Application.Commands.DeleteGame;
using GameSharing.Model.GameService;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Commands.DeleteRate
{
    public class DeleteRateCommandHandler : ICommandHandler<DeleteRateCommand>
    {
        private readonly IRepository<Rate> RateRepository;

        public DeleteRateCommandHandler(IRepository<Rate> rateRepository)
        {
            RateRepository = rateRepository;
        }
        public Task Handle(DeleteRateCommand request, CancellationToken cancellationToken)
        {
            RateRepository.Delete(request.Id);
            return Task.CompletedTask;
        }
    }
}
