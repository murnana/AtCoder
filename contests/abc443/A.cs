using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        var S = Console.ReadLine();
        Console.WriteLine(value: S + 's');
    }
}
