﻿using System;
using System.Collections;
using System.Collections.Generic;
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
            var current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            SingleLinkedListNode<T> previous = null;
            var current = Head;
            while (current != null)
            {
                //We have a match
                if (current.Value.CompareTo(item) == 0)
                {
                    //We are at head
                    if (previous == null)
                    {
                        //We are at tail too i.e. only one item in list
                        if (current.Next == null)
                        {
                            Clear();
                            return true;
                        }

                        Head = null;
                        Head = current.Next;
                    }
                    //We are not at head
                    else
                    {
                        //We have found tail
                        if (current.Next == null)
                        {
                            current = Tail = null;
                            Tail = previous;
                        }
                        else
                        {
                            previous.Next = current.Next;
                        }
                    }

                    --Count;
                    return true;
                }


                previous = current;
                current = current.Next;
            }

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
