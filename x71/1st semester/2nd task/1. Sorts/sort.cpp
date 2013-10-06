#include <cstdio>
#include <cstdlib>
#include <iostream>
#include "sort.h"

//#define swap(a, b) { int x = a; a = b; b = x; }

using namespace std;
using namespace sort;

//вспомогательные функции
namespace sort
{
    void heapify(int*, int, int);
    void makeHeap(int*, int, int);
    int isSorted(int*, int);
}

void sort::heapify(int *heap, int firstElement, int lastElement)
{
    int current = firstElement;

    while (current * 2 <= lastElement)
    {
        int firstDescendant = current * 2;
        int secondDescendant = firstDescendant + 1;

        if (heap[current] < heap[firstDescendant])
        {
            if (heap[firstDescendant] > heap[secondDescendant])
            {
                swap(heap[current], heap[firstDescendant]);
                current = firstDescendant;
            }
        }
        else if (heap[current] > heap[secondDescendant])
        {
            swap(heap[current], heap[secondDescendant]);
            current = secondDescendant;
        }
    }
}

void sort::makeHeap(int *heap, int firstElement, int lastElement)
{
    for (int i = lastElement / 2; i >= firstElement; i--)
        heapify(heap, firstElement, lastElement);
}

int sort::isSorted(int *array, int lastElement)
{
    for (int i = 2; i <= lastElement; i++)
        if (array[i] < array[i - 1])
            return 0;
    return 1;
}

//сортировки

void sort::heapSort(int *heap, int firstElement, int lastElement)
{
    makeHeap(heap, firstElement, lastElement);

    while (lastElement > firstElement)
    {
        swap(heap[firstElement], heap[lastElement]);
        lastElement--;

        heapify(heap, firstElement, lastElement);
    }
}

void sort::quickSort(int *array, int firstElement, int lastElement)
{
    int i = firstElement;
    int j = lastElement;
    int x = array[(firstElement + lastElement) / 2];

    while (i <= j)
    {
        while (array[i] < x)
            i++;
        while (x < array[j])
            j--;
        if (i <= j)
        {
            int y = array[i];
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

void sort::randomSort(int *array, int lastElement)
{
    while (true)
    {
        swap(array[rand() % lastElement], array[rand() % lastElement]);

        if (isSorted(array, lastElement) == 1)
            break;
    }
}

void sort::bubbleSort(int *array, int firstElement, int lastElement)
{
    for (int i = firstElement; i < lastElement; i++)
        for (int j = i; j <= lastElement; j++)
            if (array[i] > array[j])
                swap(array[i], array[j]);
}
