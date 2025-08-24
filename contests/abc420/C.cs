using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        int N;
        int Q;
        {
            var firstLine = Console.ReadLine().Split(separator: ' ');
            N = int.Parse(s: firstLine[0]);
            Q = int.Parse(s: firstLine[1]);
        }

        var A = new long[N];
        {
            var line = Console.ReadLine()
                              .Split(separator: ' ');
            for (var n = 0; n < N; n++)
            {
                A[n] = long.Parse(s: line[n]);
            }
        }
        var B = new long[N];
        {
            var line = Console.ReadLine()
                              .Split(separator: ' ');
            for (var n = 0; n < N; n++)
            {
                B[n] = long.Parse(s: line[n]);
            }
        }

        var mimMemory = new long[N];
        for (var n = 0; n < N; n++)
        {
            mimMemory[n] = Math.Min(val1: A[n], val2: B[n]);
        }

        for (var q = 0; q < Q; q++)
        {
            string c;
            long   V;
            int    X;
            {
                var line = Console.ReadLine().Split(separator: ' ');
                c = line[0];
                X = int.Parse(s: line[1]);
                V = long.Parse(s: line[2]);
            }

            var x = X - 1;
            if (c == "A")
            {
                A[x] = V;
            }
            else
            {
                B[x] = V;
            }

            mimMemory[x] = Math.Min(val1: A[x], val2: B[x]);

            // Console.WriteLine(format: "-> {0}", arg0: mimMemory.Sum());
            Console.WriteLine(value: mimMemory.Sum());
        }
    }
}
