using SourceExpander;
using System.Diagnostics;
internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var firstLine = Console.ReadLine().Split(' ');
        var N = int.Parse(firstLine[0]);
        var A = int.Parse(firstLine[1]);
        var B = int.Parse(firstLine[2]);

        var S = Console.ReadLine();
        Console.WriteLine(string.Concat(S.Skip(A).SkipLast(B)));
    }
}
#region Expanded by https://github.com/kzrnm/SourceExpander
namespace SourceExpander{public class Expander{[Conditional("EXP")]public static void Expand(string inputFilePath=null,string outputFilePath=null,bool ignoreAnyError=true){}public static string ExpandString(string inputFilePath=null,bool ignoreAnyError=true){return "";}}}
#endregion Expanded by https://github.com/kzrnm/SourceExpander
