#include <iostream>

using namespace std;

long fact(long n)
{
    if (n > 1)
        return fact(n - 1) * n;
    else
        return 1;
}

int main()
{
    long n = 0;

    cout << "input n: ";
    cin >> n;

    cout << n << "! = " << fact(n) << '\n';

    return 0;
}
