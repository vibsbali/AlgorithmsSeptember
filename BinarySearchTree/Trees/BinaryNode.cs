using System;

namespace BinarySearchTree
{
    public class BinaryNode<T>
        where T : IComparable<T>
    {
        public T Value { get; }

        public BinaryNode(T value)
        {
            Value = value;
        }

        public BinaryNode<T> LeftChild { get; set; }
        public BinaryNode<T> RightChild { get; set; }

        public static bool operator <(BinaryNode<T> lhs, BinaryNode<T> rhs)
        {
            return lhs.Value.CompareTo(rhs.Value) < 0;
        }

        public static bool operator >(BinaryNode<T> lhs, BinaryNode<T> rhs)
        {
            return lhs.Value.CompareTo(rhs.Value) > 0;
        }
    }
}
