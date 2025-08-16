using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var firstLine = Console.ReadLine().Split(' ');
        var N = int.Parse(firstLine[0]);
        var A = int.Parse(firstLine[1]);
        var B = int.Parse(firstLine[2]);

        var S = Console.ReadLine();
        Console.WriteLine(string.Concat(S.Skip(A).SkipLast(B)));
    }
}
