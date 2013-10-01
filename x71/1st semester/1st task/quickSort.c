#include <cstring>
#include <cstdio>

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

    printf("input length of massive: ");
    scanf("%d", &n);

    for (int i = 0; i < n; i++)
    {
        scanf("%d", &a[i]);
    }

    quickSort(a, 0, n - 1);

    for (int i = 0; i < n; i++)
    {
        printf("%d ", a[i]);
    }
    printf("\n");

    return 0;
}
