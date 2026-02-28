using SourceExpander;
using System.Diagnostics;
internal sealed class Program
{
    private static void Main()
    {
        Expander.Expand();

        long N, K;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            N = long.Parse(s: line[0]);
            K = long.Parse(s: line[1]);
        }

        var sum   = N;
        var next  = N + 1;
        var count = 0;
        for(count = 0 ; sum < K ; ++count)
        {
            sum  += next;
            next += 1;
        }

        Console.WriteLine(value: count);
    }
}
#region Expanded by https://github.com/kzrnm/SourceExpander
namespace SourceExpander{public class Expander{[Conditional("EXP")]public static void Expand(string inputFilePath=null,string outputFilePath=null,bool ignoreAnyError=true){}public static string ExpandString(string inputFilePath=null,bool ignoreAnyError=true){return "";}}}
#endregion Expanded by https://github.com/kzrnm/SourceExpander
