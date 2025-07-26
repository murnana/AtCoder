#include <iostream>
#include <string>
using namespace std;

/**
 * @brief 問題文の関数を定義
 * 
 * @tparam T 
 * @param n 
 * @return T 
 */
template <typename T>
T Func(T n)
{
    if (n < 2)
    {
        return 1;
    }
    return n * Func(n - 2);
}

/**
 * @brief プログラムのエントリーポイントです
 * 
 * @return int 終了後、0を返却しなければなりません。
 */
int main()
{
    // 整数の入力
    long N;
    cin >> N;

    auto result = Func<long>(N);
    string resultString = to_string(result);
    long zeroCount = 0;
    for (unsigned long i = resultString.length() - 1; i >= 0; --i)
    {
        if (resultString[i] != '0')
        {
            break;
        }
        ++zeroCount;
    }

    // 出力
    cout << zeroCount << endl;
    return 0;
}
