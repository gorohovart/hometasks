#include <iostream>

using namespace std;

int main()
{
    int numberOfSums[28] = {0};
    int numberOfTickets = 0;

    for (int i = 0; i < 10; i++)
        for (int j = 0; j < 10; j++)
            for (int k = 0; k < 10; k++)
                numberOfSums[i + j + k]++;

    for (int i = 0; i < 28; i++)
        numberOfTickets += numberOfSums[i] * numberOfSums[i];

    cout << numberOfTickets << " tickets.\n";

    return 0;

}
