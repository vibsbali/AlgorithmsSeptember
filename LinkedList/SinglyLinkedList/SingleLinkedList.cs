using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LinkedList.DoublyLinkedList;

namespace LinkedList.SinglyLinkedList
{
    public class SingleLinkedList<T> : ICollection<T>
        where T : IComparable<T>
    {
        private SingleLinkedListNode<T> Head { get; set; }
        private SingleLinkedListNode<T> Tail { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            var nodeToAdd = new SingleLinkedListNode<T>(item);

            if (Head == null)
            {
                Head = Tail = nodeToAdd;
            }
            else
            {
                Tail.Next = nodeToAdd;
                Tail = nodeToAdd;
            }

            ++Count;

        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; }
    }
}
