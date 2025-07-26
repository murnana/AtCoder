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
    int N;
    string S, T;
    cin >> N >> S >> T;

    string answer;

    for(int i = 0; i < N ; ++i)
    {
      	// cerr << S[i] << "," << T[i] << endl;
        answer = answer + S[i] + T[i];
    }

    // 出力
    cout << answer << endl;
    return 0;
}
