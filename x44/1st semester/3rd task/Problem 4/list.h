#pragma once

namespace list
{
    struct ListElement
    {
        int value;
        ListElement *next;
    };

    struct List
    {
        ListElement *first;
    };

    List *createList();
    bool isEmpty(List *list);
    void add(List *list, int value);
    void remove(List *list, int value);
    void printList(List *list);
    int get(List *list, int index);
};
