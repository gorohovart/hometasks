#include <iostream>

using namespace std;
using namespace list;


List list::*createList()
{

}

bool isEmpty(List *list);
void add(List *list, int value);
void remove(List *list, int value);
void printList(List *list);
int get(List *list, int index);
