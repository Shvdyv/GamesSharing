using GameSharing.Common;
using GameSharing.Model.GameService;
using GameSharing.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Queries.DisplayDetailsGame
{
    public class DisplayDetailsGameQueryHandler : IQueryHandler<DisplayDetailsGameQuery, DisplayDetailsGameQueryResponse> // getdetails display=get
    {
        private readonly IRepository<Game> GameRepository;
        private readonly IRepository<Rate> RateRepository;
        private readonly IRepository<Comment> CommentRepository;
        private readonly IRepository<Photo> PhotoRepository;

        public DisplayDetailsGameQueryHandler(IRepository<Game> gameRepository, IRepository<Rate> rateRepository, IRepository<Comment> commentRepository, IRepository<Photo> photoRepository)
        {
            GameRepository = gameRepository;
            RateRepository = rateRepository;
            CommentRepository = commentRepository;
            PhotoRepository = photoRepository;
        }

        public async Task<DisplayDetailsGameQueryResponse> Handle(DisplayDetailsGameQuery request, CancellationToken cancellationToken)
        {
            var game = GameRepository.Get(request.Id);
            game.Rate = RateRepository.GetAllObjects(request.Id).Select(x => x.GameRate).Average();
            return new DisplayDetailsGameQueryResponse(game);
        }

    }
}
