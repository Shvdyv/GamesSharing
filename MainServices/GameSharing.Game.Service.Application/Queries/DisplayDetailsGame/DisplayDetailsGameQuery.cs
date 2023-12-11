using GameSharing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Queries.DisplayDetailsGame
{
    public class DisplayDetailsGameQuery : IQuery<DisplayDetailsGameQueryResponse>
    {
        public Guid Id { get; set; }

        public DisplayDetailsGameQuery(Guid id)
        {
            Id = id;
        }
    }
}
