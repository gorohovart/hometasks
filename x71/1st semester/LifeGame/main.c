/*
Artem Gorokhov (c) 2013

Homework NaN.
Life game.
*/
#include <stdio.h>
#include <windows.h>
#include <stdlib.h>

void clrscr()
{
    int i = 0;
    for (i = 0; i < 30; i++)
    {
        printf("\n");
    }
}

void printState(int a)
{
    if (a == 1)
    {
        printf("@");
    }
    else 
    {
        printf(" ");
    }
}
int nextState(int n, int m, int **a, int i, int j, int *isEmpty, int* isChanged)
{
    int sum = a[(i - 1 + n) % n][(j - 1 + m) % m] + a[(i - 1 + n) % n][j] + a[(i - 1 + n) % n][(j + 1 + m) % m]; 
    sum += a[i][(j - 1 + m) % m] + a[i][(j + 1 + m) % m];
    sum += a[(i + 1 + n) % n][(j - 1 + m) % m] + a[(i + 1 + n) % n][j] + a[(i + 1 + n) % n][(j + 1 + m) % m];
    
    if (a[i][j])
    {
        if (sum == 2 || sum == 3)
        {
            *isEmpty = 0;
            return 1;
        }
        *isChanged = 1;
        return 0;
    }

    if (sum == 3)
    {
        *isEmpty = 0;
        *isChanged = 1;
        return 1;
    }
    return 0;
}

int game(int n, int m, int **current, int **next)
{
    int isChanged = 1;
    int isEmpty = 0;

    while (isChanged == 1 && isEmpty == 0)
    {
        int i = 0;
        int j = 0;
        int **ptr = NULL;

        isEmpty = 1;
        isChanged = 0;

        clrscr();
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < m; j++)
            {   
                next[i][j] = nextState(n, m, current, i, j, &isEmpty, &isChanged);
                printState(next[i][j]);
            }
            printf("\n");
        }

        ptr = current;
        current = next;
        next = ptr;
        Sleep(100);
    }
}

int main()
{
    FILE *in = fopen ("input.txt", "r"); // n, m ... 1/0
    int n = 0;
    int m = 0;
    int i = 0;
    int j = 0;
    int **a = NULL;
    int **b = NULL;
    char symbol;


    fscanf(in, "%d%d%c", &n, &m, &symbol);
    //printf("%d %d\n", n, m);
    
    a = (int**) malloc (sizeof(int*) * n);
    b = (int**) malloc (sizeof(int*) * n);
    
    for (i = 0; i < n; i++)
    {
        char *string;

        string = (char*) malloc (sizeof(char) * (m + 3));
        a[i] = (int*) malloc (sizeof(int) * m);
        b[i] = (int*) malloc (sizeof(int) * m);
        
        fgets(string, m + 3, in);

        for (j = 0; j < m; j++)
        {
            if (!('0' <= string[j] && string[j] <= '3'))
            {
                b[i][j] = 0;
                a[i][j] = 0;
                continue;
            }
            switch (string[j])
            {
            case '1':
                a[i][j] = 1;
                break;
            case '0':
                a[i][j] = 0;
                break;
            }
            
            b[i][j] = 0;
        }
    }
    
    for (i = 0; i < n; i++)
    {
        for (j = 0; j < m; j++)
        {   
            printf("%d ", a[i][j]);
        }
        printf("\n");
    }

    game(n, m, a, b);

    return 0;
}