/**
 * @file A - Colorful Subsequence.cpp
 * @author murnana
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <iostream>
#include <vector>
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

    vector<char> S;
    unsigned int count = 0;
    for (unsigned int i = 0; i < N; ++i)
    {
        char s;
        cin >> s;
        cerr << "s = " << s << endl;
        if (S.size() > 0)
        {
            if (S.back() == s)
                continue;
        }
        S.push_back(s);
        ++count;
    }
    cerr << "----------------------" << endl;

    auto echelon = [](const unsigned int &count) {
        unsigned int ans = count;
        unsigned int cnt = ans;
        cerr << count << ": " << ans;
        while (--cnt)
        {
            ans += cnt;
            cerr << " + " << cnt;
        }
        cerr << " = " << ans << endl;
        return ans;
    };

    cout << echelon(count - 1) + echelon(count) << endl;
    return 0;
}
