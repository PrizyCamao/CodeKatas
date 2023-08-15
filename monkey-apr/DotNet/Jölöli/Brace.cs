using System.Text;

namespace Jölöli;

public class Brace
{
    public static bool validBraces(String braces)
    {
        if (braces.Length == 0)
        {
            return true;
        }

        if (braces.Length % 2 != 0
            || braces[0] == ')'
            || braces[0] == ']'
            || braces[0] == '}')
        {
            return false;
        }

        var i = braces.Length;
        do
        {
            if(!RemoveClosingBraces(out braces))
            {
                return false;
            }
            i--;
        } while (braces.Length > 0 || i == 0);

        return true;
    }

    private static bool RemoveClosingBraces(out String braces)
    {
        for (var i = 0; i < braces.Length; i++)
        {
            if (
                braces[i] == '(' && braces[i + 1] == ')'
                || braces[i] == '[' && braces[i + 1] == ']'
                || braces[i] == '{' && braces[i + 1] == '}'
                )
            {
                braces = braces.Remove(i, 2);
                return true;
            }
        }

        return false;
    }
}