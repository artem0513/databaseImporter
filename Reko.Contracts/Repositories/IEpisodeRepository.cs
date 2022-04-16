﻿using Reko.Models.Dto;

namespace Reko.Contracts.Repositories
{
    public interface IEpisodeRepository : ICRUDRepository<EpisodeDto, int>
    {
    }
}