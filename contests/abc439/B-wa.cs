using System.Diagnostics;
using System.Globalization;
using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        var line     = Console.ReadLine()!;
        var minValue = int.Parse(s: line);
        var current  = minValue;
        do
        {
            Debug.WriteLine(message: "------");
            current = line.Select(selector: c => int.Parse(s: string.Empty + c))
                          .Select(selector: number => (int)Math.Pow(x: number, y: 2))
                          .Sum();
            Debug.WriteLine("current result: {0}", current);
            Debug.WriteLine("prev minValue: {0}", minValue);
            if(current == 1)
            {
                Console.WriteLine(value: "Yes");
                return;
            }

            if(current == 0)
            {
                Console.WriteLine(value: "No");
                return;
            }

            line     = current.ToString(provider: CultureInfo.InvariantCulture);
            minValue = Math.Min(val1: minValue, val2: current);
        } while(minValue == current);

        Console.WriteLine(value: "No");
    }
}
