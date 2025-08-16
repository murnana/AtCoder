using System.Globalization;
using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var firstLine = Console.ReadLine().Split(' ');
        var N = int.Parse(firstLine[0]);
        var M = int.Parse(firstLine[1]);

        var A = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
        var B = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

        foreach (var b in B) A.Remove(b);

        Console.WriteLine(string.Join(' ', A.Select(a => a.ToString(CultureInfo.InvariantCulture))));
    }
}
