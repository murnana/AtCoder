#include <iostream>

/**
 * @brief プログラムのエントリーポイントです
 * 
 * @return int 終了後、0を返却しなければなりません。
 */
int main()
{
    // 入力
    unsigned int N;
    std::cin >> N;
    unsigned long long ans = 0;

    for (unsigned int i = 0; i < N; ++i)
    {
        if ((N % 3) <= 0)
        {
            continue;
        }
        if ((N % 5) <= 0)
        {
            continue;
        }
        ans += i;
    }

    // 出力
    std::cout << ans << std::endl;
    return 0;
}
