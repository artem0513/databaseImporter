using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reko.Contracts;
using Reko.Contracts.Managers;
using Reko.Models;

namespace Reko.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataCollectorManager _dataCollectorManager;

        public HomeController(IDataCollectorManager dataCollectorManager)
        {
            _dataCollectorManager = dataCollectorManager;
        }

        [HttpPost]
        public IActionResult Run([FromForm] RunSchedulerModel request)
        {
            var summary = _dataCollectorManager.Collect(request.From, request.To);
            return View(model: summary);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}