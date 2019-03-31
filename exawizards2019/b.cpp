/**
 * @file b.cpp
 * @brief B - Red or Blue
 * @version 0.1
 * 
 * @copyright Copyright (c) 2019
 * 
 */

#include <iostream>
#include <string>
using namespace std;

/**
 * @brief Entry point
 * 
 * @return int 
 */
int main()
{
    int N;
    cin >> N;

    string colors;
    int red = 0;
    int blue = 0;
    cin >> colors;

    for (int i = 0; i < N; ++i)
    {
        ('R' == colors[i]) ? ++red : ++blue;
    }

    cout << (red > blue ? "Yes" : "No") << endl;

    return 0;
}
