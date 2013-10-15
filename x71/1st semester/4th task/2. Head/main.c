#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void inParams(int *n, char *name)
{
    char c[1000];
    scanf("%s", c);

    if (c[0] == '?')
        fgets(c, 1000, stdin);//to next line
    else if (c[0] == '-')
        scanf("%d", n);
    else
    {
        strcpy(name, c);
        return;
    }

    scanf("%s", name);
    fgets(c, 100, stdin);//to next line
}

void stdRead(int n)
{
    char string[100][1000];
    int i = 0;

    for (i = 0; i < n; i++)
        fgets(string[i], 1000, stdin);

    printf("\n");
    for (i = 0; i < n; i++)
        printf("%s", string[i]);
}

void fileRead(char *name, int n)
{
    char string[100][1000];
    int i = 0;
    FILE *inFile;
    int last = n;
    
    inFile = fopen (name, "r");

    for (i = 0; i < n; i++)
    {
        if (feof(inFile))
        {
            last = i;
            break;
        }
        fgets(string[i], 1000, inFile);
    }

    for (i = 0; i < last; i++)
    printf("%s", string[i]);
}

int main()
{
    int readFromStd = 1;
    int n = 10;
    int i = 0;
    char name[100];


    printf("Head.\nInput -n <numOfLines>(optional) nameOfFile(optional) (in single line)\nIf no parameters, in '?'\n");
    inParams(&n, name);

    if (name[0] > 33)
        fileRead(name, n);
    else
        stdRead(n);

    system("pause");
}