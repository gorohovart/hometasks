/*
Artem Gorokhov (c) 2013

Homework 2
Sort library check.
*/
#include <stdio.h>
#include <stdlib.h>
#include "sort.h"

int main()
{
    int array[1000];
    int n = 0;
    int i = 0;
    int num = 0;
    
    printf("Sort.\nChoose type of sorting:\n");
    printf("1. Heap sort\n");
    printf("2. Quick sort\n");
    printf("3. Bubble sort\nYour choise: ");
    scanf("%d", &num);
    
    printf("Input array size: ");
    scanf("%d", &n);
    
    printf("Input array: ");
    for (i = 1; i <= n; i++)
        scanf("%d", &array[i]);
    
    switch (num)
    {
        case 1:
            heapSort(array, 1, n);
            break;
        case 2:
            quickSort(array, 1, n);
            break;
        case 3:
            bubbleSort(array, 1, n);
            break;
    }
    
    printf("Sorted array:\n");
    for (i = 1; i <= n; i++)
        printf("%d ", array[i]);

    printf("\n");
    system ("pause");
    return 0;
}

