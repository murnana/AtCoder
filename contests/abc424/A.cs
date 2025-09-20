using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();


        byte a, b, c;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            a = byte.Parse(s: line[0]);
            b = byte.Parse(s: line[1]);
            c = byte.Parse(s: line[2]);
        }

        var ab = a == b;
        var bc = b == c;
        var ca = c == a;

        if (ab || bc || ca)
        {
            Console.WriteLine(value: "Yes");
        }
        else
        {
            Console.WriteLine(value: "No");
        }
    }
}
