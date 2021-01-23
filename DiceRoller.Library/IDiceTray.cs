namespace DiceRoller.Library
{
    public interface IDiceTray
    {
        int Bonus { get; }
        Crit Crit { get; }
        int DiceCount { get; }
        int DiceType { get; }
        int[] Rolls { get; }
        VantageType VantageType { get; }

        void DiceRoll(string diceType, string diceCount, string bonus, VantageType vantageType = VantageType.NoVantage);
    }
}