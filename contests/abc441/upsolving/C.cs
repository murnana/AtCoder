using System.Collections.Immutable;
using System.Diagnostics;
using SourceExpander;

internal sealed class Program
{
    /// <summary>
    /// AtCoder Beginner Contest 441 - C: Sake or Water
    /// </summary>
    /// <remarks>
    /// <i>N</i>個のカップのうち<i>K</i>個に日本酒、残りに水が入っている。
    /// どのカップに日本酒があるか不明な状況で、確実に<i>X</i>ml以上の
    /// 日本酒を飲むために必要な最小カップ数を求める。
    /// <para>
    /// 提出結果: <a href="https://atcoder.jp/contests/abc441/submissions/72576193" />
    /// </para>
    /// </remarks>
    /// <seealso href="https://atcoder.jp/contests/abc441/tasks/abc441_c"/>
    /// <seealso href="https://atcoder.jp/contests/abc441/editorial/15089"/>
    /// <seealso href="https://atcoder.jp/contests/abc441/editorial/15112"/>
    private static void Main()
    {
        Expander.Expand();

        // === 入力の読み込み ===
        var line1 = Console.ReadLine()!.Split(separator: ' ');
        var N     = int.Parse(s: line1[0]);  // カップの総数
        var K     = int.Parse(s: line1[1]);  // 日本酒が入っているカップ数
        var X     = long.Parse(s: line1[2]); // 目標の日本酒量 (最大3×10^14なのでlong)

        var        line2 = Console.ReadLine()!.Split(separator: ' ');
        var A     = new long[N];
        for(var i = 0 ; i < N ; i++)
        {
            A[i] = long.Parse(s: line2[i]);
        }

        // === ソート（降順: 大きい順）===
        // 最大のカップから選ぶのが最適戦略
        Array.Sort(array: A, comparison: (a, b) => b.CompareTo(value: a));

        Debug.WriteLine(message: "=== 入力処理完了 ===");
        Debug.WriteLine(format: "ソート後の配列 A = [{0}]", string.Join(separator: ", ", values: A));

        // === 累積和の計算 ===
        // prefix[i] = A[0] + A[1] + ... + A[i-1]（最初のi個の合計）
        // 競プロでは N ≤ 3×10^5 の場合、スタックオーバーフローに注意が必要ですが、
        // long × 3×10^5 ≈ 2.4MB なのでギリギリ安全圏です
        Span<long> prefix = stackalloc long[N + 1];
        for(var i = 0 ; i < N ; i++)
        {
            prefix[i + 1] = prefix[i] + A[i];
        }

        // === 最小カップ数を求める ===
        // M個選んだとき、確実に日本酒が含まれるカップ数 g = max(0, K + M - N)
        // 保証される日本酒量 = 選んだM個の中で最小のg個の合計
        var result = FindMinimumCups(N: in N, K: in K, X: in X, prefix: prefix);

        Console.WriteLine(value: result);
    }

    /// <summary>
    /// 確実にX ml以上の日本酒を飲むために必要な最小カップ数を求める
    /// </summary>
    /// <param name="N">カップの総数</param>
    /// <param name="K">日本酒が入っているカップ数</param>
    /// <param name="X">目標の日本酒量</param>
    /// <param name="prefix">降順ソート済み配列の累積和 (prefix[i] = 最大i個の合計)</param>
    /// <returns>最小カップ数、不可能なら-1</returns>
    private static long FindMinimumCups(
        in int                N,
        in int                K,
        in long               X,
        in ReadOnlySpan<long> prefix
    )
    {
        Debug.WriteLine(message: "=== FindMinimumCups 開始 ===");
        Debug.WriteLine(format: "カップの総数 N={0}, 日本酒が入っているカップ数 K={1}, 目標の日本酒量 X={2}", N, K, X);
        Debug.WriteLine(format: "降順ソート済み配列の累積和(prefix[i] = 最大i個の合計) = [{0}]", string.Join(separator: ", ", values: prefix.ToImmutableArray()));
        Debug.WriteLine(message: "");

        // カップの数を最小にしたい場合、容量が大きいカップから選択すればよいです。
        // そこで容量の大きな順から、
        // M個のカップを選択する場合を考えます（M = 1, 2, ..., N）
        for(var M = 1 ; M <= N ; M++)
        {
            // 【ステップ1: M個の内、確実に日本酒が含まれるカップ数 g を計算します】
            // 高橋君にとって最悪なのは、選択した日本酒のカップが少なかった場合です。
            // これはどういう状況かというと、選ばれなかったカップのほうに日本酒のカップが多くある場合です。
            // そこで選ばれなかったカップ (N - M) のうち、日本酒は最大でいくつになるかを考えます。
            //
            // 選ばれなかったカップ(N - M)が日本酒の数K以上の場合、
            // 日本酒はすべて選ばれなかったカップには入っている可能性があります。
            // つまり選択したカップM個のうち、確実に日本酒があるカップは0個です。
            //
            // 選ばれなかったカップ(N - M)が日本酒の数Kより小さい場合、
            // 選ばれなかったカップ全てに日本酒があったとしても、選択したカップM個に日本酒のカップが確実に入ります。
            // この数は、K - (N - M) と表せます。
            //
            // よって、計算では max(0, K - (N - M))となります。
            // 実装では、計算量を減らすためマイナスを許容しています。
            var g =  K - (N - M);

            Debug.WriteLine(format: "選択するカップの数 M={0}:", M);
            Debug.WriteLine(format: "  残りのカップ数 = N - M = {0}", N - M);
            Debug.WriteLine(format: "  確実に選択内にある日本酒カップ数 g = K - (N - M) = {0} - ({1} - {2}) = {3}", K, N, M, g);

            // gが0以下 の場合、保証される日本酒は 0 ml です
            if(g <= 0)
            {
                Debug.WriteLine(format: "  → g<=0 のため、相手は全ての日本酒を選択外に隠せます。保証される日本酒量 = 0 < X={0} ✗", X);
                Debug.WriteLine(message: "");
                continue;
            }

            // 【ステップ2: 保証される日本酒量を計算します】
            // 最悪のケースは、一番容量の小さいカップに日本酒が入っている場合です。
            // そのため、M個のうち一番小さい容量をg個選択します。
            // 降順ソート済みなので、最小g個はインデックス (M-g) 〜 (M-1) の範囲です。
            // この範囲の合計 = prefix[M] - prefix[M - g] で計算できます。
            var guaranteed = prefix[M] - prefix[M - g];

            Debug.WriteLine(format: "  選択内の最小{0}個（インデックス {1}〜{2}）の合計", g, M - g, M - 1);
            Debug.WriteLine(format: "  = prefix[{0}] - prefix[{1}] = {2} - {3} = {4}", M, M - g, prefix[M], prefix[M - g], guaranteed);

            // 【ステップ3: 条件を満たすか確認します】
            if(guaranteed >= X)
            {
                Debug.WriteLine(format: "  → {0} >= X={1} ✓ 条件を達成しました！", guaranteed, X);
                Debug.WriteLine(format: "=== 答え: M={0} ===", M);
                return M;
            }

            Debug.WriteLine(format: "  → {0} < X={1} ✗ まだ条件を満たしていません", guaranteed, X);
            Debug.WriteLine(message: "");
        }

        // 全てのカップを選んでも条件を満たせませんでした
        Debug.WriteLine(message: "=== 全カップ選択でも条件未達成。答え: -1 ===");
        return -1;
    }
}
