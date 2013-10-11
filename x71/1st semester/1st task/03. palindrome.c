#include <string.h>
#include <stdio.h>
#include <math.h>
#include <stdlib.h>

int isEqual(char a, char b)
{
    const int comp = 'a' - 'A';

    if ((a == b) || (fabs(a - b) == comp))
        return 1;
    return 0;
}

int main()
{
    char s[200];
    int a = 0;
    int b = 0;

    printf("input string : ");
    fgets(s, 200, stdin);
    
    b = strlen(s) - 2;

    while (a <= b)
    {
        while (s[a] == ' ')
            a++;
        while (s[b] == ' ')
            b--;

        if (a > b)
            break;

        if (isEqual(s[a], s[b]) == 0)
        {
            printf("string is not palindrome.\n");
            system("pause");
            return 0;
        }
        a++;
        b--;

    }

    printf("string is palindrome");

    system("pause");
    return 0;
}
