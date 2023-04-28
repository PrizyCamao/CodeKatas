namespace Ordered_Jobs;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var sut = new OrderedJobs();

        sut.Register('c');
        sut.Register('b', 'a');
        sut.Register('c', 'b');

        var res = sut.Sort();

        Assert.Equal(3, res.Length);
    }

    [Fact]
    public void Sort_ReturnsCorrectJobOrder()
    {
        // Arrange
        var orderedJobs = new OrderedJobs();
        orderedJobs.Register('c');
        orderedJobs.Register('b', 'a');
        orderedJobs.Register('c', 'b');

        // Act
        var jobOrder = orderedJobs.Sort();

        // Assert
        Assert.Equal("abc", jobOrder);
    }
}