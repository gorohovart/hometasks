#include <iostream>
#include "sort.h"

using namespace std;
using namespace sort;

void sort::quickSort(char *array, int firstElement, int lastElement)
{
    int i = firstElement;
    int j = lastElement;
    char x = array[(firstElement + lastElement) / 2];

    while (i <= j)
    {
        while (array[i] < x)
            i++;
        while (x < array[j])
            j--;
        if (i <= j)
        {
            char y = array[i];
            array[i] = array[j];
            array[j] = y;
        }
        i++;
        j--;
    }
    if (firstElement < j)
        quickSort(array, firstElement, j);
    if (i < lastElement)
        quickSort(array, i, lastElement);
}

