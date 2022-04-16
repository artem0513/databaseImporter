using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reko.Contracts.Containers;
using Reko.Contracts.Managers;
using Reko.Contracts.Repositories;
using Reko.Data.Entities;
using Reko.Models.Dto;
using Serilog;

namespace Reko.Business.Managers
{
    public sealed class TVShowManager : CatalogManagerBase<TvShow, IUniqueTvShowDataContainer, TVShowDto, ITVShowRepository, int>, ITVShowManager
    {
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

        public TVShowManager(IUniqueTvShowDataContainer tvShowDataContainer, ITVShowRepository tvShowRepository, ICompanyRepository companyRepository,
            ICrewMemberRepository crewMemberRepository,
            ICastMemberRepository castMemberRepository, ISeasonRepository seasonRepository, IGenreRepository genreRepository,
            IVideoRepository videoRepository, IKeywordRepository keywordRepository, IEpisodeRepository episodeRepository,
            INetworkRepository networkRepository, IGuestStarRepository guestStarRepository, ITvShowCreatorRepository tvShowCreatorRepository, ILogger logger)
            : base(tvShowRepository, tvShowDataContainer, logger)
        {
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

        public async Task<TVShowDto> GetTvShowInfo(int id, CancellationToken cancellationToken)
        {
            return await Repository.GetTvShowInfo(id, cancellationToken);
        }

        protected override async Task SaveChildObjects(IUniqueTvShowDataContainer container, CancellationToken cancellationToken)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            await _companyRepository.AddIfNotExistent(container.ProductionCompanies, cancellationToken);
            await _networkRepository.AddIfNotExistent(container.Networks, cancellationToken);
            await _tvShowCreatorRepository.AddIfNotExistent(container.TVShowCreators, cancellationToken);
            await _crewMemberRepository.AddIfNotExistent(container.CrewMembers, cancellationToken);
            await _castMemberRepository.AddIfNotExistent(container.CastMembers, cancellationToken);
            await _seasonRepository.AddIfNotExistent(container.Seasons, cancellationToken);
            await _episodeRepository.AddIfNotExistent(container.Episodes, cancellationToken);
            await _guestStarRepository.AddIfNotExistent(container.GuestStars, cancellationToken);
            await _genreRepository.AddIfNotExistent(container.Genres, cancellationToken);
            await _videoRepository.AddIfNotExistent(container.Videos, cancellationToken);
            await _keywordRepository.AddIfNotExistent(container.Keywords, cancellationToken);
        }
    }
}