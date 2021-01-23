using DiceRoller.Library;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiceRoller.Web.Models
{
    public class DiceRollModel
    {
        private IRollMessage _rollResult;
        [BindProperty, Required]
        public string DiceType { get; set; } = "20";
        [BindProperty, Required]
        public string DiceCount { get; set; } = "1";
        [BindProperty]
        public VantageType VantageType { get; set; } = VantageType.NoVantage;
        [BindProperty, Required]
        public string Bonus { get; set; } = "0";
        public IRollMessage RollResult
        {
            get
            {
                return _rollResult;
            }
            set
            {
                _rollResult = value;
                RollHistory.Add(value);
            }
        }

        public List<IRollMessage> RollHistory { get; private set; } = new List<IRollMessage>();
    }
}
