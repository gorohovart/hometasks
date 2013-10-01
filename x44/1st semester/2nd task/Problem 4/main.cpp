//http://en.wikipedia.org/wiki/Stern%E2%80%93Brocot_tree
#include <iostream>

using namespace std;

void returnTree(int n, int a, int b, int c, int d)
{
    if (b + d <= n)
    {
        returnTree(n, a, b, a + c, b + d);

        cout << a + c << '/' << b + d << '\n';

        returnTree(n, a + c, b + d, c, d);
    }
}

int main()
{
    int n = 0;

    cout << "Drobi\ninput n: ";
    cin >> n;

    returnTree(n, 0, 1, 1, 1); // 0/1 and 1/1

    return 0;
}

