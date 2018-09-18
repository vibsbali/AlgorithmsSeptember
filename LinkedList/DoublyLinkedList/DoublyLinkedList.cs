using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : ICollection<T>
        where T : IComparable<T>
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }
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
            var nodeToAdd = new DoublyLinkedListNode<T>(item);
            if (Tail == null)
            {
                Head = Tail = nodeToAdd;
            }
            else
            {
                Tail.Next = nodeToAdd;
                nodeToAdd.Previous = Tail;

                Tail = nodeToAdd;
            }

            ++Count;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
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
            var current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    //are we at head
                    if (current.Previous == null)
                    {
                        //is head and tail same
                        if (current.Next == null)
                        {
                            Clear();
                            return true;
                        }

                        Head = current;
                        Head.Previous = null;
                    }
                    // are we at tail
                    else if (current.Next == null)
                    {
                        Tail = current.Previous;
                        Tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }

                    --Count;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
