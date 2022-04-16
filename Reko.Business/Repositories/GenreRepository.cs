using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public class GenreRepository : CRUDRepository<Genre, GenreDto, RekoDbContext, int>, IGenreRepository
    {
        public GenreRepository(RekoDbContext context) : base(context)
        {
        }
    }
}