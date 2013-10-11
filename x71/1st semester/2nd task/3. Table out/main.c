#include <cstdio>
#include <cstdlib>

using namespace std;

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
    for (int i = 0; i < n; i++)
    {
        printf("+");
        for (int j = 0; j < maxLen; j++)
            printf("-");
    }
    printf("+\n");
}

void outCell(int number, int maxLen)
{
    printf("|%d", number);
    for (int i = 0; i < maxLen - numLen(number); i++)
        printf(" ");
}


int main ()
{
	char s1[1000];
	char s2[1000];
    int n = 0;


    scanf("%d", &n);
	
    int **array = (int **) malloc(sizeof(int) * (n + 1));
	for (int i = 0; i <= n; i++)
	{
	    array[i] = (int *)malloc(sizeof(int) * (n + 1));
	}

    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= n; j++)
            if (i == 1 || j == 1)
                array[i][j] = 1;
            else
                array[i][j] = array[i - 1][j] + array[i][j - 1];


    int maxLen = numLen(array[n][n]);

    for (int i = 1; i <= n; i++)
    {
        outLine(n, maxLen);

        for (int j = 1; j <= n; j++)
            outCell(array[i][j], maxLen);
        printf("|\n");
    }
    outLine(n, maxLen);

    free(array);
    system ("pause");
	return 0;
}
