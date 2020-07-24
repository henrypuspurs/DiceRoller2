using System;
using Xunit;
using DiceRoller.Library;
using Xunit.Sdk;

namespace DiceRoller.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Roll_StaysWithinBounds()
        {
            var diceTray = new DiceTray("d20", "1", "0", VantageType.NoVantage);

            var actual = diceTray.Rolls;

            Assert.InRange(actual[0], 1, 20);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("10")]
        [InlineData("20")]
        public void Roll_LengthIsSetByDice(string diceCount)
        {
            var diceTray = new DiceTray("d20", diceCount, "0", VantageType.NoVantage);
            int expected = int.Parse(diceCount);

            var actual = diceTray.Rolls.Length;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(VantageType.Advantage)]
        [InlineData(VantageType.Disadvantage)]
        public void VantageType_LimitsDiceCount(VantageType vantageType)
        {
            var diceTray = new DiceTray("d20", "5", "0", vantageType);
            int expected = 2;

            var actual = diceTray.DiceCount;

            Assert.Equal(expected, actual);
        }
    }
}
