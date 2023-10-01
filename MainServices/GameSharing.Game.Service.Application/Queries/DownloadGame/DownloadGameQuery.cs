using GameSharing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSharing.GameInfo.Service.Application.Queries.DownloadGame
{
    public class DownloadGameQuery : IQuery<DownloadGameQueryResponse>
    {
        public Guid Id { get; set; }
        public string File { get; set; }

        public DownloadGameQuery(Guid id, string file)
        {
            Id = id;
            File = file;
        }
    }
}
