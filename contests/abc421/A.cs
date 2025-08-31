using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var N = int.Parse(s: Console.ReadLine());

        var S = new string[N];
        for (var i = 0; i < N; i++)
        {
            S[i] = Console.ReadLine();
        }

        int    X;
        string Y;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            X = int.Parse(s: line[0]);
            Y = line[1];
        }

        if ((X < 1) || (N < X))
        {
            Console.WriteLine(value: "No");
        }
        else
        {
            Console.WriteLine(value: S[X-1] == Y ? "Yes" : "No");
        }
    }
}
