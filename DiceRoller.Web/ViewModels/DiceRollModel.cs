using DiceRoller.Library;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiceRoller.Web.Models
{
    public class DiceRollModel
    {
        [BindProperty, Required]
        public string DiceType { get; set; } = "20";
        [BindProperty, Required]
        public string DiceCount { get; set; } = "1";
        [BindProperty]
        public VantageType VantageType { get; set; } = VantageType.NoVantage;
        [BindProperty, Required]
        public string Bonus { get; set; } = "0";
        public IRollMessage RollResult { get; set; }
        public List<IRollMessage> History { get; set; }
    }
}
