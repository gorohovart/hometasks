/*
Artem Gorokhov (c) 2013

Homework 2
Pascal's "triangle"
*/
#include <stdio.h>
#include <stdlib.h>

int numLen(int n)
{
    int count = 1;

    while (n > 9)
    {
        n /= 10;
        count++;
    }

    return count;
}

void outLine(int n, int maxLen)
{
    int i = 0;
    int j = 0;
    for (i = 0; i < n; i++)
    {
        printf("+");
        for (j = 0; j < maxLen; j++)
        {
            printf("-");
        }
    }
    printf("+\n");
}

void outCell(int number, int maxLen)
{
    int i = 0;

    printf("|%d", number);
    for (i = 0; i < maxLen - numLen(number); i++)
    {
        printf(" ");
    }
}

void outTable(int n)
{
    char s1[1000];
    char s2[1000];
    int i = 0;
    int j = 0;
    int maxLen = 0;
    int **array;

    array = (int **) malloc(sizeof(int*) * (n + 1));
    for (i = 0; i <= n; i++)
    {
        array[i] = (int *)malloc(sizeof(int) * (n + 1));
    }
    
    for (i = 1; i <= n; i++)
    {
        for (j = 1; j <= n; j++)
        {
            if (i == 1 || j == 1)
            {
                array[i][j] = 1;
            }
            else
            {
                array[i][j] = array[i - 1][j] + array[i][j - 1];
            }
        }
    }

    maxLen = numLen(array[n][n]);
    
    for (i = 1; i <= n; i++)
    {
        outLine(n, maxLen);

        for (j = 1; j <= n; j++)
        {
            outCell(array[i][j], maxLen);
        }
        printf("|\n");
    }
    outLine(n, maxLen);
    
    free(array);
}

int main ()
{
    int n = 0;
    
    printf("Input n: ");
    scanf("%d", &n);

    outTable(n);
    return 0;
}