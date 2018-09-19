using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        internal BinaryNode<T> Root { get; set; }

        public void Add(T value)
        {
            var nodeToAdd = new BinaryNode<T>(value);

            if (Root == null)
            {
                Root = nodeToAdd;
            }
            else
            {
                var current = Root;
                while (current != null)
                {
                    if (nodeToAdd < current)
                    {
                        if (current.LeftChild == null)
                        {
                            current.LeftChild = nodeToAdd;
                            break;
                        }

                        current = current.LeftChild;
                    }
                    else
                    {
                        if (current.RightChild == null)
                        {
                            current.RightChild = nodeToAdd;
                            break;
                        }

                        current = current.RightChild;
                    }
                }
            }

            ++Count;
        }

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            var itemsToReturn = new Queue<T>(Count);
            var auxQueue = new Queue<BinaryNode<T>>(Count);

            auxQueue.Enqueue(Root);
            while (auxQueue.Count > 0)
            {
                var current = auxQueue.Dequeue();
                if (current != null)
                {
                    itemsToReturn.Enqueue(current.Value);

                    auxQueue.Enqueue(current.LeftChild);
                    auxQueue.Enqueue(current.RightChild);
                }
            }

            yield return itemsToReturn.Dequeue();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void InOrderTraversal(Action<T> actionToPerform)
        {
            RecursivelyInOrder(Root, actionToPerform);
        }

        private void RecursivelyInOrder(BinaryNode<T> current, Action<T> actionToPerform)
        {
            if (current != null)
            {
                RecursivelyInOrder(current.LeftChild, actionToPerform);
                actionToPerform(current.Value);
                RecursivelyInOrder(current.RightChild, actionToPerform);
            }
        }

        public void PreOrderTraversal(Action<T> actionToPerform)
        {
            RecursivelyPreOrder(Root, actionToPerform);
        }

        private void RecursivelyPreOrder(BinaryNode<T> current, Action<T> actionToPerform)
        {
            if (current != null)
            {
                actionToPerform(current.Value);
                RecursivelyPreOrder(current.LeftChild, actionToPerform);
                RecursivelyPreOrder(current.RightChild, actionToPerform);
            }
        }

        public void PostOrderTraversal(Action<T> actionToPerform)
        {
            RecursivelyPostOrder(Root, actionToPerform);
        }

        private void RecursivelyPostOrder(BinaryNode<T> current, Action<T> actionToPerform)
        {
            if (current != null)
            {
                RecursivelyPostOrder(current.LeftChild, actionToPerform);
                RecursivelyPostOrder(current.RightChild, actionToPerform);
                actionToPerform(current.Value);
            }
        }

        public bool Contains(T value)
        {
            var current = Root;

            while (current != null)
            {
                if (current.Value.CompareTo(value) == 0)
                {
                    return true;
                }

                if (current.Value.CompareTo(value) > 0)
                {
                    current = current.LeftChild;
                }
                else
                {
                    current = current.RightChild;
                }
            }

            return false;
        }

        public bool Remove(T value)
        {
            var current = Root;
            BinaryNode<T> parent = null;

            while (current != null)
            {
                //Found it
                if (current.Value.CompareTo(value) == 0)
                {
                    //We are at root
                    if (parent == null)
                    {
                        if (current.LeftChild == null && current.RightChild == null)
                        {
                            Root = null;
                        }
                    }
                    else
                    {
                        // No left or right child

                        // Has Left but no right

                        // Has Right but that right has no left

                        // Has Right and that right has left child
                    }

                    --Count;
                    return true;
                }
                else
                {
                    //Otherwise
                    parent = current;
                    if (current.Value.CompareTo(value) < 0)
                    {
                        current = current.RightChild;
                    }
                    else if (current.Value.CompareTo(value) > 0)
                    {
                        current = current.LeftChild;
                    }
                }
            }

            return false;
        }
    }
}
