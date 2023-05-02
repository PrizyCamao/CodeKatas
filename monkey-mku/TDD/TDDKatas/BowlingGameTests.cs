namespace TDDKatas
{
    public class BowlingGameTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void Bowling_SingleRoll_ReturnsPinsRolled(int pins)
        {
            var game = new BowlingGame();
            
            game.Roll(pins);
            var result = game.Score();

            Assert.Equal(pins, result);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(-1)]
        public void Bowling_InvalidRoll_ScoreNotUpdated(int pins)
        {
            var game = new BowlingGame();

            game.Roll(pins);
            var result = game.Score();

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(5, 4)]
        [InlineData(4, 5)]
        [InlineData(3, 4)]
        [InlineData(1, 8)]
        [InlineData(10, 0)]
        [InlineData(5, 5)]
        public void Bowling_MultipleRolls_ReturnTotalScore(int firstRoll, int secondRoll)
        {
            var game = new BowlingGame();

            game.Roll(firstRoll);
            game.Roll(secondRoll);

            var result = game.Score();

            Assert.Equal(firstRoll + secondRoll, result);
        }

        [Theory]
        [InlineData(10, 5, 5, 30)]
        [InlineData(10, 4, 2, 22)]
        [InlineData(10, 3, 6, 28)]
        [InlineData(10, 2, 2, 18)]
        [InlineData(10, 9, 0, 28)]
        [InlineData(10, 0, 9, 28)]
        [InlineData(10, 0, 10, 30)]
        [InlineData(10, 10, 0, 30)]
        public void Bowling_FirstRollStrike_NextFrameDouble(int firstRoll, int secondRoll, int thirdRoll, int expectedResult)
        {
            var game = new BowlingGame();

            game.Roll(firstRoll);
            game.Roll(secondRoll);
            game.Roll(thirdRoll);

            var result = game.Score();

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(9, 1, 5, 20)]
        [InlineData(5, 5, 10, 30)]
        [InlineData(3, 7, 0, 10)]
        public void Bowling_Spare_ThirdRollDoubled(int first, int second, int third, int expectedResult)
        {
            var game = new BowlingGame();

            game.Roll(first);
            game.Roll(second);
            game.Roll(third);

            var result = game.Score();

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(9, 1, 5, 4, 24)]
        [InlineData(5, 5, 10, 0, 30)]
        [InlineData(3, 7, 0, 5, 15)]
        public void Bowling_Spare_ThirdRollDoubledFourthRollNotDoubled(int first, int second, int third, int fourth, int expectedResult)
        {
            var game = new BowlingGame();

            game.Roll(first);
            game.Roll(second);
            game.Roll(third);
            game.Roll(fourth);

            var result = game.Score();

            Assert.Equal(expectedResult, result);
        }
    }
}