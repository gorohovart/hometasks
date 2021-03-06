/*
Artem Gorokhov (c) 2013

Homework 1
Number is prime?
*/
#include <stdio.h>

int isPrime(int n)
{
    int i;
    for (i = 2; i * i < n; i++)
    {
        if (n % i == 0)
        {
            return 0;
        }
    }

    return 1;
}

int main()
{
    int n = 0;

    printf("Input number: ");
    scanf("%d", &n);

    if (isPrime(n))
    {
        printf("Your number is prime.\n");
    }
    else
    {
    	printf("Your number is not prime.\n");
    }

    return 0;
}
