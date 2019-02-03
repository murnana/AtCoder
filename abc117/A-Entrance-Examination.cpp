/**
 * @file A-Entrance-Examination.cpp
 * @author murnana
 * @brief A - Entrance Examination https://atcoder.jp/contests/abc117/tasks/abc117_a
 * @date 2019-02-03
 * 
 * @copyright Copyright (c) 2019
 * 
 */

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
    // 必要な勉強時間(T時間)と
    // 世界Bの速度(X倍)の値を入力から受け取る
    double T, X;
    cin >> T >> X;

    // 世界Aでは何時間進んでいるか出力する
    // https://marycore.jp/prog/cpp/stream-format-float/ より
    // 標準出力の精度を変えないと、正しい答えにならない
    cout << setprecision(11);
    cout << (T/X) << endl;
    return 0;
}
