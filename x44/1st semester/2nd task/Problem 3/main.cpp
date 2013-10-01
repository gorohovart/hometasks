#include <iostream>

using namespace std;

void printSum(int n, int lastSummand, int sum, int *array)
{
    int summands[1000];
    for (int i = 0; i <= array[0]; i++)
        summands[i] = array[i];

    summands[0]++;

    for (int i = lastSummand; i < n - sum; i++)
    {
        summands[summands[0]] = i;

        if (i <= n - (sum + i))
            printSum(n, i, sum + i, summands);
    }

    for (int i = 1; i < summands[0]; i++)
        cout << summands[i] << '+';
    cout << n - sum << '\n';
}

int main()
{
    int n = 0;
    int summands[1000] = {0};

    cout << "Summands\ninput n: ";
    cin >> n;

    summands[0] = 1;
    for (int i = 1; i <= n/2; i++)
    {
        summands[summands[0]] = i;
        printSum(n, i, i, summands);
    }

    return 0;
}
