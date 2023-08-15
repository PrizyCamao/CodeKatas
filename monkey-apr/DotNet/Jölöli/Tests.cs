namespace Jölöli;

public class Tests
{
    [Fact]
    public void WalkService_ShouldBeTrue()
    {
        Assert.True(WalkService.IsValidWalk(new string[] { "n", "s", "n", "s", "n", "s", "n", "s", "n", "s" }));
    }

    [Fact]
    public void WalkService_ShouldBeFalse()
    {
        Assert.False(WalkService.IsValidWalk(new string[] { "w", "e", "w", "e", "w", "e", "w", "e", "w", "e", "w", "e" }));
        Assert.False(WalkService.IsValidWalk(new string[] { "w" }));
        Assert.False(WalkService.IsValidWalk(new string[] { "n", "n", "n", "s", "n", "s", "n", "s", "n", "s" }));
    }

    [Fact]
    public void Brace_ShouldBeTrue()
    {
        Assert.True(Brace.validBraces("()"));
    }

    [Fact]
    public void Brace_ShouldBeFalse()
    {
        Assert.False(Brace.validBraces("[(])"));
    }

    [Fact]
    public void Brace_ShouldBeTreueueueue()
    {
        Assert.True(Brace.validBraces("{}({}())[]"));
    }
}