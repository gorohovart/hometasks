#include <iostream>

using namespace std;

int main()
{
    int a = 0;
    int b = 0;
    int n = 0;

    cout << "a / b \na = ";
    cin >> a;

    cout << "b = ";
    cin >> b;

    bool isNegative = a * b < 0;

    if (a < 0)
        a *= -1;
    if (b < 0)
        b *= -1;

    while (a >= b)
    {
        a -= b;
        n++;
    }

    if (isNegative)
        n *= -1;

    cout << "a / b = " << n;
    return 0;
}
