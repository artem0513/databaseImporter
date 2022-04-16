using System.Threading;
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
        public async Task<ObjectResult> GetMovieInfo(int movieId, CancellationToken cancellationToken)
        {
            return Ok(await _movieManager.GetMovieInfo(movieId, cancellationToken));
        }

        [Route("[action]")]
        public async Task<ObjectResult> GetMovies(CancellationToken cancellationToken)
        {
            return Ok(await _movieManager.Get(cancellationToken));
        }

        [Route("[action]")]
        public async Task<ObjectResult> GetTvShows(CancellationToken cancellationToken)
        {
            return Ok(await _tvShowManager.Get(cancellationToken));
        }

        [Route("[action]/{tvShowId}")]
        public async Task<ObjectResult> GetTvShowInfo(int tvShowId, CancellationToken cancellationToken)
        {
            return Ok(await _tvShowManager.GetTvShowInfo(tvShowId, cancellationToken));
        }
    }
}