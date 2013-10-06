#include <iostream>

using namespace std;

int main()
{
    ifstream in("input.txt");

    int array[500][500];
    int n = 0;

    cout << "Spiral.\nInput N: ";
    cin >> n;

    cout << "Input array: ";
    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= n; j++)
            cin >> array[i][j];


    for (int i = 1; i <= n / 2; i++)
    {
        for (int j = i; j < n - i + 1; j++)
            cout << array[i][j] << ' ';
        for (int j = i; j < n - i + 1; j++)
            cout << array[j][n - i + 1] << ' ';

        for (int j = n - i + 1; j > i; j--)
            cout << array[n - i + 1][j] << ' ';
        for (int j = n - i + 1; j > i; j--)
            cout << array[j][i] << ' ';
    }

    cout << array[n / 2 + 1][n / 2 + 1] << '\n';

    return 0;
}
