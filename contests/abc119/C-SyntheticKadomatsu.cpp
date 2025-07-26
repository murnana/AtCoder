/**
 * @file C-SyntheticKadomatsu.cpp
 * @author murnana
 * @brief C - Synthetic Kadomatsu
 * @date 2019-02-24
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <iostream>
#include <vector>
#include <map>
#include <string>
#include <algorithm>
#include <math.h>
using namespace std;

int GetAnswer(const int Goal, vector<int> &L)
{
    cerr << "-----------------" << endl;
    cerr << "Goal = " << Goal << endl;

    // 延長または短縮魔法を使う
    // 10MP以下の場合はこれが最小となる
    vector<int> costL;
    auto l = L.begin();
    int min = abs((*l) - Goal);
    costL.push_back(min);
    auto minL = l;
    ++l;
    for (; l != L.end(); ++l)
    {
        auto mp = abs((*l) - Goal);
        costL.push_back(mp);
        if (min < mp)
        {
            if (min <= 10)
            {
                // 最小なので
                // 対象の竹を抜いて終了
                L.erase(minL);
                cerr << "min = " << min << endl;
                return min;
            }
        }
        else
        {
            min = mp;
            minL = l;
        }
    }
    if (min <= 10)
    {
        // 最小なので
        // 対象の竹を抜いて終了
        L.erase(minL);
        cerr << "min = " << min << endl;
        return min;
    }

    // MP10以上なので組み合わせたほうが最小となるはず
    // そのため、コストが最小となる組み合わせを探す
    // …でもどうやってドンピシャを探せばいい…？

    return 10;
}

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    // 竹の数Nと、目的の長さA,B,Cを取得
    int N, A, B, C;
    cin >> N >> A >> B >> C;

    // 素材となる竹を取得
    vector<int> L;
    for (int i = 0; i < N; ++i)
    {
        int l;
        cin >> l;
        L.push_back(l);
    }
    sort(L.begin(), L.end());
    reverse(L.begin(), L.end());

    // 長い方から計算し、近い値を求める
    int MP = 0;
    MP += GetAnswer(A, L);
    MP += GetAnswer(B, L);
    MP += GetAnswer(C, L);

    cout << MP << endl;

    return 0;
}
