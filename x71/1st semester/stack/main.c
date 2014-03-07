#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "stack.h"


void doOperation(Stack *nums, char x)
{
    int a = 0;
    int b = 0;
    if (stack_size(nums) < 2)
    {
        printf("\nError. StackSize < 2\n");
        return;
    }

    b = stack_pop(nums);
    a = stack_pop(nums);

    switch (x)
    {
        case '+':
            stack_push(nums, a + b);
            break;
        case '-':
            stack_push(nums, a - b);
            break;
        case '*':
            stack_push(nums, a * b);
            break;
        case '/':
            if (b == 0)
            {
                printf("\nError. Division by zero.\n");
                stack_push(nums, a);
                stack_push(nums, b);
                return;
            }
            stack_push(nums, a / b);
            break;
    }

}

void calculator()
{
    Stack* numbers = stack_create();

    printf("Input one of the commands:\nNumber\nOperation(+,-,*,/)\n'pop'\n'dup'\n'exit'\n");

    while (1)
    {
        char command[20];
        fgets(command, 20, stdin);

        if ('0' <= command[0] && command[0] <= '9')
        {
            int n = 0;
            sscanf(command, "%d", &n);
            
            stack_push(numbers, n);
        }
        else if (strlen(command) < 3)  //(+,-,*,/)
        {
            doOperation(numbers, command[0]);
        }
        else if (command[0] == 'p')     //pop
        {
            if (stack_isEmpty(numbers))
            {
                printf("\nError. Stack is empty.\n");
                return;
            }
            printf("%d", stack_pop(numbers));
        }
        else if (command[0] == 'd')     //dup
        {
            numbers->top->value *= 2;
        }
        else if (command[0] == 'e')     //exit
        {
            return;
        }
    }

}

int main()
{
    calculator();
    return 0;
}
