using System;
using System.Threading;
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
        public IActionResult Run([FromForm] RunSchedulerModel request, CancellationToken cancellationToken)
        {
            if (request.From > request.To)
            {
                throw new ArgumentException("\"From\" date should be less than \"To\" date");
            }

            var summary = _dataCollectorManager.Collect(request.From, request.To, cancellationToken);
            return View(model: summary);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}