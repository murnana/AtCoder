using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        int X;
        int Y;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            X = int.Parse(s: line[0]);
            Y = int.Parse(s: line[1]);
        }

        long prev = Y;
        var  a    = A(x: X, y: Y);
        for (var i = 3; i < 10; i++)
        {
            var next = A(x: in prev, y: in a);
            prev = a;
            a    = next;
        }

        Console.WriteLine(value: a);
    }

    private static string rev(string sx)
    {
        return new string(value: sx.Reverse().ToArray());
    }

    private static long f(string sx)
    {
        return long.Parse(s: rev(sx: sx));
    }

    private static long A(in long x, in long y)
    {
        return f(sx: (x + y).ToString());
    }
}
