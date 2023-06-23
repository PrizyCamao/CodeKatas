using Xunit;

namespace TDD;

public class GameTests
{
    [Fact]
    public void Game_10rounds_NoStrikes_NoSpares()
    {

        var throws = Enumerable.Range(0, 20).Select(i => 3).ToList();
        var game = new Game();
        foreach (var i in throws)
        {
            game.roll(i);
        }
        Assert.Equal(60, game.score());
    }

    [Theory]
    [InlineData(new int[] {
            9, 1,
            5, 4,
            0, 0,
            0, 0,
            0, 0,
            0, 0,
            0, 0,
            0, 0,
            0, 0,
            0, 0
        }, 24)]
    public void Game_Spare_Sum(int[] throws, int expectedSum)
    {
        var game = new Game();
        foreach (var i in throws)
        {
            game.roll(i);
        }
        Assert.Equal(expectedSum, game.score());
    }

    [Theory]
    [InlineData(new int[] {
            10,
            3, 5
        }, 26)]
    public void Game_Strike_Sum(int[] throws, int expectedSum)
    {
        var game = new Game();
        foreach (var i in throws)
        {
            game.roll(i);
        }
        Assert.Equal(expectedSum, game.score());
    }
}