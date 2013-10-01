#include <iostream>

using namespace std;

int main()
{
    int n = 0;
    bool isPrime[100];

    cout << "input n: ";
    cin >> n;

    if (n > 1) cout << "2 ";

    for (int i = 3; i <= n; i += 2) //only odd numbers
    {
        isPrime[i] = true;
    }

    for (int i = 3; i <= n; i += 2)
    {
        if (isPrime[i])
        {
            cout << i << ' ';
            for (int j = i + i; j <= n; j += i)
            {
                isPrime[j] = false;
            }

        }
    }
    return 0;
}
