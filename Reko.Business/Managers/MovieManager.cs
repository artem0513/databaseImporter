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
    public sealed class MovieManager : CatalogManagerBase<Movie, IUniqueMovieDataContainer, MovieDto, IMovieRepository, int>, IMovieManager
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICrewMemberRepository _crewMemberRepository;
        private readonly ICastMemberRepository _castMemberRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly IKeywordRepository _keywordRepository;
        private readonly ICountryRepository _countryRepository;

        public MovieManager(IUniqueMovieDataContainer movieDataContainer, IMovieRepository movieRepository, ICompanyRepository companyRepository,
            ICrewMemberRepository crewMemberRepository,
            ICastMemberRepository castMemberRepository, ILanguageRepository languageRepository, IGenreRepository genreRepository,
            IVideoRepository videoRepository, IKeywordRepository keywordRepository, ICountryRepository countryRepository, ILogger logger)
            : base(movieRepository, movieDataContainer, logger)
        {
            _companyRepository = companyRepository;
            _crewMemberRepository = crewMemberRepository;
            _castMemberRepository = castMemberRepository;
            _languageRepository = languageRepository;
            _genreRepository = genreRepository;
            _videoRepository = videoRepository;
            _keywordRepository = keywordRepository;
            _countryRepository = countryRepository;
        }

        public async Task<MovieDto> GetMovieInfo(int id, CancellationToken cancellationToken)
        {
            return await Repository.GetMovie(id, cancellationToken);
        }

        protected override async Task SaveChildObjects(IUniqueMovieDataContainer container, CancellationToken cancellationToken)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            await Repository.AddCollectionInfos(container.CollectionInfos, cancellationToken);
            await _companyRepository.AddIfNotExistent(container.ProductionCompanies, cancellationToken);
            await _crewMemberRepository.AddIfNotExistent(container.CrewMembers, cancellationToken);
            await _castMemberRepository.AddIfNotExistent(container.CastMembers, cancellationToken);
            await _languageRepository.AddIfNotExistent(container.SpokenLanguages, cancellationToken);
            await _genreRepository.AddIfNotExistent(container.Genres, cancellationToken);
            await _videoRepository.AddIfNotExistent(container.Videos, cancellationToken);
            await _keywordRepository.AddIfNotExistent(container.Keywords, cancellationToken);
            await _countryRepository.AddIfNotExistent(container.ProductionCountries, cancellationToken);
        }
    }
}