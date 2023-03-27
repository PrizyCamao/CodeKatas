using System.Security.Cryptography.X509Certificates;

namespace HappyNumbers;

internal class HappyNumberGenerator
{
    private Dictionary<int, bool> NumberIsHappy = new Dictionary<int, bool>();

    public List<int> GetHappyNumbers()
    {
        var startNumber = 1;
        var lastNumber = 20;

        for(int i = startNumber; i <= lastNumber; i++) {
            var history = new List<int>();
            var isHappy = IsHappyNumber(i, history);

            history.ForEach(item =>
            {
                NumberIsHappy.Add(item, isHappy);
            });
        }

        return NumberIsHappy
            .Where(x => x.Value == true)
            .Select(x => x.Key)
            .OrderBy(x => x)
            .ToList();
    }

    private bool IsHappyNumber(int number, List<int> history)
    {
        if(history.Count > 10) return false;

        bool isHappy;
        if (NumberIsHappy.TryGetValue(number, out isHappy) || history.Any(x => x == number))
        {
            return isHappy;
        }

        history.Add(number);

        var digits = GetDigits(number);
        var multiplicated = digits.Sum(digit => digit * digit);

        return multiplicated == 1 ? true : IsHappyNumber(multiplicated, history);
    }

    private List<int> GetDigits(int number)
    {
        return number.ToString().Select(c => int.Parse(c.ToString())).ToList();
    }
}