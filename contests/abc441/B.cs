using System.Diagnostics;
using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        int           N, M;
        HashSet<char> S;
        HashSet<char> T;
        int           Q;
        {
            var split = Console.ReadLine()
                               .Split(separator: ' ');
            N = int.Parse(s: split[0]);
            M = int.Parse(s: split[1]);

            var line = Console.ReadLine();
            S = new(capacity: N);
            foreach(var c in line)
            {
                S.Add(item: c);
            }
            Debug.WriteLine(format: "S: {0}", string.Join(separator: ',', values: S));

            line = Console.ReadLine();
            T    = new(capacity: M);
            foreach(var c in line)
            {
                T.Add(item: c);
            }
            Debug.WriteLine(format: "T: {0}", string.Join(separator: ',', values: T));

            line = Console.ReadLine();
            Q    = int.Parse(s: line);
        }

        for(var i = 0 ; i < Q ; i++)
        {
            var word = Console.ReadLine();
            Debug.WriteLine(format: "word: {0}", word);

            var isTakahashi = true;
            var isAoki      = true;
            foreach(var c in word)
            {
                isTakahashi = isTakahashi && S.Contains(item: c);
                isAoki      = isAoki      && T.Contains(item: c);
            }

            Debug.WriteLine(
                format: "isTakahashi: {0}, isAoki: {1}",
                isTakahashi,
                isAoki
            );

            string result;
            if(isTakahashi && !isAoki)
            {
                result = "Takahashi";
            }
            else if(!isTakahashi && isAoki)
            {
                result = "Aoki";
            }
            else
            {
                result = "Unknown";
            }

            Debug.WriteLine(format: "Result: {0}", result);
            Console.WriteLine(value: result);
        }

    }
}
