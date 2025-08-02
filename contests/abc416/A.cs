using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var firstLine = Console.ReadLine().Split(separator: ' ');
        var N         = int.Parse(s: firstLine[0]);
        var L         = int.Parse(s: firstLine[1]);
        var R         = int.Parse(s: firstLine[2]);

        var S     = Console.ReadLine();
        var isYes = false;
        for (var i = L - 1; i < Math.Min(val1: R, val2: N); i++)
        {
            if (S[index: i] == 'o')
            {
                isYes = true;
                continue;
            }

            isYes = false;
            break;
        }

        Console.WriteLine(value: isYes ? "Yes" : "No");
    }
}
