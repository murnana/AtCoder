using SourceExpander;
using System.Diagnostics;
internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var N = int.Parse(Console.ReadLine());
        var A = Console.ReadLine().Split(' ')
            .Select(int.Parse)
            .Select((a, i) => (a, i))
            .ToArray();

        var successCount = 0;
        for (var i = 0; i < N; i++)
        {
            ref readonly var a = ref A[i];

            for (var j = i + 1; j < N; j++)
            {
                ref readonly var a2 = ref A[j];

                var result1 = a2.i - a.i;
                var result2 = a.i - a2.i;
                var result3 = a2.a + a.a;
                if (result1 == result3) successCount++;
                if (result2 == result3) successCount++;
            }
        }

        Console.WriteLine(successCount);
    }
}
#region Expanded by https://github.com/kzrnm/SourceExpander
namespace SourceExpander{public class Expander{[Conditional("EXP")]public static void Expand(string inputFilePath=null,string outputFilePath=null,bool ignoreAnyError=true){}public static string ExpandString(string inputFilePath=null,bool ignoreAnyError=true){return "";}}}
#endregion Expanded by https://github.com/kzrnm/SourceExpander
