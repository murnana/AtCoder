using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var T = int.Parse(s: Console.ReadLine());
        for (var i = 0; i < T; i++)
        {
            long numA, numB, numC;
            {
                var line = Console.ReadLine().Split(separator: ' ');
                numA = long.Parse(s: line[0]);
                numB = long.Parse(s: line[1]);
                numC = long.Parse(s: line[2]);
            }

            var mustCount = Math.Min(val1: Math.Min(val1: numA, val2: numB), val2: numC);
            numA -= mustCount;
            numB -= mustCount;
            numC -= mustCount;

            // この時点で、AまたはCの文字がなければそれまで
            if ((numA <= 0) || (numC <= 0) || ((numA == 1) && (numC == 1)))
            {
                Console.WriteLine(value: mustCount);
                continue;
            }

            // 2買い使って大きいほうにする
            var halfA = numA / 2;
            var modA  = numA % 2;
            var halfC = numC / 2;
            var modC  = numC % 2;

            if (halfA <= halfC)
            {
                if ((modC > 0) && ((numA - halfC) >= 2))
                {
                    Console.WriteLine(value: mustCount + halfC + modC);
                }
                else
                {
                    Console.WriteLine(value: mustCount + halfC);
                }
            }
            else
            {
                if ((modA > 0) && ((numC - halfA) >= 2))
                {
                    Console.WriteLine(value: mustCount + halfA + modA);
                }
                else
                {
                    Console.WriteLine(value: mustCount + halfA);
                }
            }
        }
    }
}
