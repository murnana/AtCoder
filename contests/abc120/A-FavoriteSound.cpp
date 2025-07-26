/**
 * @file A-FavoriteSound.cpp
 * @author murnana
 * @brief A - Favorite Sound
 *  https://atcoder.jp/contests/abc120/tasks/abc120_a
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
    // 自販で買うジュースの値段A円、
    // 高橋君が持っているお金B円
    // 聞きたい音の回数C回を取得する
    int A, B, C;
    cin >> A >> B >> C;

    // C回音を聞くのにいくらか = C * A
    // それはB円で足りるのか
    if (B >= C * A)
    {
        cout << C << endl;
    }
    else
    {
        cout << (B / A) << endl;
    }

    return 0;
}
