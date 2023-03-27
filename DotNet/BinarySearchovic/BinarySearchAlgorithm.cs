namespace BinarySearchovic;

public class BinarySearchAlgorithm : IBinarySearchAlgorithm
{
    public int[] Numbers { get; private set; }

    public BinarySearchAlgorithm(int[] numbers)
    {
        Numbers = numbers;
    }

    public int Search(int searched)
    {
        int ende = Numbers.Length;
        for(var start = 0; true;)
        {
            int index = start + (ende - start) / 2;

            var compare = Numbers[index];

            if (compare == searched)
            {
                return index;
            }

            if(start == ende + 1 || start == ende - 1)
            {
                throw new Exception("gibet ned");
            }

            if(searched > compare)
            {
                start = index;
            }
            else
            {
                ende = index;
            }
        }
    }
}
