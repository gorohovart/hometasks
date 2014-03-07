/*
Artem Gorokhov (c) 2013

Homework 3
Decimal to binary
*/
#include <stdio.h>

void printBin(int n)
{
    int i = 0;
    int flag = 0;

    printf("Binary: ");
    for (i = 31; i >= 0; i--)
    {
        if (flag == 0 && (n >> i) & 1 == 1)
        {
            flag = 1;
        }
        if (flag == 1)
        {
            printf("%d", (n >> i) & 1);
        }
    }

    printf("\n");
}

int main ()
{
    int n = 0;
    
    printf("Input n: ");
    scanf("%d", &n);
    printBin(n);

    return 0;
}
