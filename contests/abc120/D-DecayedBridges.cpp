/**
 * @file D-DecayedBridges.cpp
 * @author murnana
 * @brief D - Decayed Bridges
 *        https://atcoder.jp/contests/abc120/tasks/abc120_d
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <iostream>
#include <string>
using namespace std;

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    // 島の数Nと橋の数Mを取得
    unsigned int N, M;
    cin >> N >> M;

    // 行き来できる橋について取得するが、
    // そのまえに「不便さ」について考える

    // 「いくつかの橋を渡って互いに行き来できなくなった」
    // というのは、以下２つの条件が必要になる
    // 1. 元来、行き来することが可能だった
    // 2. どの島を経由しても行き来できなくなった
    //    = 完全に孤立した

    // 孤立するのは、そのルートがクリティカルパスになったとき
    // クリティカルパスは、その島に行くルートが1通りしかなかった場合に
    // 発生する
    for (unsigned int i = 0; i < M; ++i)
    {
        unsigned int A, B;
        cin >> A >> B;
    }

    // cout << ??? << endl;

    return 0;
}
