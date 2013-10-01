#include <iostream>

using namespace std;

int pow(int a, int n)
{
    if (n == 0)
        return 1;
    if (n % 2 == 1)
        return pow(a, n - 1) * a;
    else
    {
        int b = pow (a, n / 2);
        return b * b;
    }
}

int main()
{
    int a = 0;
    int n = 0;

    cout << "input a: ";
    cin >> a;

    cout << "input n: ";
    cin >> n;

    if (n >= 0)
        cout << "a^n = " << pow(a, n) << '\n';
    else
        cout << "a^n = " << 1.0 / pow(a, n * -1) << '\n';

    return 0;
}
