using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DiceRoller.Library
{
    public class DiceTray : IDiceTray
    {
        public int DiceType { get; private set; }
        public int DiceCount { get; private set; }
        public VantageType VantageType { get; private set; } = VantageType.NoVantage;
        public int Bonus { get; private set; }
        public int[] Rolls { get; private set; }
        public Crit Crit { get; private set; } = Crit.False;

        public void DiceRoll(string diceType, string diceCount, string bonus, VantageType vantageType = VantageType.NoVantage)
        {
            var stringToInt = new StringToInt();
            Bonus = stringToInt.ZeroOrGreater(bonus);
            DiceCount = stringToInt.OneOrGreater(diceCount);
            DiceType = stringToInt.OneOrGreater(diceType);
            VantageType = vantageType;
            CheckVantageType();
            RollDice();
            Crit = CheckIfCrit();
        }

        private void RollDice()
        {
            Rolls = new int[DiceCount];
            var r = new Random();
            for (int i = 0; i < DiceCount; i++)
            {
                Rolls[i] = r.Next(1, DiceType + 1);
            }
        }

        private void CheckVantageType()
        {
            if (VantageType != VantageType.NoVantage && DiceCount >= 1)
            {
                DiceCount = 2;
            }
        }

        private Crit CheckIfCrit()
        {
            if (Rolls.Max() == 20 && DiceType == 20 && VantageType != VantageType.Disadvantage)
            {
                return Crit.CriticalSuccess;
            }
            else if (Rolls.Min() == 1 && DiceType == 20 && VantageType != VantageType.Advantage)
            {
                return Crit.CriticalFail;
            }
            else
            {
                return Crit.False;
            }
        }
    }

    public enum VantageType
    {
        NoVantage,
        Advantage,
        Disadvantage
    }

    public enum Crit
    {
        False,
        CriticalSuccess,
        CriticalFail
    }
}
