using System.Diagnostics;
using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        byte N, M;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            N = byte.Parse(s: line[0]);
            M = byte.Parse(s: line[1]);
        }
        Debug.WriteLine(message: $"N: {N}");
        Debug.WriteLine(message: $"M: {M}");

        var result = N >= ((M * 2) - 1);
        Debug.WriteLine(message: $"result: {result}");
        Console.Write(value: result ? "Yes" : "No");
    }
}
