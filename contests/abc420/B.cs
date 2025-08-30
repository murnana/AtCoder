using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var firstLine = Console.ReadLine().Split(separator: ' ');
        var N         = int.Parse(s: firstLine[0]);
        var M         = int.Parse(s: firstLine[1]);

        var answers = new int[N, M];
        var yCounts = new int[M];
        for (var n = 0; n < N; n++)
        {
            var line = Console.ReadLine();
            for (var m = 0; m < M; m++)
            {
                var answer = line[index: m] == '1' ? 1 : 0;
                answers[n, m] =  answer;
                yCounts[m]    += answer;
            }
        }

        var points = new int[N];
        var yWin   = N / 2;
        for (var m = 0; m < M; m++)
        {
            // x=0 または y=0 である場合、
            // その投票では全員に 1 点が与えられる。
            if ((yCounts[m] == 0) || (yCounts[m] == N))
            {
                // 全員に同じ点がはいるので、省略
                // for (var n = 0; n < N; n++)
                // {
                //     points[n] += 1;
                // }
            }

            // そうでなく x<y である場合、
            // その投票で 0 に投票した人のみに 1 点が与えられる。
            else if (yWin < yCounts[m])
            {
                for (var n = 0; n < N; n++)
                {
                    points[n] += answers[n, m] == 0 ? 1 : 0;
                }
            }

            // そうでない場合、
            // その投票で 1 に投票した人のみに 1 点が与えられる。
            else
            {
                for (var n = 0; n < N; n++)
                {
                    points[n] += answers[n, m];
                }
            }
        }

        // 最高得点を探します
        var maxPoint = points.Max();

        Console.WriteLine(
            value: string.Join(
                separator: ' ',
                values: points
                        .Select(selector: (point, index) => point >= maxPoint ? index + 1 : 0)
                        .Where(predicate: result => result != 0)));
    }
}
