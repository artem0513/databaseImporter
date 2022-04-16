using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reko.Contracts.Managers;

namespace Reko.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IMovieManager _movieManager;
        private readonly ITVShowManager _tvShowManager;

        public InfoController(IMovieManager movieManager, ITVShowManager tvShowManager)
        {
            _movieManager = movieManager;
            _tvShowManager = tvShowManager;
        }

        [Route("[action]/{movieId}")]
        public async Task<ObjectResult> GetMovieInfo(int movieId)
        {
            return Ok(await _movieManager.GetMovieInfo(movieId));
        }

        [Route("[action]")]
        public async Task<ObjectResult> GetMovies()
        {
            return Ok(await _movieManager.GetMovies());
        }

        [Route("[action]")]
        public async Task<ObjectResult> GetTvShows()
        {
            return Ok(await _tvShowManager.GetTvShows());
        }

        [Route("[action]/{tvShowId}")]
        public async Task<ObjectResult> GetTvShowInfo(int tvShowId)
        {
            return Ok(await _tvShowManager.GetTvShowInfo(tvShowId));
        }
    }
}