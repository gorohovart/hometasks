#include <stdio.h>
#include <stdlib.h>

int numLen(int n)
{
    int len = 1;
    
    if (n < 0)
    {
        n *= -1;
        len++;
    }

    while (n > 9)
    {
        n /= 10;
        len ++;
    }

    return len;
}
void printSign(int n)
{
    printf("    ");

    if ((n >> 31) & 1)
        printf("1");
    else printf("0");
}

int printExp(int n)
{
    int i = 0;
    int exp = 0;
    for (i = 30; i > 22; i--)
    {
        exp <<= 1;
        exp += (n >> i) & 1;
    }

    exp -= 127;

    printf("    %d", exp);

    return numLen(exp);
}

void printMantissa(int n)
{
    int i = 0;
    char mantissa[23];
    int lenth = 23;
    
    for (i = 22; i >= 0; i--)
        mantissa[22 - i] = (n >> i) & 1;

    i = 22;
    while (mantissa[i] == 0)
    {
        i--;
        lenth--;
    }

    for (i = 0; i < lenth; i++)
        printf("%d", mantissa[i]);
}
int main()
{
	float n = 0;
    int *N;
    int expLen = 0;
    int sign = 0;
    int i = 0;

    printf("Input float number: ");
    scanf("%f", &n);
    N = (int*) &n;
    
    printSign(*N);
    expLen = printExp(*N);

    printf("\n(-1)  * 2 ");
    for (i = 1; i <= expLen; i++)
        printf(" ");

    printf("* 1.");
    printMantissa(*N);
    printf("\n");
    
    system ("pause");
	return 0;
}