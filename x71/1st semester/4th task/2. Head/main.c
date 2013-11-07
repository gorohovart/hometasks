/*
Artem Gorokhov (c) 2013

Homework 4
Head
*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void stdReadWrite(int n)
{
    char string[100][1000];
    int i = 0;

    for (i = 0; i < n; i++)
    {
        fgets(string[i], 1000, stdin);
    }

    printf("\n");
    for (i = 0; i < n; i++)
    {
        printf("%s", string[i]);
    }
}

void fileReadWrite(char *name, int n)
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
    {
        printf("%s", string[i]);
    }
}

int main(int argc, char **argv)
{
    int readFromStd = 1;
    int n = 10;
    int i = 0;
    char name[100];

    for (i = 1; i < argc; i++)
    {
        if (strcmp(argv[i], "-n") == 0)
        {
            sscanf(argv[i + 1], "%d", &n);
            i++;
        }
        else
        {
            readFromStd = 0;
            strcpy(name, argv[i]);
        }
    }
    
    if (readFromStd)
    {
        stdReadWrite(n);
    }
    else
    {
        fileReadWrite(name, n);
    }
}