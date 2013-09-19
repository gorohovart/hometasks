#include <cstring>
#include <cstdio>

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

    printf("a^n \ninput a: ");
    scanf("%d", &a);

    printf("input n: ");
    scanf("%d", &n);

    if (n >= 0)
        printf("a^n = %d \n", pow(a, n));
    else
        printf("a^n = %f \n", 1.0 / pow(a, n * -1));

    return 0;
}
