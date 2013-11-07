/*
Artem Gorokhov (c) 2013

Homework 2
String library check.
*/
#include <stdio.h>
#include <stdlib.h>
#include "str.h"

int main ()
{
    char s1[] = {"asd"};
    char s2[] = {"qwerty"};
    char s3[15];

    printf("s1: %s\ns2: %s\n", s1, s2);
    printf("strlen(s1) = %d\nstrlen(s2) = %d\n", strlen(s1), strlen(s2));

    strcpy(s3, s1);
    printf("s3 = s1 = %s\n", s3);

    strcat(s3, s2);
    printf("s1 + s2 = %s\n", s3);

    printf("s1 > s2? %d\n", strcmp(s1, s2));

    return 0;
}
