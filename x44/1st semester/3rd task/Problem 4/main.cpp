#include <iostream>
#include <cstring>
#include "sort.h"

using namespace std;
using namespace sort;

int main()
{
    char s[1000];

    printf("Input n: ");
    gets(s);

    quickSort(s, 0, strlen(s) - 1);

    int i = 0;
    while (s[i] == '0')
        i++;

    swap(s[i], s[0]);


    cout << s;
    return 0;
}
