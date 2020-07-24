using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller.Library
{
    public class RollMessage
    {
        public string ComposeMessage(DiceTray diceTray)
        {
            if (diceTray.VantageType == VantageType.NoVantage)
            {
                return $"You rolled {diceTray.DiceCount}d{diceTray.DiceType} +{diceTray.Bonus}\n\n" +
                    $"{string.Join(", ", diceTray.Rolls)}\n" +
                    $"Result: {diceTray.Rolls.Sum() + diceTray.Bonus}";
            }
            else if (diceTray.VantageType == VantageType.Advantage)
            {
                return $"You rolled {diceTray.DiceCount}d{diceTray.DiceType} +{diceTray.Bonus}\n" +
                    $"{string.Join(", ", diceTray.Rolls)}\n" +
                    $"Result: {diceTray.Rolls.Max() + diceTray.Bonus}";
            }
            else if (diceTray.VantageType == VantageType.Disadvantage)
            {
                return $"You rolled {diceTray.DiceCount}d{diceTray.DiceType} +{diceTray.Bonus}\n" +
                    $"{string.Join(", ", diceTray.Rolls)}\n" +
                    $"Result: {diceTray.Rolls.Min() + diceTray.Bonus}";
            }
            else
            {
                return "Oops, something went wrong";
            }
        }

        public string ComposeCaption(DiceTray diceTray)
        {
            if (diceTray.Crit == Crit.False)
            {
                return "Your Rolls:";
            }
            else if (diceTray.Crit == Crit.CriticalSuccess)
            {
                return "CRITICAL HIT";
            }
            else if (diceTray.Crit == Crit.CriticalFail)
            {
                return "CRITICAL FAIL";
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
