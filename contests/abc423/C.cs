using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        int N;
        int R;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            N = int.Parse(s: line[0]);
            R = int.Parse(s: line[1]);
        }

        var L          = new char[N];
        var spanL      = L.AsSpan();
        var firstIndex = 0; // 左橋を探しておきます
        {
            var line     = Console.ReadLine();
            var endFirst = false;
            for (var i = 0; i < N; i++)
            {
                spanL[index: i] = line[index: i * 2];
                if (!endFirst && (spanL[index: i] == '1'))
                {
                    firstIndex = i + 1;
                }
                else
                {
                    endFirst = true;
                }
            }
        }

        // 右側を閉める回数
        var right = 0;
        {
            var stopIndex = R; // 閉まっているため、一時的に止めてある場所
            for (var i = R; i < N; i++)
            {
                if (spanL[index: i] == '1') // 既に閉まっている
                {
                    // いったん見なかったことに
                    continue;
                }

                // 止めてあるので、開けながら来てもらう必要がある
                if (stopIndex != i)
                {
                    right += (i - stopIndex) * 2; // 最終的に閉めるため、2回操作する
                }

                right     += 1; // ドアiを閉めるための回数
                stopIndex =  i + 1;
            }
        }

        var left = 0;
        {
            var stopIndex = R - 1;
            for (var i = stopIndex; i >= firstIndex; i--)
            {
                if (spanL[index: i] == '1') // 既に閉まっている
                {
                    // いったん見なかったことに
                    continue;
                }

                // 止めてあるので、開けながら来てもらう必要がある
                if (stopIndex != i)
                {
                    left += (stopIndex - i) * 2; // 最終的に閉めるため、2回操作する
                }

                left      += 1; // ドアiを閉めるための回数
                stopIndex =  i - 1;
            }
        }

        Console.WriteLine(value: left + right);
    }
}
