using System;
using System.Text.RegularExpressions;

namespace DiceRoller.Library
{
    public class DiceTray
    {
        public int DiceType { get; private set; }
        public int DiceCount { get; private set; }
        public VantageType VantageType { get; private set; } = VantageType.NoVantage;
        public int Bonus { get; private set; }
        public int[] Rolls { get; private set; }

        public DiceTray(string diceType, string diceCount, string bonus)
        {
            Bonus = int.Parse(bonus);
            DiceCount = int.Parse(diceCount);
            DiceType = int.Parse(Regex.Replace(diceType, @"d", ""));
            RollDice();
        }

        private void RollDice()
        {
            Rolls = new int[DiceCount];
            var r = new Random();
            for (int i=0; i < DiceCount; i++)
            {
                Rolls[i] = r.Next(1, DiceType + 1);
            }
        }
    }

    public enum VantageType
    {
        NoVantage,
        Advantage,
        Disadvantage
    }
}
