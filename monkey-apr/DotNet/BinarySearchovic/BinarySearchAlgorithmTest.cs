namespace BinarySearchovic;

public class BinarySearchAlgorithmTest
{
    [Theory]
    [InlineData(1, 0)]
    [InlineData(5, 1)]
    [InlineData(11, 2)]
    [InlineData(15, 3)]
    [InlineData(21, 4)]
    [InlineData(32, 5)]
    [InlineData(45, 6)]
    [InlineData(55, 7)]
    [InlineData(88, 8)]
    [InlineData(100, 9)]
    public void Valids(int searched, int expected)
    {
        IBinarySearchAlgorithm search = new BinarySearchAlgorithm(new[] { 1, 5, 11, 15, 21, 32, 45, 55, 88, 100 });

        var i = search.Search(searched);
        Assert.Equal(expected, i);
    }

    [Theory]
    [InlineData(0, 10000, 45, 45)]
    [InlineData(0, 500000, 88000, 88000)]
    [InlineData(500, 1000, 555, 55)]
    [InlineData(0, 1, 0, 0)]
    public void ValidsGeneratedData(int start, int count, int searched, int? expected)
    {
        var data = Enumerable.Range(start, count);

        IBinarySearchAlgorithm search = new BinarySearchAlgorithm(data.ToArray());

        var i = search.Search(searched);
        Assert.Equal(expected, i);
    }

    [Fact]
    public void ExceptionThrowingShittovic()
    {
        IBinarySearchAlgorithm search = new BinarySearchAlgorithm(new[] { 1, 5, 11, 15, 21, 32, 45, 55, 88, 100 });

        Assert.Throws<Exception>(() => search.Search(2));
    }
}