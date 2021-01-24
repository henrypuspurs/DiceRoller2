using System.Collections.Generic;

namespace DiceRoller.Library
{
    public interface IRollHistory
    {
        List<IRollMessage> Entries { get; set; }
    }
}