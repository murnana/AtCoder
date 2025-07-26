/**
 * @file C-Unification.cpp
 * @author murnana
 * @brief C - Unification
 *        https://atcoder.jp/contests/abc120/tasks/abc120_c
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <iostream>
#include <string>
#include <math.h>
using namespace std;

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    // 長さN与えられない説…
    string S;
    cin >> S;

    // ぷよぷよみたく、隣り合っている色を消すが
    // 消すための最大数は決まっていて、どんなにきれいに消せたとしても
    // N / 2 以上にはならない

    // 0と1が並んでいるときなら消せる、つまり
    // 0と1の数がどちらが一番小さいかによっても決まる

    // なので、0の数と1の数を調べる
    size_t red = 0;
    size_t blue = 0;
    auto length = S.length();
    for (size_t i = 0; i < length; ++i)
    {
        if (S[i] == '0')
        {
            ++red;
        }
        else
        {
            ++blue;
        }
    }

    // 小さい方を答えにする
    cout << (min(red, blue) * 2) << endl;

    return 0;
}
