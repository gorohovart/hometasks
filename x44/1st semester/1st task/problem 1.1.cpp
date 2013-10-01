#include <iostream>

using namespace std;

int main()
{
    int x = 0;

    cout << "x = ";
    cin >> x;

    int x2 = x * x;

    cout << '\n' << "x^4 + x^3 + x^2 + x = " << (x2 + 1) * (x2 + x);

    return 0;
}
