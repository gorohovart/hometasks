#include <iostream>
#include "sort.h"

using namespace std;
using namespace sort;

int main()
{
    int heap[1000];
    int n = 0;

    cout << "Heapsort.\nInput array size: ";
    cin >> n;

    cout << "Input array: ";
    for (int i = 1; i <= n; i++)
        cin >> heap[i];

    heapSort(heap, 1, n);

    return 0;
}
