namespace Jölöli;

public class WalkService
{
    public static readonly string NORTH = "n";
    public static readonly string SOUTH = "s";
    public static readonly string EAST = "e";
    public static readonly string WEST = "w";

    private static (int ns, int ow) _directionCounter = (0, 0);

    public static bool IsValidWalk(string[] walk)
    {
        if (walk.Length != 10)
        {
            return false;
        }

        _directionCounter = (0, 0);

        foreach (var step in walk)
        {
            if(step is null)
            {
                return false;
            }

            if (IsNS(step))
            {
                _directionCounter.ns += step == NORTH ? 1 : -1;
            }
            else
            {
                _directionCounter.ow += step == EAST ? 1 : -1;
            }
        }

        return _directionCounter.ns == 0 && _directionCounter.ow == 0;
    }

    private static bool IsNS(string step)
    {
        return step == NORTH || step == SOUTH;
    }
}
