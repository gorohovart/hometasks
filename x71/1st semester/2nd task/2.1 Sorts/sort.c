/*
Artem Gorokhov (c) 2013

Homework 2
Sort library.
*/
#include <stdio.h>
#include <stdlib.h>
#include "sort.h"

//secondary functions

void swap(int *a, int *b)
{
    int tmp = *a;
    *a = *b;
    *b = tmp;
}

void heapify(int *heap, int firstElement, int lastElement)
{
    int current = firstElement;
    
    while (current * 2 - firstElement + 1 <= lastElement)
    {
        int firstDescendant = current * 2 - firstElement + 1;
        int secondDescendant = firstDescendant + 1;
        
        if (secondDescendant <= lastElement)
        {
            int max = firstDescendant;
            
            if (heap[firstDescendant] < heap[secondDescendant])
            {
                max = secondDescendant;
            }
    
            if (heap[current] < heap[max])
            {
                swap(&heap[current], &heap[max]);
                current = max;
            }
            else
            {
                return;
            }
        }
        else
        {
            if (heap[current] < heap[firstDescendant])
            {
                swap(&heap[current], &heap[firstDescendant]);
                current = firstDescendant;
            }
            else
            {
                return;
            }
        }
    }
}

void makeHeap(int *heap, int firstElement, int lastElement)
{
    int i = 0;
    for (i = lastElement / 2; i >= firstElement; i--)
    {
        heapify(heap, firstElement, lastElement);
    }
}

//sort functions

void heapSort(int *heap, int firstElement, int lastElement)
{
    makeHeap(heap, firstElement, lastElement);
    
    while (lastElement > firstElement)
    {
        swap(&heap[firstElement], &heap[lastElement]);
        lastElement--;

        heapify(heap, firstElement, lastElement);
    }
}

void quickSort(int *array, int firstElement, int lastElement)
{
    int i = firstElement;
    int j = lastElement;
    int x = array[(firstElement + lastElement) / 2];
    
    while (i <= j)
    {
        while (array[i] < x)
        {
            i++;
        }
        while (x < array[j])
        {
            j--;
        }

        if (i <= j)
        {
            swap(&array[i], &array[j]);
        }
        i++;
        j--;
    }
    if (firstElement < j)
    {
        quickSort(array, firstElement, j);
    }
    if (i < lastElement)
    {
        quickSort(array, i, lastElement);
    }
}

void bubbleSort(int *array, int firstElement, int lastElement)
{
    int i = 0;
    int j = 0;
    
    for (i = firstElement; i < lastElement; i++)
    {
        for (j = i; j <= lastElement; j++)
        {
            if (array[i] > array[j])
            {
                swap (&array[i], &array[j]);
            }
        }
    }
}
