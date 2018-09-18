using System;

namespace LinkedList.DoublyLinkedList
{
    class SingleLinkedListNode<T>
        where T : IComparable<T>
    {
        public SingleLinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get;}
        public SingleLinkedListNode<T> Next { get; set; }
    }
}
