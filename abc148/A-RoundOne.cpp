#include<iostream>
using namespace std;

/**
 * @brief プログラムのエントリーポイントです
 * 
 * @return int 終了後、0を返却しなければなりません。
 */
int main()
{
    // 入力
    int A, B;
    cin >> A >> B;

    int anser = (1 + 2 + 3) - ( A + B );

    // 出力
    cout << anser << endl;

    return 0;
}
