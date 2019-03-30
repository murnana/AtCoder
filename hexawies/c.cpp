/**
 * @file c.cpp
 * @brief C - Snuke the Wizard
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <algorithm>
#include <iostream>
#include <string>
#include <vector>
using namespace std;

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    int N, Q;
    cin >> N >> Q;

    string golems;
    vector<char> golemMap;
    vector<int> golemCount;
    cin >> golems;
    for (int i = 0; i < N; ++i)
    {
        golemMap.push_back(golems[i]);
        golemCount.push_back(1);
    }

    int maxGolemCount = N;
    for (int i = 0; i < Q; ++i)
    {
        if (maxGolemCount <= 0)
            break;

        char t, d;
        cin >> t >> d;
        vector<int> indexes;
        for (int index = 0; index < N; ++index)
        {
            if (golemMap[index] == t)
            {
                indexes.push_back(index);
            };
        }
        for_each(indexes.begin(), indexes.end(), [&](int index) {
            auto &count = golemCount[index];
            if (d == 'L')
            {
                if (index <= 0)
                {
                    maxGolemCount -= count;
                    count = 0;
                    return;
                }
                golemCount[index - 1] += count;
                count = 0;
            }
            else
            {
                if (index >= N - 1)
                {
                    maxGolemCount -= count;
                    count = 0;
                    return;
                }
                golemCount[index + 1] += count;
                count = 0;
            }
        });
    }

    cout << maxGolemCount << endl;

    return 0;
}
