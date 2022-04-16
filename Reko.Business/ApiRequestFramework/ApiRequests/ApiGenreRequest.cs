using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Reko.Business.ApiRequestFramework.ApiResponse;
using Reko.Contracts.ApiRequestFramework;
using Reko.Models.Dto;

namespace Reko.Business.ApiRequestFramework.ApiRequests
{
    public class ApiGenreRequest : ApiRequestBase, IApiGenreRequest
    {
        private static readonly List<GenreDto> _allGenres = new List<GenreDto>();

        public IEnumerable<GenreDto> AllGenres
        {
            get
            {
                if (_allGenres.Any() == false)
                {
                    var genres = Task.Run(() => GetAllAsync()).GetAwaiter().GetResult().Item;
                    _allGenres.AddRange(genres);
                }

                return _allGenres.AsReadOnly();
            }
        }

        [ImportingConstructor]
        public ApiGenreRequest(IMovieDbSettings settings)
            : base(settings)
        {
        }

        public async Task<IApiQueryResponse<GenreDto>> FindByIdAsync(int genreId)
        {
            var param = new Dictionary<string, string>
            {
                {"language", "en"}
            };

            var command = $"genre/{genreId}";

            var response = await QueryAsync<GenreDto>(command, param);

            EnsureAllGenres(response);

            return response;
        }

        public async Task<IApiQueryResponse<IReadOnlyList<GenreDto>>> GetAllAsync(string language = "en")
        {
            var tv = await GetTelevisionAsync(language);
            if (tv.Error != null)
            {
                return tv;
            }

            var movies = await GetMoviesAsync(language);
            if (movies.Error != null)
            {
                return movies;
            }

            var merged = movies.Item
                .Union(tv.Item)
                .OrderBy(x => x.Name)
                .ToList();

            movies.Item = merged.AsReadOnly();

            return movies;
        }

        public async Task<IApiQueryResponse<IReadOnlyList<GenreDto>>> GetMoviesAsync(string language = "en")
        {
            var param = new Dictionary<string, string>
            {
                {"language", language},
            };

            var genres = await QueryAsync("genre/movie/list", param, GenreDeserializer);

            return genres;
        }

        public async Task<IApiQueryResponse<IReadOnlyList<GenreDto>>> GetTelevisionAsync(string language = "en")
        {
            var param = new Dictionary<string, string>
            {
                {"language", language},
            };

            var genres = await QueryAsync("genre/tv/list", param, GenreDeserializer);

            return genres;
        }

        public async Task<IApiSearchResponse<MovieInfoDto>> FindMoviesByIdAsync(int genreId, int pageNumber = 1, string language = "en")
        {
            var param = new Dictionary<string, string>
            {
                {"language", language},
                {"include_adult", "false"},
            };

            var command = $"genre/{genreId}/movies";

            var response = await SearchAsync<MovieInfoDto>(command, pageNumber, param);

            if (response.Error != null)
            {
                return response;
            }

            return response;
        }


        private static void EnsureAllGenres(ApiQueryResponse<GenreDto> response)
        {
            if (response.Error != null)
            {
                return;
            }

            if (response.Item == null)
            {
                return;
            }

            if (_allGenres.Contains(response.Item) == false)
            {
                _allGenres.Add(response.Item);
            }
        }

        private static IReadOnlyList<GenreDto> GenreDeserializer(string json)
        {
            var obj = JObject.Parse(json);

            var arr = (JArray) obj["genres"];

            var genres = arr.ToObject<IReadOnlyList<GenreDto>>();

            return genres;
        }
    }
}