using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        byte N, M, K;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            N = byte.Parse(s: line[0]);
            M = byte.Parse(s: line[1]);
            K = byte.Parse(s: line[2]);
        }

        var anwers    = new byte[N];
        var completed = new List<byte>(capacity: N);
        for (var i = 0; i < K; i++)
        {
            byte A, B;
            {
                var line = Console.ReadLine().Split(separator: ' ');
                A = byte.Parse(s: line[0]);
                B = byte.Parse(s: line[1]);
            }
            anwers[A - 1] += 1;
            if (anwers[A - 1] >= M)
            {
                completed.Add(item: A);
            }
        }

        Console.WriteLine(value: string.Join(separator: ' ', values: completed));
    }
}
