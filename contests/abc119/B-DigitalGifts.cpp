/**
 * @file B-DigitalGifts.cpp
 * @author murnana
 * @brief B - Digital Gifts
 * @date 2019-02-24
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <iostream>
#include <array>
#include <string>
#include <stdio.h>
using namespace std;

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    // 親戚の人数Nを取得
    int N;
    cin >> N;

    double sun = 0.0; // 小遣いの合計
    for (int i = 0; i < N; ++i)
    {
        // 小遣いの値xを取得
        double x;
        cin >> x;

        // 小遣いの種類uを取得
        string u;
        cin >> u;

        // 種類から小遣いの合計を入れる
        if (u == "BTC")
        {
            sun += x * 380000.0;
        }
        else    // JPY
        {
            sun += x;
        }
    }

    cout << sun << endl;

    return 0;
}
