using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller.Library
{
    public class RollHistory : IRollHistory
    {
        public List<IRollMessage> Entries { get; set; } = new List<IRollMessage>();
    }
}
