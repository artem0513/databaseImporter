using System.Collections.Generic;
using Reko.Contracts.Containers;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Contracts.EntityStorages
{
    public interface IMovieEntityStorage : IEntityStorage<IUniqueMovieDataContainer, MovieDto, int>
    {
        CollectionInfo GetEntityCollectionInfo(int id);
        Dictionary<MovieDto, Movie> GetMovies();
        IEnumerable<Language> GetEntityLanguage(IEnumerable<string> ids);
        IEnumerable<Country> GetEntityCountry(IEnumerable<string> ids);
    }
}