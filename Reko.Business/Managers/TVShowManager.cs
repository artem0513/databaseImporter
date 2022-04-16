using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reko.Contracts.Managers;
using Reko.Contracts.Repositories;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Managers
{
    public sealed class TVShowManager : CatalogManagerBase<TVShowDto, ITVShowRepository>, ITVShowManager
    {
        private readonly ITVShowRepository _tvShowRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICrewMemberRepository _crewMemberRepository;
        private readonly ICastMemberRepository _castMemberRepository;
        private readonly ISeasonRepository _seasonRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly IKeywordRepository _keywordRepository;
        private readonly IEpisodeRepository _episodeRepository;
        private readonly INetworkRepository _networkRepository;
        private readonly IGuestStarRepository _guestStarRepository;
        private readonly ITvShowCreatorRepository _tvShowCreatorRepository;

        public TVShowManager(ITVShowRepository tvShowRepository, ICompanyRepository companyRepository, ICrewMemberRepository crewMemberRepository,
            ICastMemberRepository castMemberRepository, ISeasonRepository seasonRepository, IGenreRepository genreRepository,
            IVideoRepository videoRepository, IKeywordRepository keywordRepository, IEpisodeRepository episodeRepository,
            INetworkRepository networkRepository, IGuestStarRepository guestStarRepository, ITvShowCreatorRepository tvShowCreatorRepository)
            : base(tvShowRepository)
        {
            _tvShowRepository = tvShowRepository;
            _companyRepository = companyRepository;
            _crewMemberRepository = crewMemberRepository;
            _castMemberRepository = castMemberRepository;
            _seasonRepository = seasonRepository;
            _genreRepository = genreRepository;
            _videoRepository = videoRepository;
            _keywordRepository = keywordRepository;
            _episodeRepository = episodeRepository;
            _networkRepository = networkRepository;
            _guestStarRepository = guestStarRepository;
            _tvShowCreatorRepository = tvShowCreatorRepository;
        }

        protected override void RemoveDuplicates(IEnumerable<TVShowDto> data)
        {
            foreach (var tvShowDto in data)
            {
                if (tvShowDto.Credit != null)
                {
                    tvShowDto.Credit.CrewMembers = tvShowDto.Credit.CrewMembers.Distinct();
                    tvShowDto.Credit.CastMembers = tvShowDto.Credit.CastMembers.Distinct();
                }

                if (tvShowDto.Videos != null)
                {
                    tvShowDto.Videos.Videos = tvShowDto.Videos.Videos.Distinct();
                }

                tvShowDto.Seasons = tvShowDto.Seasons.Distinct().ToArray();
                foreach (var seasonDto in tvShowDto.Seasons)
                {
                    seasonDto.Episodes = seasonDto.Episodes.Distinct().ToArray();
                    foreach (var seasonDtoEpisode in seasonDto.Episodes)
                    {
                        seasonDtoEpisode.GuestStars = seasonDtoEpisode.GuestStars.Distinct();
                        seasonDtoEpisode.CrewMembers = seasonDtoEpisode.CrewMembers.Distinct();
                    }
                }

                tvShowDto.ProductionCompanies = tvShowDto.ProductionCompanies.Distinct();
                tvShowDto.Networks = tvShowDto.Networks.Distinct();
                tvShowDto.Genres = tvShowDto.Genres.Distinct();
                tvShowDto.Keywords = tvShowDto.Keywords.Distinct();
                tvShowDto.CreatedBy = tvShowDto.CreatedBy.Distinct();
            }
        }

        protected override async Task SaveChildObjects(ICollection<TVShowDto> data)
        {
            var seasons = data.SelectMany(x => x.Seasons).Distinct().ToArray();
            var episodes = seasons.SelectMany(x => x.Episodes).Distinct().ToArray();
            await _companyRepository.AddIfNotExistent(data.SelectMany(x => x.ProductionCompanies).Distinct());
            await _networkRepository.AddIfNotExistent(data.SelectMany(x => x.Networks).Distinct());
            await _tvShowCreatorRepository.AddIfNotExistent(data.SelectMany(x => x.CreatedBy).Distinct());
            await _crewMemberRepository.AddIfNotExistent(data.SelectMany(x => x.Credit?.CrewMembers)
                .Concat(episodes.SelectMany(x => x.CrewMembers)).Distinct());
            await _castMemberRepository.AddIfNotExistent(data.SelectMany(x => x.Credit?.CastMembers).Distinct());
            await _seasonRepository.AddIfNotExistent(seasons);
            await _episodeRepository.AddIfNotExistent(episodes);
            await _guestStarRepository.AddIfNotExistent(episodes.SelectMany(x => x.GuestStars).Distinct());
            await _genreRepository.AddIfNotExistent(data.SelectMany(x => x.Genres).Distinct());
            await _videoRepository.AddIfNotExistent(data.SelectMany(x => x.Videos?.Videos).Distinct());
            await _keywordRepository.AddIfNotExistent(data.SelectMany(x => x.Keywords).Distinct());
        }

        public async Task<IEnumerable<TVShowDto>> GetTvShows()
        {
            return await _tvShowRepository.Get();
        }

        public async Task<TVShowDto> GetTvShowInfo(int id)
        {
            return await _tvShowRepository.GetTvShowInfo(id);
        }
    }
}