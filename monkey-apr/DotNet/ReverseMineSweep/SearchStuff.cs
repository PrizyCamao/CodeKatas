namespace ReverseMineSweep;

public class SearchStuff : ISearchStuff
{
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

    public Table Search(Table field)
    {
        for (int x = 0; x < field._lengthX; x++)
        {
            for (int y = 0; y < field._lengthY; y++)
            {
                if (field[x, y] != "*")
                {
                    field[x, y] = field.GetMineCount(x, y).ToString();
                }
            }
        }

        return field;
    }
}
