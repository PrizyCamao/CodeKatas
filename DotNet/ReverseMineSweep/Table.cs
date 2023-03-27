namespace ReverseMineSweep;

public class Table
{
    public int _lengthX { get; init; }
    public int _lengthY { get; init; }

    private string[,] _data;
    private readonly List<(int, int)> SearchMatrix = new List<(int, int)> {
        ( -1, -1 ),
        ( -1, 0 ),
        ( -1, 1 ),
        ( 0, -1 ),
        ( 0, 1 ),
        ( 1, -1 ),
        ( 1, 0 ),
        ( 1, 1 )
    };

    public Table(string[,] data, int lengthX, int lengthY)
    {
        _data = data;
        _lengthX = lengthX;
        _lengthY = lengthY;
    }

    public string this[int indexX, int indexY]
    {
        get => _data[indexX, indexY];
        set => _data[indexX, indexY] = value;
    }

    public int GetMineCount(int x, int y)
    {
        return SearchMatrix.Count(tubbel =>
        {
            if (x == 0 && tubbel.Item1 == -1
            || y == 0 && tubbel.Item2 == -1
            || x == _lengthX - 1 && tubbel.Item1 == 1
            || y == _lengthY - 1 && tubbel.Item2 == 1)
            {
                return false;
            }

            return _data[x + tubbel.Item1, y + tubbel.Item2] == "*";
        });
    }
}
