#include <stdio.h>
#include <stdlib.h>

char isLetter(char a)
{
    if (('a' <= a && a <= 'z') || ('�' <= a && a <= '�'))
    {
        return a;
    }
    else if ('A' <= a && a <= 'Z')
    {
        return a - ****;
    }
    else if ('�' <= a && a <= '�')
    {
        return a - ****;
    }
    else
    {
        return 0;
    }
}
int main()
{
    int i = 0;
    FILE *in = stdin;

    while (!feof(in))
    {
        char a;

        fscanf(in, "%c", &a);

        if (isLetter(a))
        {
            if (i)
            {
                char *word = (char*) malloc (sizeof(char) * (i + 2));
                word[i] = a;
                word[i + 1] = 0;
            }
            else
        }


    }
}