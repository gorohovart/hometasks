#include <iostream>
#include <cstring>
#include <cstdio>
using namespace std;

int min(int a, int b)
{
    if (a > b)
        return b;
    else
        return a;
}

void zFunction(char *s, int *z)
{
    int n = strlen(s) - 1;
    int l = 0;
    int r = 0;
    for (int i = 1; i < n; i++)
    {
        if (i <= r)
            z[i] = min (r - i + 1, z[i - l]);

        while (i + z[i] < n && s[z[i]] == s[i + z[i]])
            z[i]++;

        if (i + z[i] - 1 > r)
        {
            l = i;
            r = i + z[i] - 1;
        }
    }
}

int main()
{
    char s[400];
    char s1[200];

    int z[400];

    cout << "input s : ";
    fgets(s1, 200, stdin);

    cout << "input s1 : ";
    fgets(s, 200, stdin);

    int s1len = strlen(s) - 1;
    strcat(s, "#");
    strcat(s, s1);

    for (int i = 0; i < strlen(s); i++)
        z[i] = 0;

    zFunction(s, z);

    int sum = 0;

    for (int i = 0; i < strlen(s); i++)
        if (z[i] == s1len)
            sum++;

    cout << sum << '\n';

    return 0;
}

