#include <cstdio>
#include <cstdlib>
#include "str.h"

using namespace std;
using namespace str;

int main ()
{
	char s1[1000];
	char s2[1000];
	
    printf("input s1: ");
    fgets(s1, 200, stdin);

    printf("input s2: ");
	fgets(s2, 200, stdin);

	printf("\nstrlen(s1) = %d\nstrlen(s2) = %d\n", strlen(s1), strlen(s2));

    char s3[1000];

    strcpy(s3, s1);
    printf("s3 = s1 = %s\n", s3);

    strcat(s3, s2);
    printf("s1 + s2 = %s\n", s3);

    printf("s1 > s2? %d\n", strcmp(s1, s2));

    system ("pause");
	return 0;
}
