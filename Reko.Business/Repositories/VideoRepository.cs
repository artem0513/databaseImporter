using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class VideoRepository : CRUDRepository<Video, VideoDto, RekoDbContext, string>, IVideoRepository
    {
        public VideoRepository(RekoDbContext context) : base(context)
        {
        }
    }
}