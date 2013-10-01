#include <iostream>

using namespace std;

void quickSort(int *a, int l, int r)
{
    int i = l;
    int j = r;
    int x = a[(l + r) / 2];

    while (i <= j)
    {
        while (a[i] < x)
            i++;
        while (x < a[j])
            j--;
        if (i <= j)
        {
            int y = a[i];
            a[i] = a[j];
            a[j] = y;
        }
        i++;
        j--;
    }
    if (l < j)
        quickSort(a, l, j);
    if (i < r)
        quickSort(a, i, r);
}

int main()
{
    int a[300];
    int n = 0;

    cout << "input length of massive: ";
    cin >> n;

    for (int i = 0; i < n; i++)
    {
        cin >> a[i];
    }

    quickSort(a, 0, n - 1);

    for (int i = 0; i < n; i++)
    {
        cout << a[i] << ' ';
    }
    cout << '\n';

    return 0;
}
