/**
 * @file C-Streamline.cpp
 * @author murnana
 * @brief C - Streamline
 *     https://atcoder.jp/contests/abc117/tasks/abc117_c
 * @date 2019-02-03
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <iostream>
#include <map>
using namespace std;

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    // コマの数Nと
    // 座標の数Mを取得
    unsigned int N, M;
    cin >> N >> M;

    // 座標Xを取得
    map<int, int> X;

    // 最初の値を基準にしてmapを作る
    int x;
    cin >> x;
    X[0] = x;
    for (unsigned int i = 1; i < M; ++i)
    {
        int x;
        cin >> x;
        // 距離によってデータの塊を作れば
        // 最短が作れるはず…
        // そのため、mapのキー値をX[0]からの距離にする
        auto cost = X[0] - x;
        X[cost] = cost;
    }
    // std::mapは勝手にソートしてれる
    // 端から端を計算すれば、
    // 1コマで移動した際のコストが分かる
    auto start = X.begin();
    auto last = X.end();
    --last;
    cerr << "start = " << start->second << endl;
    cerr << "last = " << last->second << endl;
    auto cost = last->second - start->second;
    cerr << "M/1 cost = " << cost << endl;

    // コマを配置し、何ターンでクリアできるか考える
    for (unsigned int i = 0; i < N; ++i)
    {
        // 一番コストの高いところから配置していく？
        // 10, 12, 1, 2, 14
        // 0, 2, 9, 8, -4
    }

    // 答え
    cout << "Unknown" << endl;

    return 0;
}
