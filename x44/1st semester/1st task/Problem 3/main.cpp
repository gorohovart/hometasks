#include <iostream>

using namespace std;

void reverse(int *array, int x, int y)
{
    for (int i = x; i < x + (y - x + 1) / 2; i++)
    {
        int s = array[i];
        array[i] = array[y - i + x];
        array[y - i + x] = s;
    }
}

int main()
{
    int a[300];
    int n = 0;
    int m = 0;

    cout << "input m ";
    cin >> m;

    cout << "input n ";
    cin >> n;

    for (int i = 1; i <= n + m; i++)
    {
        cout << "a[" << i << "] = ";
        cin >> a[i];
    }

    reverse(a, 1, m);
    reverse(a, m + 1, m + n);
    reverse(a, 1, m + n);

    cout << '\n';
    for (int i = 1; i <= n + m; i++)
    {
        cout << "a[" << i << "] = " << a[i] << '\n';
    }
    return 0;
}
