using System.Diagnostics;
using SourceExpander;

internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        var N = byte.Parse(s: Console.ReadLine());
        Debug.WriteLine(format: "N = {0}", N);
        var A = new int[N];
        {
            var line = Console.ReadLine().Split(separator: ' ');
            for(var i = 0 ; i < N ; i++)
            {
                A[i] = int.Parse(s: line[i]);
            }

            Debug.WriteLine(message: string.Join(separator: ' ', values: A));
        }
        Debug.WriteLine(message: "-----");

        // 累積和 Xを作る
        var X    = new int[N];
        var prev = 0;
        for(var i = 0 ; i < N ; i++)
        {
            var next = prev + A[i];
            X[i] = next;
            prev = next;
        }

        var result = 0;
        for(var l = 0 ; l < (N - 1) ; l++)
        {
            for(var r = l + 1 ; r < N ; r++)
            {
                var sum = X[r] - (l <= 0 ? 0 : X[l - 1]);

                var isNotDivisor = true;
                for(var i = l ; i <= r ; i++)
                {
                    if((sum % A[i]) <= 0)
                    {
                        Debug.WriteLine(
                            format: "Case ({0},{1}) == ({2} ~ {3}) -> {4} (約数: {5})",
                            l,
                            r,
                            A[l],
                            A[r],
                            sum,
                            A[l]
                        );

                        isNotDivisor = false;
                        break;
                    }
                }

                if(!isNotDivisor)
                {
                    continue;
                }

                Debug.WriteLine(
                    format: "Case ({0},{1}) == ({2} ~ {3}) -> {4}",
                    l,
                    r,
                    A[l],
                    A[r],
                    sum
                );
                result++;
            }
        }

        Console.WriteLine(value: result);
    }
}
