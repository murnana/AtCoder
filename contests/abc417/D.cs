using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var N = int.Parse(Console.ReadLine());
        var P = new Present[N];
        for (var i = 0; i < N; i++)
        {
            var line = Console.ReadLine().Split(' ');
            P[i] = new Present(
                int.Parse(line[0]),
                int.Parse(line[1]),
                int.Parse(line[2])
            );
        }

        var Q = int.Parse(Console.ReadLine());
        for (var i = 0; i < Q; i++)
        {
            var X = int.Parse(Console.ReadLine());
            for (var j = 0; j < N; j++)
                if (P[j].P >= X)
                    X += P[j].A;
                else
                    X = Math.Max(X - P[j].B, 0);

            Console.WriteLine(X);
        }
    }

    private readonly struct Present
    {
        /// <summary>
        ///     価値
        /// </summary>
        public readonly int P;

        /// <summary>
        ///     テンション上げ度
        /// </summary>
        public readonly int A;

        /// <summary>
        ///     テンション下げ度
        /// </summary>
        public readonly int B;

        public Present(int p, int a, int b)
        {
            P = p;
            A = a;
            B = b;
        }
    }
}
