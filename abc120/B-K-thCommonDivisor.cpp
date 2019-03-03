/**
 * @file B-K-thCommonDivisor.cpp
 * @author murnana
 * @brief B - K-th Common Divisor
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <iostream>
using namespace std;

int EuclideanAlgorithm(int A, int B)
{
    if (A < B)
    {
        auto temp = A;
        A = B;
        B = temp;
    }
    while (B <= 0)
    {
        const auto div = A % B;
        A = B;
        B = div;
    }
    return A;
}

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    // 正整数A,BとK番目を取得
    int A, B, K;
    cin >> A >> B >> K;

    // 最大公約数を求める
    auto div = EuclideanAlgorithm(A, B);

    // もし1番目ならそれが答えになる
    if (K <= 1)
    {
        cout << div << endl;
    }
    else
    {
        // ???
    }

    return 0;
}
