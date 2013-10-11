#include <iostream>
#include <windows.h>
#include "sort.h"

using namespace std;
using namespace sort;

int main()
{
    int array[1000];
    int n = 0;
    int num = 0;

    printf("Sort.\nChoose type of sorting:\n");
    printf("1. Heap sort(doesn't work)\n");
    printf("2. Quick sort\n");
    printf("3. Bubble sort\n");
    printf("4. Random sort.\n");
    scanf("%d", &num);

    printf("Input array size: ");
    scanf("%d", &n);

    printf("Input array: ");
    for (int i = 1; i <= n; i++)
        scanf("%d", &array[i]);

	DWORD startTime = GetTickCount();
	
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
        case 4:
            randomSort(array, n);
            break;
    }
	DWORD endTime = GetTickCount();

    for (int i = 1; i <= n; i++)
        printf("%d ", array[i]);
	printf("\n%d %d\n", endTime, startTime);

	system("pause");
    return 0;
}
