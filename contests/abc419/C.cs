using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var N = long.Parse(s: Console.ReadLine()); // 人数
        long maxR = long.MinValue,
             maxC = long.MinValue,
             minR = long.MaxValue,
             minC = long.MaxValue;
        for (var i = 0; i < N; i++)
        {
            var read = Console.ReadLine().Split(separator: ' ');
            var R    = long.Parse(s: read[0]);
            var C    = long.Parse(s: read[1]);

            maxR = Math.Max(val1: maxR, val2: R);
            maxC = Math.Max(val1: maxC, val2: C);
            minR = Math.Min(val1: minR, val2: R);
            minC = Math.Min(val1: minC, val2: C);
        }

        var RLength = maxR - minR;
        var CLength = maxC - minC;
        var length  = Math.Max(RLength, CLength);
        Console.WriteLine(value: length / 2);
    }
}
