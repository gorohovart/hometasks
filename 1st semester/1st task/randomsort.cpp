//randomsort

#include <iostream>
#include <algorithm>
#include <cstdio>
#include <cmath>
using namespace std;

bool isSorted(int *a, int n)
{
    for (int i = 1; i < n; i++)
        if (a[i] < a[i - 1])
            return false;
    return true;
}

int main()
{
    int array[1000];
    int n = 0;

    cout << "Input array size: ";
    cin >> n;

    cout << "Input array: ";
    for (int i = 0; i < n; i++)
        cin >> array[i];

    while (true)
    {
        swap(array[rand() % n], array[rand() % n]);

        if (isSorted(array, n))
            break;
    }


    for (int i = 0; i < n; i++)
        cout << array[i] << ' ';
    cout << '\n';

    return 0;
}
