using GameSharing.Common;
using GameSharing.Model.AccountService;
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
        private readonly IRepository<User> UserRepository;

        public RateGameCommandHandler(IRepository<Rate> rateRepository, IRepository<User> userRepository)
        {
            RateRepository = rateRepository;
            UserRepository = userRepository;
        }
        public Task Handle(RateGameCommand request, CancellationToken cancellationToken)
        {
            var user = UserRepository.GetUser(Guid.Parse(request.UserId));
            var rate = new Rate(request.Id, user, request.Rate, request.Game);
            RateRepository.Add(rate);
            return Task.CompletedTask;
        }
    }
}
