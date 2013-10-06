#include <iostream>
#include <cstring>
#include "sort.h"

using namespace std;
using namespace sort;

int main()
{
    char s1[1000];
    char s2[1000];

    printf("Input first string: ");
    gets(s1);

    printf("Input second string: ");
    gets(s2);

    int sLen = strlen(s1);

    if (strlen(s2) != sLen)
    {
        cout << "It is impossible.";
        return 0;
    }

    quickSort(s1, 0, sLen - 1);
    quickSort(s2, 0, sLen - 1);

    for (int i = 0; i < sLen; i++)
        if (s1[i] != s2[i])
        {
            cout << "It is impossible. " << sLen;
            return 0;
        }

    cout << "It is possible.";
    return 0;
}
