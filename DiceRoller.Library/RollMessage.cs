using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller.Library
{
    public class RollMessage
    {
        public string RollMade { get; private set; }
        public string Rolls { get; private set; }
        public string Result { get; private set; }
        public string CritMessage { get; private set; }
        public Crit CritValue { get; private set; }

        public RollMessage(DiceTray diceTray)
        {
            RollMade = $"{diceTray.DiceCount}d{diceTray.DiceType} +{diceTray.Bonus}";
            Rolls = $"{string.Join(", ", diceTray.Rolls)}";
            Result = CalculateResult(diceTray);
            CritMessage = CritAsString(diceTray);
            CritValue = diceTray.Crit;
        }

        private string CalculateResult(DiceTray diceTray)
        {
            if (diceTray.VantageType == VantageType.NoVantage)
            {
                    return $"{diceTray.Rolls.Sum() + diceTray.Bonus}";
            }
            else if (diceTray.VantageType == VantageType.Advantage)
            {
                return $"{diceTray.Rolls.Max() + diceTray.Bonus}";
            }
            else if (diceTray.VantageType == VantageType.Disadvantage)
            {
                return $"{diceTray.Rolls.Min() + diceTray.Bonus}";
            }
            else
            {
                return "Oops, something went wrong";
            }
        }

        public string CritAsString(DiceTray diceTray)
        {
            if (diceTray.Crit == Crit.False)
            {
                return "Your Rolls:";
            }
            else if (diceTray.Crit == Crit.CriticalSuccess)
            {
                return "Natural 20!";
            }
            else if (diceTray.Crit == Crit.CriticalFail)
            {
                return "Natural 1!";
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
