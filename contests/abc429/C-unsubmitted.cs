using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        var N            = int.Parse(s: Console.ReadLine());
        var A            = new int[N];
        var selectDouble = new Dictionary<int, List<int>>(capacity: N / 2);
        {
            var line = Console.ReadLine().Split(separator: ' ');
            for(var i = 0 ; i < N ; i++)
            {
                var a = int.Parse(s: line[i]);
                A[i] = a;
                if(!selectDouble.TryGetValue(key: a, value: out var list))
                {
                    list = new(capacity: N / 2);
                    selectDouble.Add(key: a, value: list);
                }

                list.Add(item: i);
            }
        }

        // 数字のペアから組み合わせを数えます
        var count = 0;
        foreach((var a, var indexes) in selectDouble)
        {
            if(indexes.Count < 2)
            {
                continue;
            }

            var firstIndex = indexes[0];
            for(var i = 1 ; i < indexes.Count ; i++)
            {
            }
        }
    }

}
