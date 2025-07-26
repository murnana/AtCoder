/**
 * @file A-Entrance-Examination.cpp
 * @author murnana
 * @brief A - B +/- A
 *   https://atcoder.jp/contests/abc118/tasks/abc118_a
 * @date 2019-02-16
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <ios>
#include <iostream>
#include <iomanip>
using namespace std;

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    // A, Bを受け取る
    int A, B;
    cin >> A >> B;

    if (B <= 0 || A <= 0)
    {
        // 0で割らないで・・・！
        // 問題の条件分的にそんな数字出ないけど
    }
    else if (B % A)
    {
        cout << (B - A) << endl;
    }
    else
    {
        cout << (A + B) << endl;
    }
    return 0;
}
