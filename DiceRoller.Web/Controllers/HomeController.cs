using DiceRoller.Library;
using DiceRoller.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DiceRoller.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DiceRollModel diceRoll)
        {
            var dicetray = new DiceTray(diceRoll.DiceType, diceRoll.DiceCount, diceRoll.Bonus, diceRoll.VantageType);
            diceRoll.RollResult = new RollMessage(dicetray);
            ViewData["RollResults"] = diceRoll.RollResult;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
