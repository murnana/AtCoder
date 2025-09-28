using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        int N;
        int Q;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            N = int.Parse(s: line[0]);
            Q = int.Parse(s: line[1]);
        }

        var A = new List<long>(capacity: N);
        {
            var line = Console.ReadLine().Split(separator: ' ');
            for(var i = 0 ; i < N ; i++)
            {
                A.Add(item: long.Parse(s: line[i]));
            }
        }

        for(var i = 0 ; i < Q ; i++)
        {
            var line = Console.ReadLine().Split(separator: ' ');
            if(line[0] == "1")
            {
                // A の先頭の要素を末尾に移動させる操作をc回行う
                var c    = int.Parse(s: line[1]);
                var temp = A.Take(count: c).ToArray();
                A.RemoveRange(index: 0, count: c);
                A.AddRange(collection: temp);
            }
            else
            {
                var l = int.Parse(s: line[1]);
                var r = int.Parse(s: line[2]);

                // 答えを出力します
                var ans = A.Take(range: new(start: l - 1, end: r)).Sum();
                Console.WriteLine(value: ans);
            }
        }
    }
}
