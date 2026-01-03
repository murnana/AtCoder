using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        var N = byte.Parse(s: Console.ReadLine());

        Console.WriteLine(value: (int)(Math.Pow(x: 2, y: N) - (2 * N)));
    }
}
