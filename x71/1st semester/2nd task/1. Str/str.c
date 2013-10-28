#include <stdio.h>
#include <stdlib.h>
#include "str.h"

int strlen(char *string)
{
	int i = 0;

	while (string[i] != 0 && string[i] != 10)
		i++;
	return i;
}

void strcpy(char *s1, char *s2)
{
	int len2 = strlen(s2);

    int i = 0;
	for (i = 0; i < len2; i++)
		s1[i] = s2[i];

    s1[len2] = 0;
}

void strcat(char *s1, char *s2)
{
	int len1 = strlen(s1);
	int len2 = strlen(s2);
    int i = 0;

	for (i = len1; i < len1 + len2; i++)
		s1[i] = s2[i - len1];

    s1[len1 + len2] = 0;
}


int strcmp(char *s1, char *s2)
{
    int len1 = strlen(s1);
	int len2 = strlen(s2);
    int min = len1;
    int i = 0;

    if (len1 > len2)
        min = len2;
    	
    for (i = 0; i < min; i++)
    {
        if (s1[i] < s2[i])
            return -1;
        if (s1[i] > s2[i])
            return 1;
    }

	if (len1 < len2) 
		return -1;
	if (len1 == len2) 
		return 0;
	if (len1 > len2) 
		return 1;
}