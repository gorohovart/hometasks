/*
Artem Gorokhov (c) 2013

Homework 2
String library.
*/
#include <stdio.h>
#include <stdlib.h>
#include "str.h"

int strlen(char *string)
{
    int i = 0;

    while (string[i] != 0)
    {
        i++;
    }
    return i;
}

void strcpy(char *s1, char *s2)
{
    int i = 0;

    while (s2[i] != 0)
    {
        s1[i] = s2[i];
        i++;
    }

    s1[i] = 0;
}

void strcat(char *s1, char *s2)
{
    const int len1 = strlen(s1);
    int i = len1;

    while(s2[i - len1] != 0)
    {
        s1[i] = s2[i - len1];
        i++;
    }
    
    s1[i] = 0;
}


int strcmp(char *s1, char *s2)
{
    int i = 0;

    while(s1[i] != 0 && s2[i] != 0)
    {
        if (s1[i] < s2[i])
        {
            return -1;
        }
        if (s1[i] > s2[i])
        {
            return 1;
        }

        i++;
    }

    if (s1[i] < s2[i])
    {
        return -1;
    }
    if (s1[i] == s2[i]) 
    {
        return 0;
    }
    if (s1[i] > s2[i]) 
    {
        return 1;
    }
}