using GameSharing.Common;
using GameSharing.Model.GameService;
using GameSharing.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Commands.RateGame
{
    public class RateGameCommandHandler : ICommandHandler<RateGameCommand>
    {
        private readonly IRepository<Rate> RateRepository;

        public RateGameCommandHandler(IRepository<Rate> rateRepository)
        {
            RateRepository = rateRepository;
        }
        public Task Handle(RateGameCommand request, CancellationToken cancellationToken)
        {
            var rate = new Rate(request.Id, request.UserId, request.Rate, request.Game);
            RateRepository.Add(rate);
            return Task.CompletedTask;
        }
    }
}
