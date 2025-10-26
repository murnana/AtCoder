using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        byte N, M;
        {
            var line = Console.ReadLine()!.Split(separator: ' ');
            N = byte.Parse(s: line[0]);
            M = byte.Parse(s: line[1]);
        }

        for(byte i = 1 ; i <= N ; i++)
        {
            Console.WriteLine(value: i <= M ? @"OK" : @"Too Many Requests");
        }
    }
}
