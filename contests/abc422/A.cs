using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var split = Console.ReadLine().Split(separator: '-');
        var i     = int.Parse(s: split[0]);
        var j     = int.Parse(s: split[1]);

        if (i >= 8)
        {
            Console.WriteLine(value: $"{i}-{Math.Max(val1: 8, val2: j + 1)}");
        }
        else
        {
            if (j >= 8)
            {
                Console.WriteLine(value: $"{i + 1}-1");
            }
            else
            {
                Console.WriteLine(value: $"{i}-{j + 1}");
            }
        }
    }
}
