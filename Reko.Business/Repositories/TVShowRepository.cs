using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public sealed class TVShowRepository : CRUDRepository<TvShow, TVShowDto, RekoDbContext, int>, ITVShowRepository
    {
        private readonly IEntityKeeper _entityKeeper;

        public TVShowRepository(RekoDbContext context, IEntityKeeper entityKeeper) : base(context)
        {
            _entityKeeper = entityKeeper;
        }

        public async Task LinkData(ICollection<TVShowDto> data)
        {
            await _entityKeeper.SaveTvShowData(data);

            var episodes = _entityKeeper.GetEpisodes();
            var seasons = _entityKeeper.GetSeasons();

            foreach (var (tvShowDto, tvShow) in _entityKeeper.GetTvShows())
            {
                tvShow.ProductionCompanies.AddRange(_entityKeeper.GetEntityProductionCompanies(tvShowDto.ProductionCompanies.Select(x => x.Id)));
                tvShow.CastMembers.AddRange(_entityKeeper.GetEntityCastMembers(tvShowDto.Credit?.CastMembers.Select(x => x.Id)));
                tvShow.CrewMembers.AddRange(_entityKeeper.GetEntityCrewMembers(tvShowDto.Credit?.CrewMembers.Select(x => x.Id)));
                tvShow.Genres.AddRange(_entityKeeper.GetEntityGenres(tvShowDto.Genres.Select(x => x.Id)));
                tvShow.Videos.AddRange(_entityKeeper.GetEntityVideos(tvShowDto.Videos?.Videos.Select(x => x.Id)));
                tvShow.Networks.AddRange(_entityKeeper.GetEntityNetworks(tvShowDto.Networks.Select(x => x.Id)));
                tvShow.TvShowCreators.AddRange(_entityKeeper.GetEntityTvShowCreators(tvShowDto.CreatedBy.Select(x => x.Id)));
                tvShow.KeyWords.AddRange(_entityKeeper.GetEntityKeyWords(tvShowDto.Keywords.Select(x => x.Id)));
                tvShow.Seasons.AddRange(tvShowDto.Seasons.Select(x => seasons[x]));
            }

            foreach (var (episodeDto, episode) in episodes)
            {
                episode.GuestStars.AddRange(_entityKeeper.GetEntityGuestStars(episodeDto.GuestStars.Select(x => x.Id)));
                episode.CrewMembers.AddRange(_entityKeeper.GetEntityCrewMembers(episodeDto.CrewMembers.Select(x => x.Id)));
            }

            foreach (var (seasonDto, season) in seasons)
            {
                season.Episodes.AddRange(seasonDto.Episodes.Select(x => episodes[x]));
            }

            _entityKeeper.Clear();
        }

        public async Task<TVShowDto> GetTvShowInfo(int id)
        {
            var tvShow = await Context.TvShows.Include(x => x.Genres).Include(x => x.TvShowCreators).Include(x => x.ProductionCompanies)
                .Include(x => x.Networks).Include(x => x.Videos)
                .Include(x => x.CastMembers).Include(x => x.KeyWords).Include(x => x.Seasons).ThenInclude(x => x.Episodes)
                .ThenInclude(x => x.CrewMembers).FirstOrDefaultAsync(x => x.Id == id);

            return tvShow.ToDto();
        }
    }
}