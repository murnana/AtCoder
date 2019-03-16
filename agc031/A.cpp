/**
 * @file A.cpp
 * @author murnana
 * @brief 
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
        cerr << "----------------------" << endl;
        cerr << "s = " << s << endl;
        if (S.size() > 0)
        {
            if (S.back() == s)
                continue;
        }
        cerr << "add \"" << s << "\" for S" << endl;
        S.push_back(s);
        ++count;
    }

    auto create = [](unsigned int count) {
        unsigned int ans = 1;
        for (unsigned int i = 2; i < count; ++i)
        {
            ans += i;
        }
        return ans;
    };

    cout << create(count) << endl;
    return 0;
}
