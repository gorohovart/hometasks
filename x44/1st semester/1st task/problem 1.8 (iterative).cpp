#include <iostream>

using namespace std;

int main()
{
    long n = 0;
    long factorial = 1;
    cout << "input n: ";
    cin >> n;

    for (int i = 1; i <= n; i++)
    {
        factorial *= i;
    }
    cout << n << "! = " << factorial << '\n';

    return 0;
}
