/*
Artem Gorokhov (c) 2013

Homework 1
Binary Power Function
*/
#include <stdio.h>
#include <stdlib.h>

int pow(int a, int n)
{
    int b;

    if (n == 0)
        return 1;
    if (n % 2 == 1)
        return pow(a, n - 1) * a;
    else
    {
        b = pow (a, n / 2);
        return b * b;
    }
}

int main()
{
    int a = 0;
    int n = 0;

    printf("a^n \ninput a: ");
    scanf("%d", &a);

    printf("input n: ");
    scanf("%d", &n);

    if (n >= 0)
        printf("a^n = %d \n", pow(a, n));
    else
        printf("a^n = %f \n", 1.0 / pow(a, n * -1));

    return 0;
}
