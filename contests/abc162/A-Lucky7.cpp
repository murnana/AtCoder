#include<iostream>

/**
 * @brief プログラムのエントリーポイントです
 * 
 * @return int 終了後、0を返却しなければなりません。
 */
int main()
{
    // 入力
    std::string N;
    std::cin >> N;

    for(int i = 0; i < N.length(); ++i)
    {
        if(N[i] == '7')
        {
            std::cout << "Yes" << std::endl;
            return 0;
        }
    }

    // 出力
    std::cout << "No" << std::endl;
    return 0;
}
