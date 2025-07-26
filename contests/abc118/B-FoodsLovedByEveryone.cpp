/**
 * @file B-FoodsLovedByEveryone.cpp
 * @author murnana
 * @brief B - Foods Loved by Everyone
 *      https://atcoder.jp/contests/abc118/tasks/abc118_b
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

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    // N人の人と、M種類の食べ物を受け取る
    int N, M;
    cin >> N >> M;
    vector<int> Food;

    // 最初の一人が好きなものについて調べる
    // それ以外は要らないので外す
    int K;
    cin >> K;
    for (int k = 0; k < K; ++k) {
        int like;
        cin >> like;
        Food.push_back(like);
    }

    // 次からは要らない数字だけを抽出する必要がある
    for (int n = 1; n < N; ++n) {
        cin >> K;
        vector<int> isLike;
        for (int k = 0; k < K; ++k) {
            int like;
            cin >> like;
            // Foodリストにあるものを追加していく
            auto isFind = find(Food.begin(), Food.end(), like);
            if (isFind != Food.end()) {
                isLike.push_back(like);
            }
        }
        // Foodリスト更新
        Food = isLike;
    }

    cout << Food.size() << endl;
    return 0;
}
