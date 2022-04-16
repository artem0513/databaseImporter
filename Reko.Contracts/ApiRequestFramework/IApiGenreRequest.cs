using System.Collections.Generic;
using System.Threading.Tasks;
using Reko.Models.Dto;

namespace Reko.Contracts.ApiRequestFramework
{
    public interface IApiGenreRequest : IApiRequest, IDetailsApiRequest<GenreDto, int>
    {
        IEnumerable<GenreDto> AllGenres { get; }

        Task<IApiQueryResponse<IReadOnlyList<GenreDto>>> GetAllAsync(string language = "en");

        Task<IApiQueryResponse<IReadOnlyList<GenreDto>>> GetMoviesAsync(string language = "en");

        Task<IApiQueryResponse<IReadOnlyList<GenreDto>>> GetTelevisionAsync(string language = "en");

        Task<IApiSearchResponse<MovieInfoDto>> FindMoviesByIdAsync(int genreId, int pageNumber = 1, string language = "en");
    }
}