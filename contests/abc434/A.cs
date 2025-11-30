using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        byte W, B;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            W = byte.Parse(s: line[0]);
            B = byte.Parse(s: line[1]);
        }

        // 何グラム?
        var need = W * 1000;

        // 風船いくつ?
        var needCount = need / B;
        Console.WriteLine(value: (needCount * B) > need ? needCount : needCount + 1);
    }
}
