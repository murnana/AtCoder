using System.Diagnostics;
using SourceExpander;

internal sealed class Program
{
    /// <summary>
    /// https://atcoder.jp/contests/abc435/tasks/abc435_c
    /// </summary>
    private static void Main()
    {
        Expander.Expand();

        var N = int.Parse(s: Console.ReadLine());
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
        Debug.WriteLine(message: "----------");

        {
            var i      = 0;
            var result = 1;
            do
            {
                var downCount = A[i] - i;

                if(downCount <= 1)
                {
                    break;
                }

                // 次の数
                i      += downCount - 1;
                result =  Math.Min(val1: result + downCount, val2: N);

                Debug.WriteLine(
                    format: "Next: {0} (downCount: {1})",
                    i,
                    downCount
                );
            } while(i < N);

            Console.WriteLine(value: result);
        }
    }
}
