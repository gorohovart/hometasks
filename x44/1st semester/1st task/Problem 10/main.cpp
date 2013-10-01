#include <iostream>
#include <cstring>
#include <cstdio>
#include <cmath>
using namespace std;

bool isEqual(char a, char b)
{
    const int comp = 'a' - 'A';

    return (a == b || fabs(a - b) == comp);
}

int main()
{
    char s[200];

    cout << "Palindrome\nInput string: ";
    fgets(s, 200, stdin);

    int a = 0;
    int b = strlen(s) - 2;

    while (a <= b)
    {
        while (s[a] == ' ')
            a++;
        while (s[b] == ' ')
            b--;

        if (a > b)
            break;

        if (!isEqual(s[a], s[b]))
        {
            cout << "s is not palindrome";
            return 0;
        }
        a++;
        b--;

    }

    cout << "s is palindrome";

    return 0;
}

