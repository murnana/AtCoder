using SourceExpander;

internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        // 整数の入力
        var a = int.Parse(s: Console.ReadLine());
        // スペース区切りの整数の入力
        var input = Console.ReadLine().Split(separator: ' ');
        var b     = int.Parse(s: input[0]);
        var c     = int.Parse(s: input[1]);
        // 文字列の入力
        var s = Console.ReadLine();
        //出力
        Console.WriteLine(value: a + b + c + " " + s);
    }
}
