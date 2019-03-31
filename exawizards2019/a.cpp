/**
 * @file a.cpp
 * @brief A - Regular Triangle
 * @version 0.1
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
    // 三辺の長さが A, B, C
    // であるような正三角形が存在するなら Yes を
    // そうでなければ No を出力せよ。
    int A, B, C;
    cin >> A >> B >> C;

    if (A == B && A == C)
    {
        cout << "Yes" << endl;
    }
    else
    {
        cout << "No" << endl;
    }

    return 0;
}
