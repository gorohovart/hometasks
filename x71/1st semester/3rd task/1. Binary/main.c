#include <stdio.h>
#include <stdlib.h>

int main ()
{
	int n = 0;
    int flag = 0;
    int i = 0;

    printf("Input n: ");
    scanf("%d", &n);
    printf("Binary: ");

    for (i = 31; i >= 0; i--)
    {
        if (flag == 0 && (n >> i) & 1 == 1)
            flag = 1;
        
        if (flag == 1)
            printf("%d", (n >> i) & 1);
    }

    printf("\n");
    system ("pause");
	return 0;
}
