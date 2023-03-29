using Xunit;

namespace ReverseMineSweep;

public class SearchStuffTest
{
    [Fact]
    public void Search_1MineAtLeftSide_1sAnd0s()
    {
        var field = new string[3,3] {
            { ".", ".", "." },
            { "*", ".", "." },
            { ".", ".", "." }
        };
        var expected = new string[3,3] {
            { "1", "1", "0" },
            { "*", "1", "0" },
            { "1", "1", "0" }
        };

        var table = new Table(field, 3, 3);
        var expectedTable = new Table(expected, 3, 3);

        ISearchStuff instance = new SearchStuff();
        var result = instance.Search(table);

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                Assert.Equal(expectedTable[x, y], result[x, y]);
            }
        }
    }

    [Fact]
    public void Search_MultipleMines_No0sLotsOfHigherValues()
    {
        var field = new string[3, 3] {
            { ".", ".", "." },
            { "*", "*", "." },
            { ".", "*", "." }
        };
        var expected = new string[3, 3] {
            { "2", "2", "1" },
            { "*", "*", "2" },
            { "3", "*", "2" }
        };

        var table = new Table(field, 3, 3);
        var expectedTable = new Table(expected, 3, 3);

        ISearchStuff instance = new SearchStuff();
        var result = instance.Search(table);

        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                Assert.Equal(expectedTable[x, y], result[x, y]);
            }
        }
    }
}