using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        var N = byte.Parse(s: Console.ReadLine());
        var A = new List<byte>(capacity: N);
        {
            var line = Console.ReadLine().Split(separator: ' ');
            for(byte i = 0 ; i < N ; i++)
            {
                var a     = byte.Parse(s: line[i]);
                var index = A.FindLastIndex(match: item => item > a);
                Console.WriteLine(value: index >= 0 ? index + 1 : -1);

                A.Add(item: a);
            }
        }
    }
}
