using GameSharing.Common;
using GameSharing.GameInfo.Service.Application.Commands.AddGame;
using GameSharing.Model.GameService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameSharing.Repository.Interfaces.IRepository;

namespace GameSharing.GameInfo.Service.Application.Commands.AddPhotos
{
    public class AddPhotosCommandHandler : ICommandHandler<AddPhotosCommand>
    {
        private readonly IRepository<Photo> PhotoRepository;

        public AddPhotosCommandHandler(IRepository<Photo> photoRepository)
        {
            PhotoRepository = photoRepository;
        }

        Task IRequestHandler<AddPhotosCommand>.Handle(AddPhotosCommand request, CancellationToken cancellationToken)
        {
            var photo = new Photo(request.Photo, request.Game);
            PhotoRepository.Add(photo);
            return Task.CompletedTask;
        }
    }
}
