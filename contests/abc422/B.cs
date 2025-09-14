using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        int H, W;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            H = int.Parse(s: line[0]);
            W = int.Parse(s: line[1]);
        }

        var blackCountMap = new byte[H, W];
        for (var i = 0; i < H; i++)
        {
            var S = Console.ReadLine();
            for (var j = 0; j < W; j++)
            {
                var p = S[index: j];

                if (p == '#')
                {
                    blackCountMap[i, j] = 1;
                }
                else
                {
                    blackCountMap[i, j] = 0;
                    continue;
                }

                // 上を見る
                if (i >= 1)
                {
                    // 上も黒いのか
                    ref var up = ref blackCountMap[i - 1, j];
                    if (up >= 1)
                    {
                        blackCountMap[i, j]     += 1;
                        blackCountMap[i - 1, j] += 1;
                    }
                }

                // 左を見る
                if (j >= 1)
                {
                    // 左も黒いのか
                    ref var left = ref blackCountMap[i, j - 1];
                    if (left >= 1)
                    {
                        blackCountMap[i, j]     += 1;
                        blackCountMap[i, j - 1] += 1;
                    }
                }
            }
        }

        Console.WriteLine();

        // マップ全体を見る
        var isClear = true;
        for (var i = 0; i < H; i++)
        {
            for (var j = 0; j < W; j++)
            {
                ref readonly var p = ref blackCountMap[i, j];
                // Console.Write(value: p);

                if (p == 0)
                {
                    continue;
                }

                if (p == 3)
                {
                    continue;
                }

                if (p == 5)
                {
                    continue;
                }

                isClear = false;
                break;
            }

            // Console.WriteLine();

            if (!isClear)
            {
                break;
            }
        }

        Console.WriteLine(value: isClear ? "Yes" : "No");
    }
}
