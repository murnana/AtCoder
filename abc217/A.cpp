#include<iostream>

/**
 * @brief プログラムのエントリーポイントです
 * 
 * @return int 終了後、0を返却しなければなりません。
 */
int main()
{
    // 入力
    std::string S, T;
    std::cin >> S;
    std::cin >> T;

    if(S < T)
    {
        std::cout << "Yes" << std::endl;
    }
    else
    {
        std::cout << "No" << std::endl;
    }

    // 出力
    return 0;
}
