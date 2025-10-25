using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        int    N, K;
        string S;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            N = int.Parse(s: line[0]);
            K = int.Parse(s: line[1]);
            S = Console.ReadLine();
        }

        var memory = new Dictionary<string, int>();
        for(var i = 0 ; i <= (S.Length - K) ; i++)
        {
            var sample = S[i..(i + K)];
            if(!memory.TryAdd(key: sample, value: 1))
            {
                memory[key: sample] += 1;
            }
        }

        var sortOrder = memory.OrderByDescending(keySelector: pair => pair.Value)
                              .ToArray();
        var max = sortOrder[0].Value;
        Console.WriteLine(value: max);

        var result = sortOrder.Where(predicate: pair => pair.Value == max)
                              .OrderBy(keySelector: pair => pair.Key)
                              .Select(selector: p => p.Key);
        Console.WriteLine(value: string.Join(separator: ' ', values: result));
    }
}
