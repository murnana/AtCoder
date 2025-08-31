using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var    N = int.Parse(s: Console.ReadLine());
        Pair[] pairs;
        {
            var S = Console.ReadLine();

            pairs = new Pair[N];
            for (var i = 0; i < N; i++)
            {
                pairs[i] = new Pair(a: S[index: i * 2], b: S[index: (i * 2) + 1]);
            }
        }

        // 最初にペアをつくる
        var changeCount = 0;
        for (var i = 0; i < N; i++)
        {
            ref var a = ref pairs[i];
            if (a.IsPair())
            {
                continue;
            }

            // 変更相手を見つけます
            for (var j = i + 1; j < N; j++)
            {
                ref var b = ref pairs[j];
                if (b.IsPair())
                {
                    continue;
                }

                if (a.B == b.A)
                {
                    continue;
                }

                // 交換
                changeCount += (j * 2) - ((i * 2) + 1);
                (a.B, b.A)  =  (b.A, a.B);
                break;
            }
        }

        // ペアのパターンが AB が多いか、 BA が多いか数える
        var abCount = 0;
        for (var i = 0; i < N; i++)
        {
            ref readonly var pair = ref pairs[i];
            if (pair.A == 'A')
            {
                abCount += 1;
            }
        }

        if (abCount > N)
        {
            changeCount += abCount - N;
        }
        else if (N > abCount)
        {
            changeCount += N - abCount;
        }

        Console.WriteLine(value: changeCount);
    }

    private struct Pair
    {
        public char A;
        public char B;

        public Pair(char a, char b)
        {
            A = a;
            B = b;
        }

        public readonly bool IsPair()
        {
            return A != B;
        }
    }
}
