#include <stdio.h>
#include <stdlib.h>
#include "stack.h"

Stack* stack_create()
{
    Stack *newStack = (Stack*) malloc (sizeof(Stack));

    newStack->top =  NULL;
    return newStack;
}

void stack_push(Stack *c, int val)
{
    StackElement *newElement = (StackElement*) malloc (sizeof(StackElement));
    newElement->value = val;
    newElement->next = c->top;
    c->top = newElement;
}

int stack_size(Stack *c)
{
    int i = 0;
    StackElement *ptr = c->top;
    
    while (ptr != NULL)
    {
        ptr = ptr->next;
        i++;
    }
    
    return i;
}

int stack_pop(Stack *c)
{
    int rez = c->top->value;
    StackElement *ptr = c->top;
    c->top = c->top->next;
    
    free(ptr);
    return rez; 
}

int stack_back(Stack *c)
{
    return c->top->value;
}

int stack_isEmpty(Stack *c)
{
    if (c->top == NULL)
    {
        return 1;
    }
    else
    {
        return 0;
    }
}