using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var firstLine = Console.ReadLine().Split(separator: ' ');
        var X         = int.Parse(s: firstLine[0]);
        var Y         = int.Parse(s: firstLine[1]);

        var ans = ((X + Y) - 1) % 12;
        Console.WriteLine(value: ans + 1);
    }
}
