using Xunit;

namespace Ordered_Jobs;

public class OrderedJobsTests
{
    [Fact]
    public void Sort_ReturnsEmptyString_WhenNoJobsRegistered()
    {
        // Arrange
        var orderedJobs = new OrderedJobs();

        // Act
        var result = orderedJobs.Sort();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Sort_ReturnsSingleJob_WhenSingleJobRegistered()
    {
        // Arrange
        var orderedJobs = new OrderedJobs();
        orderedJobs.Register('a');

        // Act
        var result = orderedJobs.Sort();

        // Assert
        Assert.Equal("a", result);
    }

    [Fact]
    public void Sort_ReturnsJobsInCorrectOrder_WhenMultipleJobsRegistered()
    {
        // Arrange
        var orderedJobs = new OrderedJobs();
        orderedJobs.Register('a');
        orderedJobs.Register('b', 'a');
        orderedJobs.Register('c', 'b');

        // Act
        var result = orderedJobs.Sort();

        // Assert
        Assert.Equal("abc", result);
    }

    [Fact]
    public void Register_ThrowsException_WhenCircularDependencyDetected()
    {
        // Arrange
        var orderedJobs = new OrderedJobs();
        orderedJobs.Register('a', 'b');
        orderedJobs.Register('b', 'c');
        orderedJobs.Register('c', 'a');

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() => orderedJobs.Sort());
        Assert.Equal("Circular dependency detected.", ex.Message);
    }

    [Fact]
    public void Sort_ReturnsJobsInCorrectOrder_WhenMultipleJobsRegisteredWithIndependentJobs()
    {
        // Arrange
        var orderedJobs = new OrderedJobs();
        orderedJobs.Register('a');
        orderedJobs.Register('b');
        orderedJobs.Register('c', 'a');
        orderedJobs.Register('d', 'c');
        orderedJobs.Register('e', 'b');

        // Act
        var result = orderedJobs.Sort();

        // Assert
        Assert.Equal("abcde", result);
    }

    [Fact]
    public void Sort_ReturnsJobsInCorrectOrder_WhenMultipleJobsRegisteredWithMultipleDependencies()
    {
        // Arrange
        var orderedJobs = new OrderedJobs();
        orderedJobs.Register('a', 'b');
        orderedJobs.Register('b', 'c');
        orderedJobs.Register('c', 'd');
        orderedJobs.Register('e', 'd');

        // Act
        var result = orderedJobs.Sort();

        // Assert
        Assert.Equal("edcba", result);
    }
}
