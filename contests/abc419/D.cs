using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        int N;
        int M;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            N = int.Parse(s: line[0]);
            M = int.Parse(s: line[1]);
        }
        var S      = Console.ReadLine().ToCharArray();
        var T      = Console.ReadLine().ToCharArray();
        var isSwap = new bool[N];
        for (var i = 0; i < M; i++)
        {
            int L;
            int R;
            {
                var line = Console.ReadLine().Split(separator: ' ');
                L = int.Parse(s: line[0]);
                R = int.Parse(s: line[1]);
            }

            for (var j = L - 1; j < R; j++)
            {
                isSwap[j] = !isSwap[j];
            }
        }

        for (var i = 0; i < N; i++)
        {
            if (isSwap[i])
            {
                S[i] = T[i];
            }
        }

        Console.WriteLine(value: new string(value: S));
    }
}
