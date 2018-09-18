using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.DoublyLinkedList
{
    public class DoublyLinkedListNode<T>
        where T : IComparable<T>
    {
        public T Value { get; set; }
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }

        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }
    }
}
