/*
Artem Gorokhov (c) 2013

Homework 1
String is palindrome?
*/
#include <string.h>
#include <stdio.h>
#include <math.h>

int isEqual(char a, char b)
{
    const int comp = 'a' - 'A';

    if ((a == b) || (fabs(a - b) == comp))
    {
        return 1;
    }
    return 0;
}

int isPalindrome(char *s)
{
    int lens = strlen(s);
    int a = 0;
    int b = 0;
    
    b = lens - 1;
    if (s[b] < 30)
    {
        b--;
    }

    while (a <= b)
    {
        while (s[a] == ' ')
        {
            a++;
            if (a == lens)
            {
                break;
            }
        }
        while (s[b] == ' ')
        {
            b--;
            if (b < 0)
            {
                break;
            }
        }

        if (a > b)
        {
            break;
        }

        if (isEqual(s[a], s[b]) == 0)
        {
            return 0;
        }
        a++;
        b--;

    }

    return 1;
}

int main()
{
    char s[200];


    printf("input string : ");
    fgets(s, 200, stdin);
    
    if (isPalindrome(s))
    {
        printf("String is palindrome\n");
    }
    else 
    {
        printf("String is not palindrome\n");
    }
    return 0;
}
