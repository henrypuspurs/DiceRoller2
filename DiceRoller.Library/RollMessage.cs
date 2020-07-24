using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceRoller.Library
{
    public class RollMessage
    {
        public string RollResult { get; private set; }

        public RollMessage(DiceTray diceTray)
        {
            RollResult = $"You rolled {diceTray.DiceCount}d{diceTray.DiceType}+{diceTray.Bonus}\n" +
                $"Result: {diceTray.Rolls.Sum() + diceTray.Bonus}";
        }
    }
}
