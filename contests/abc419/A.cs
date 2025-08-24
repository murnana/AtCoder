using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var knownWords = new Dictionary<string, string>(capacity: 3)
        {
            { "red", "SSS" },
            { "blue", "FFF" },
            { "green", "MMM" }
        };

        var S = Console.ReadLine();
        Console.WriteLine(value: knownWords.GetValueOrDefault(key: S, defaultValue: "Unknown"));
    }
}
