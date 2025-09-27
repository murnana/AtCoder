using SourceExpander;

/// <summary>
/// ABC425-C: Rotate and Sum Query
/// 🤖 本プログラムはClaude Code (claude.ai/code) の支援により作成されました
/// 📚 <see href="https://atcoder.jp/contests/abc425/editorial/14077">AtCoder公式解説</see> に基づく実装
/// ✅ <see href="https://atcoder.jp/contests/abc425/submissions/69689748">AtCoder提出済み</see>
/// 【問題概要】
/// 長さNの配列Aに対して、Q個のクエリを処理する。
/// クエリ1: 配列の先頭c要素を末尾に移動（c回の左回転）
/// クエリ2: 現在の配列のl番目からr番目の要素の合計を出力
/// 【公式解法のポイント】
/// 1. 配列を2倍の長さにコピー: B = (A1, A2, ..., AN, A1, A2, ..., AN)
/// 2. 後ろから累積和を計算: B[i] = B[i] + B[i+1] + ... + B[2N-1]
/// 3. 回転量をオフセットとして管理
/// 4. 区間和クエリは B[l+offset] - B[r+1+offset] で計算
/// 【計算量】
/// 時間: O(N + Q)、空間: O(N)
/// 【公式解法の利点】
/// - 配列を2倍にすることで境界を跨ぐ処理が不要
/// - 後ろからの累積和により区間和計算が簡潔
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Expander.Expand();

        // 入力: 配列の長さN、クエリ数Q
        int N;
        int Q;
        {
            var line = Console.ReadLine().Split(separator: ' ');
            N = int.Parse(s: line[0]);
            Q = int.Parse(s: line[1]);
        }

        // 入力: 配列A
        var A = new long[N];
        {
            var line = Console.ReadLine().Split(separator: ' ');
            for(var i = 0 ; i < N ; i++)
            {
                A[i] = long.Parse(s: line[i]);
            }
        }

        // 公式解法：配列を2倍の長さにコピー
        // B = (A1, A2, ..., AN, A1, A2, ..., AN)
        // これにより回転による境界の問題を解決
        var B = new long[2 * N];
        for(var i = 0 ; i < N ; i++)
        {
            B[i]     = A[i]; // 最初のN要素
            B[i + N] = A[i]; // 後のN要素（コピー）
        }

        // 後ろから累積和を計算
        // B[i] = B[i] + B[i+1] + ... + B[2N-1]
        // これにより区間[i, j]の和は B[i] - B[j+1] で計算可能
        for(var i = (2 * N) - 2 ; i >= 0 ; i--)
        {
            B[i] += B[i + 1];
        }

        // 回転量の累積値
        var rotationOffset = 0;

        // Q個のクエリを処理
        for(var i = 0 ; i < Q ; i++)
        {
            var line = Console.ReadLine().Split(separator: ' ');
            if(line[0] == "1")
            {
                // クエリ1: 回転操作
                // c回の左回転を累積
                var c = int.Parse(s: line[1]);
                rotationOffset = (rotationOffset + c) % N;
            }
            else
            {
                // クエリ2: 範囲和計算
                // 1-indexedを0-indexedに変換
                var l = int.Parse(s: line[1]) - 1;
                var r = int.Parse(s: line[2]) - 1;

                // 回転を考慮した実際のインデックス
                var actualL = l + rotationOffset;
                var actualR = r + rotationOffset;

                // 後ろからの累積和を利用した区間和計算
                // 区間[actualL, actualR]の和 = B[actualL] - B[actualR + 1]
                var ans = B[actualL] - B[actualR + 1];

                Console.WriteLine(value: ans);
            }
        }
    }
}
