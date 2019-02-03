/**
 * @file B-Polygon.cpp
 * @author murnana
 * @brief B - Polygon
 *     https://atcoder.jp/contests/abc117/tasks/abc117_b
 *     提出: https://atcoder.jp/contests/abc117/submissions/4160698
 * @date 2019-02-03
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <iostream>
using namespace std;

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    // N角形を取得
    int N;
    cin >> N;

    // Lを取得しつつ
    // 定理より、一番長い辺と
    // その他短い辺の合計の値を作る
    unsigned int maxL = 0;
    unsigned int minSum = 0;
    for (int i = 0; i < N; ++i)
    {
        unsigned int L;
        cin >> L;
        if (maxL < L)
        {
            minSum += maxL;
            maxL = L;
        }
        else
        {
            minSum += L;
        }

        // cerr << "loop: " << i << endl;
        // cerr << "\tL: " << L << endl;
        // cerr << "\tmaxL: " << maxL << endl;
        // cerr << "\tminSum: " << minSum << endl;
    }

    // 答え
    cout << (maxL < minSum ? "Yes" : "No") << endl;

    return 0;
}
