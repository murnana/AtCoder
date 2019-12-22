#include <iostream>
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
    cin >> N;

    int *A = new int[N];
    for (int i = 0; i < N; ++i)
    {
        cin >> A[i];
    }

    // すぬけさんが満足するには、
    // レンガが左から 1, 2, 3…と並ぶようにしなければならない
    // つまり、最初の「1」を見つける必要がある
    // その後、2, 3 … と連番が見つかるまで、レンガを砕き続ける必要がある
    int breakCount = 0;
    int checkNumber = 1;
    for (int i = 0; i < N; ++i)
    {
        if (A[i] == checkNumber)
        {
            ++checkNumber;
        }
        else
        {
            ++breakCount;
        }
    }

    // 出力
    if (checkNumber > 1)
    {
        cout << breakCount << endl;
    }
    else
    {
        cout << "-1" << endl;
    }

    delete[] A;

    return 0;
}
