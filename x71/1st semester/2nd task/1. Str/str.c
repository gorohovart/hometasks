#include <cstdio>
#include <cstdlib>
#include "str.h"

using namespace std;
using namespace str;

int str::strlen(char *string)
{
	int i = 0;

	while (string[i] != 0 && string[i] != 10)
		i++;
	return i;
}

void str::strcpy(char *s1, char *s2)
{
	int len2 = strlen(s2);

	for (int i = 0; i < len2; i++)
		s1[i] = s2[i];

    s1[len2] = 0;
}

void str::strcat(char *s1, char *s2)
{
	int len1 = strlen(s1);
	int len2 = strlen(s2);

	for (int i = len1; i < len1 + len2; i++)
		s1[i] = s2[i - len1];

    s1[len1 + len2] = 0;
}


int str::strcmp(char *s1, char *s2)
{
	int len1 = strlen(s1);
	int len2 = strlen(s2);
	
	if (len1 < len2) 
		return -1;
	if (len1 == len2) 
		return 0;
	if (len1 > len2) 
		return 1;
}