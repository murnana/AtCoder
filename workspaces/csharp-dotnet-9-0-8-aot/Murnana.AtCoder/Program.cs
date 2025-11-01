using SourceExpander;

internal sealed class Program
{
    /// <summary>
    /// Practice A - Welcome to AtCoder
    /// 【問題概要】
    /// 整数 a, b, c と文字列 s が与えられる。
    /// a + b + c の結果と文字列 s をスペース区切りで出力する。
    /// 【入力形式】
    /// 1行目: 整数 a
    /// 2行目: 整数 b, c (スペース区切り)
    /// 3行目: 文字列 s
    /// 【制約】
    /// 1 ≤ a, b, c ≤ 1,000
    /// 1 ≤ |s| ≤ 100
    /// </summary>
    private static void Main()
    {
        Expander.Expand();

        // 1行目: 整数 a
        var a = int.Parse(s: Console.ReadLine()!);

        // 2行目: 整数 b, c (スペース区切り)
        var line2 = Console.ReadLine()!.Split(separator: ' ');
        var b     = int.Parse(s: line2[0]);
        var c     = int.Parse(s: line2[1]);

        // 3行目: 文字列 s
        var s = Console.ReadLine();

        // 出力: a + b + c と文字列 s をスペース区切り
        var sum = a + b + c;
        Console.WriteLine(value: $"{sum} {s}");
    }
}
