namespace DiceRoller.Library
{
    public interface IRollMessage
    {
        string CritMessage { get; }
        Crit CritValue { get; }
        string Result { get; }
        string RollMade { get; }
        string Rolls { get; }

        string CritAsString(IDiceTray diceTray);
        void RollMessages(IDiceTray diceTray);
    }
}