#include <iostream>

using namespace std;

int main()
{
    int n = 0;

    cout << "input № of fibonacci number: ";
    cin >> n;

    cout << n << " fibonacci number is ";

    if (n < 3)
    {
        cout << '1';
        return 0;
    }

    int a = 1;
    int b = 1;

    for (int i = 3; i <= n; i++)
    {
        int m = b;
        b += a;
        a = m;
    }

    cout << b;

    return 0;
}
