/**
 * @file A-StillTBD.cpp
 * @author murnana
 * @brief A - Still TBD
 * @date 2019-02-24
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <iostream>
#include <array>
#include <string>
#include <stdio.h>
using namespace std;

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    // 文字列Sを取得
    string S;
    cin >> S;

    // 文字列Sをスラッシュ「/」で区切る
    array<string, 3> date;
    const string separator("/");
    const auto separatorLength = separator.length();
    auto offset = string::size_type(0);
    for (auto i = 0; i < 3; ++i)
    {
        auto pos = S.find(separator, offset);
        if (pos == string::npos)
        {
            date[i] = S.substr(offset);
        }
        else
        {
            date[i] = S.substr(offset, pos - offset);
            offset = pos + separatorLength;
        }
        // cerr << "date[" << i << "]: " << date[i] << endl;
    }

    // 西暦から比較
    if (2019 < atoi(date[0].c_str()))
    {
        cout << "TBD" << endl;
    }
    else if (4 < atoi(date[1].c_str()))
    {
        cout << "TBD" << endl;
    }
    else if (30 < atoi(date[2].c_str()))
    {
        cout << "TBD" << endl;
    }
    else
    {
        cout << "Heisei" << endl;
    }

    return 0;
}
