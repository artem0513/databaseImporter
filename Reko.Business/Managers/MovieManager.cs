using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reko.Contracts.Managers;
using Reko.Contracts.Repositories;
using Reko.Models.Dto;

namespace Reko.Business.Managers
{
    public sealed class MovieManager : CatalogManagerBase<MovieDto, IMovieRepository>, IMovieManager
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICrewMemberRepository _crewMemberRepository;
        private readonly ICastMemberRepository _castMemberRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly IKeywordRepository _keywordRepository;
        private readonly ICountryRepository _countryRepository;

        public MovieManager(IMovieRepository movieRepository, ICompanyRepository companyRepository, ICrewMemberRepository crewMemberRepository,
            ICastMemberRepository castMemberRepository, ILanguageRepository languageRepository, IGenreRepository genreRepository,
            IVideoRepository videoRepository, IKeywordRepository keywordRepository, ICountryRepository countryRepository) : base(movieRepository)
        {
            _movieRepository = movieRepository;
            _companyRepository = companyRepository;
            _crewMemberRepository = crewMemberRepository;
            _castMemberRepository = castMemberRepository;
            _languageRepository = languageRepository;
            _genreRepository = genreRepository;
            _videoRepository = videoRepository;
            _keywordRepository = keywordRepository;
            _countryRepository = countryRepository;
        }

        protected override void RemoveDuplicates(IEnumerable<MovieDto> data)
        {
            foreach (var movieDto in data)
            {
                if (movieDto.Credit != null)
                {
                    movieDto.Credit.CrewMembers = movieDto.Credit.CrewMembers.Distinct();
                    movieDto.Credit.CastMembers = movieDto.Credit.CastMembers.Distinct();
                }

                if (movieDto.Videos != null)
                {
                    movieDto.Videos.Videos = movieDto.Videos.Videos.Distinct();
                }

                movieDto.Genres = movieDto.Genres.Distinct();
                movieDto.ProductionCompanies = movieDto.ProductionCompanies.Distinct();
                movieDto.SpokenLanguages = movieDto.SpokenLanguages.Distinct();
                movieDto.Keywords = movieDto.Keywords.Distinct();
                movieDto.ProductionCountries = movieDto.ProductionCountries.Distinct();
            }
        }

        protected override async Task SaveChildObjects(ICollection<MovieDto> data)
        {
            await _companyRepository.AddIfNotExistent(data.SelectMany(x => x.ProductionCompanies).Distinct());
            await _crewMemberRepository.AddIfNotExistent(data.SelectMany(x => x.Credit?.CrewMembers).Distinct());
            await _castMemberRepository.AddIfNotExistent(data.SelectMany(x => x.Credit?.CastMembers).Distinct());
            await _languageRepository.AddIfNotExistent(data.SelectMany(x => x.SpokenLanguages).Distinct());
            await _genreRepository.AddIfNotExistent(data.SelectMany(x => x.Genres).Distinct());
            await _videoRepository.AddIfNotExistent(data.SelectMany(x => x.Videos?.Videos).Distinct());
            await _keywordRepository.AddIfNotExistent(data.SelectMany(x => x.Keywords).Distinct());
            await _countryRepository.AddIfNotExistent(data.SelectMany(x => x.ProductionCountries).Distinct());
        }

        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            return await Repository.Get();
        }

        public async Task<MovieDto> GetMovieInfo(int id)
        {
            return await Repository.GetMovie(id);
        }
    }
}