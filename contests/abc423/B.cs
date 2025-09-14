using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var N          = int.Parse(s: Console.ReadLine());
        var L          = new char[N];
        var firstIndex = 0;
        {
            var line     = Console.ReadLine();
            var endFirst = false;
            for (var i = 0; i < N; i++)
            {
                L[i] = line[index: i * 2];
                if (!endFirst && (L[i] == '0'))
                {
                    firstIndex = i + 1;
                }
                else
                {
                    endFirst = true;
                }
            }
        }

        var lastIndex = N - 1;
        {
            for (var i = N - 1; i >= 0; i--)
            {
                if (L[i] == '0')
                {
                    lastIndex = i - 1;
                }
                else
                {
                    break;
                }
            }
        }

        // どちらかが到達した、または合流した
        if ((firstIndex >= N) || (lastIndex <= 0) || (firstIndex == lastIndex))
        {
            Console.WriteLine(value: "0");
        }
        else
        {
            Console.WriteLine(value: lastIndex - firstIndex);
        }
    }
}
