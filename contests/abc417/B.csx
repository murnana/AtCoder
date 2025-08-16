using SourceExpander;
using System.Diagnostics;
using System.Globalization;
internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        var firstLine = Console.ReadLine().Split(' ');
        var N = int.Parse(firstLine[0]);
        var M = int.Parse(firstLine[1]);

        var A = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
        var B = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

        foreach (var b in B) A.Remove(b);

        Console.WriteLine(string.Join(' ', A.Select(a => a.ToString(CultureInfo.InvariantCulture))));
    }
}
#region Expanded by https://github.com/kzrnm/SourceExpander
namespace SourceExpander{public class Expander{[Conditional("EXP")]public static void Expand(string inputFilePath=null,string outputFilePath=null,bool ignoreAnyError=true){}public static string ExpandString(string inputFilePath=null,bool ignoreAnyError=true){return "";}}}
#endregion Expanded by https://github.com/kzrnm/SourceExpander
