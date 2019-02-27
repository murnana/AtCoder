/**
 * @file C-MonstersBattleRoyale.cpp
 * @author murnana
 * @brief C - Monsters Battle Royale
 *      https://atcoder.jp/contests/abc118/tasks/abc118_c
 * @date 2019-02-16
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <ios>
#include <iostream>
#include <iomanip>
#include <vector>
#include <algorithm>
using namespace std;
int searchMin(vector<int> &Monster);

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    // 登場モンスター数Nを入れる
    int N;
    cin >> N;
    vector<int> Monster;

    // 登場モンスターの体力を入れる
    for (int n = 0; n < N; ++n)
    {
        int a;
        cin >> a;
        Monster.push_back(a);
    }

    cout << searchMin(Monster) << endl;
    return 0;
}

// 体力の最小値を求めるには
// 最終的に割り算の余りが最小値になる
// そのため、割る数が少なければ少ないほど最小の体力となる
int searchMin(vector<int> &Monster)
{
    // cerr << "Begin serarchMin" << endl;
    // for_each(Monster.begin(), Monster.end(), [](int a) {
    //     cerr << a << " ";
    // });
    // cerr << endl;
    // ①初期体力で最も最小となるモンスターを選択する
    std::sort(Monster.begin(), Monster.end());
    // => Monster[0]が最小

    // 結果が1になったらこれ以上計算しても仕方ないので
    // そのまま帰す
    if (Monster[0] <= 1)
        return 1;
    if (Monster.size() <= 2)
        return Monster[0];

    // ②自分以外のすべての数の余りを調べる
    vector<int> OtherMonster;
    auto min = Monster[0];
    auto minMonsterInitHitPoint = Monster[0];
    auto N = Monster.size();
    for (int n = 1; n < N; ++n)
    {
        auto temp = Monster[n] % Monster[0];
        if (min > temp && temp > 0)
        {
            OtherMonster.push_back(minMonsterInitHitPoint);
            minMonsterInitHitPoint = Monster[n];
            min = temp;
        }
        else
        {
            OtherMonster.push_back(Monster[n]);
        }
    }
    // for_each(OtherMonster.begin(), OtherMonster.end(), [](int a) {
    //     cerr << a << " ";
    // });
    // cerr << endl;

    // 結果が1になったらこれ以上計算しても仕方ないので
    // そのまま帰す
    // cerr << "min = " << min << endl;
    if (min <= 1)
        return 1;

    // Monster[0]と同じならそのまま帰す
    if (min >= Monster[0])
        return min;

    // もっかい計算する
    if (OtherMonster.size() <= 1)
    {
        return min;
    }
    OtherMonster.push_back(min);
    return searchMin(OtherMonster);
};
