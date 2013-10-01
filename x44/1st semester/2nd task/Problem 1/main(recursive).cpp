#include <iostream>

using namespace std;

long fibonacci(int n)
{
    if (n < 3)
        return 1;
    return fibonacci(n - 1) + fibonacci(n - 2);
}

int main()
{
    int n = 0;

    cout << "input № of fibonacci number: ";
    cin >> n;

    cout << n << " fibonacci number is " << fibonacci(n) << '\n';

    return 0;
}
