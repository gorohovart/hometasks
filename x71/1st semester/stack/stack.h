#pragma once

typedef struct StackElement
{
    struct StackElement *next;
    int value;
} StackElement;

typedef struct Stack
{
    StackElement *top;
} Stack;

Stack* stack_create();
void stack_push(Stack *, int);
int stack_size(Stack *);
int stack_pop(Stack *);
int stack_back(Stack *);
int stack_isEmpty(Stack *);