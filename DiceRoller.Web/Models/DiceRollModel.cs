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
        [BindProperty, Required]
        public string DiceType { get; set; }
        [BindProperty, Required]
        public string DiceCount { get; set; }
        [BindProperty]
        public VantageType VantageType { get; set; }
        [BindProperty, Required]
        public string Bonus { get; set; }

        public RollMessage RollDice()
        {
            var diceTray = new DiceTray(DiceType, DiceCount, Bonus, VantageType);
            return new RollMessage(diceTray);
        }
    }
}
