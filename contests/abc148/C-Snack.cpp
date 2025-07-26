#include <iostream>
using namespace std;

/**
 * @brief ユークリッドの互除法による、
 *        最大公約数を求める
 * 
 * @param m 
 * @param n 
 * @return long 
 */
template <typename T>
T Gcd(T m, T n)
{
    T temp;
    while (m % n != 0)
    {
        temp = n;
        n = m % n;
        m = temp;
    }
    return n;
}

/**
 * @brief 最小公倍数を求める
 * 
 * @tparam T 
 * @param m 
 * @param n 
 * @return T 
 */
template <typename T>
T Lcm(T m, T n)
{
    return m * n / Gcd<T>(m, n);
}

/**
 * @brief プログラムのエントリーポイントです
 * 
 * @return int 終了後、0を返却しなければなりません。
 */
int main()
{
    // 入力
    long A, B;
    cin >> A >> B;

    // 出力
    cout << Lcm<long>(A, B) << endl;
    return 0;
}
