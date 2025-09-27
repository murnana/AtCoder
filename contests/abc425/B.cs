using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var N    = int.Parse(s: Console.ReadLine());
        var P    = new int[N];
        var A    = new int[N];
        var rest = Enumerable.Range(start: 1, count: N).ToList();
        var line = Console.ReadLine().Split(separator: ' ');
        for(var i = 0 ; i < N ; i++)
        {
            var a = A[i] = int.Parse(s: line[i]);

            // -1はいったん無視する
            if(a == -1)
            {
                P[i] = a;
                continue;
            }

            // 既に同じ数がいたら成立しない
            if(P.Contains(value: a))
            {
                Console.WriteLine(value: "No");
                return;
            }

            // Pに入れていく
            P[i] = a;

            // リストから抜く
            rest.Remove(item: a);
        }

        // 残りを入れていく
        for(var i = 0 ; i < N ; i++)
        {
            if(P[i] != -1)
            {
                continue;
            }

            P[i] = rest[index: 0];
            rest.RemoveAt(index: 0);
        }

        Console.WriteLine(value: "Yes");
        Console.WriteLine(value: string.Join(separator: ' ', values: P));
    }
}
