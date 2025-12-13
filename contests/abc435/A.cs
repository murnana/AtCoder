using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        var N      = byte.Parse(s: Console.ReadLine());
        var result = 0;

        for(var i = 1 ; i <= N ; i++)
        {
            result += i;
        }

        Console.WriteLine(value: result);
    }
}
