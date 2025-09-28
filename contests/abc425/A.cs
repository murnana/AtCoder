using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var N = int.Parse(s: Console.ReadLine());

        var ans = 0.0;
        for(var i = 1 ; i <= N ; i++)
        {
            ans += Math.Pow(x: -1, y: i) * Math.Pow(x: i, y: 3);
        }

        Console.WriteLine(value: ans);
    }
}
