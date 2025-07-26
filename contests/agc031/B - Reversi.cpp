/**
 * @file B - Reversi.cpp
 * @author murnana
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <iostream>
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
    unsigned int N;
    cin >> N;

    vector<unsigned int> C;
    unsigned int ans = 1;
    unsigned int change_pattern = 0;
    for (unsigned int i = 0; i < N; ++i)
    {
        unsigned int c;
        cin >> c;
        C.push_back(c);
        cerr << c << ": ans = ";

        if (i <= 0)
        {
            cerr << ans << endl;
            continue;
        }
        if (C[i - 1] == c)
        {
            cerr << ans << endl;
            continue;
        }
        auto cnt = count(C.begin(), C.end(), c);
        if (cnt > 1 && i > 1)
        {
            ans += ++change_pattern;
            cerr << ans << endl;
            cerr << "\t change_pattern = " << change_pattern << endl;
            continue;
        }
        cerr << ans << endl;
    }

    cout << ans << endl;

    return 0;
}
