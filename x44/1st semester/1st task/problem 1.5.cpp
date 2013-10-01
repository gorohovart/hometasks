#include <cstring>
#include <cstdio>
#include <iostream>

using namespace std;

bool isOpen(char);
bool isClose(char);
bool isPair(char, char);

int main()
{
    char stack[300];
    char a[300];

    int stackTop = -1;

    cout << "Brackets\n";
    cin >> a;

    for (int i = 0; i < strlen(a); i++)
    {
        if (isOpen(a[i]))
        {
            stackTop++;
            stack[stackTop] = a[i];
        }

        else if (isClose(a[i]))
        {
            if (isPair(stack[stackTop], a[i]))
                stackTop--;
            else
            {
                cout << "Error";
                return 0;
            }
        }
    }
    if (stackTop < 0)
        cout << "Accepted";
    else
        cout << "Error";
    return 0;
}

bool isOpen(char c)
{
    if (c == '(' || c == '[' || c == '{')
        return true;
    return false;
}

bool isClose(char c)
{
    if (c == ')' || c == ']' || c == '}')
        return true;
    return false;
}

bool isPair(char c, char v) //c - open, v - close
{
    if (c == '(' && v == ')')
        return true;
    if (c == '[' && v == ']')
        return true;
    if (c == '{' && v == '}')
        return true;
    return false;
}
