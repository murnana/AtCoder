using System.Runtime.InteropServices;
using SourceExpander;

internal sealed class Program
{
    /// <summary>
    /// https://atcoder.jp/contests/abc434/tasks/abc434_c
    /// 途中
    /// </summary>
    private static void Main()
    {
        Expander.Expand();

        int T = int.Parse(Console.ReadLine());
        for(int i = 0 ; i < T ; i++)
        {
            int N,H;
            {
                var line = Console.ReadLine().Split(' ');
                N = int.Parse(line[0]);
                H = int.Parse(line[1]);
            }

            int currentHeight = H;
            for(int n = 0 ; n < N ; n++)
            {
                int t, l, u;
                {
                    var line = Console.ReadLine().Split(' ');
                    t = int.Parse(line[0]);
                    l = int.Parse(line[1]);
                    u = int.Parse(line[2]);
                }
            }
        }

    }

}
