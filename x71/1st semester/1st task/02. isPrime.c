#include <string.h>
#include <stdio.h>
#include <stdlib.h>

int isPrime(int n)
{
    int i;
    for (i = 2; i * i < n; i++)
    {
        if (n % i == 0)
            return 0;
    }

    return 1;
}

int main()
{
    int n = 0;

    printf("input number: ");
    scanf("%d", &n);

    if (isPrime(n))
        printf("Your number is prime.\n");
    else printf("Your number is not prime.\n");

    system("pause");
    return 0;
}
