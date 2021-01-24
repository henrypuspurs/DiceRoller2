using DiceRoller.Library;
using DiceRoller.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace DiceRoller.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDiceTray _diceTray;
        private readonly IRollMessage _rollMessage;
        private readonly IRollHistory _rollHistory;

        public HomeController(ILogger<HomeController> logger, IDiceTray diceTray, IRollMessage rollMessage, IRollHistory rollHistory)
        {
            _logger = logger;
            _diceTray = diceTray;
            _rollMessage = rollMessage;
            _rollHistory = rollHistory;
        }

        public IActionResult Index()
        {
            return View(new DiceRollModel());
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DiceRollModel diceRoll)
        {
            _diceTray.DiceRoll(diceRoll.DiceType, diceRoll.DiceCount, diceRoll.Bonus, diceRoll.VantageType);
            _rollMessage.RollMessages(_diceTray);
            diceRoll.RollResult = _rollMessage;
            _rollHistory.Entries.Add(_rollMessage);
            diceRoll.History = _rollHistory.Entries;
            return View(diceRoll);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
