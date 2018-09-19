using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArrayAkaList
{
   public class DynamicArray<T> : IList<T>
      where T : IComparable<T>
   {
      private int InitialSize { get; set; }
      private T[] BackingStore { get; set; }
      public DynamicArray(int size = 4)
      {
         InitialSize = size < 4 ? 4 : size;
         BackingStore = new T[InitialSize];
      }
      public IEnumerator<T> GetEnumerator()
      {
         for (var index = 0; index < Count; index++)
         {
            var item = BackingStore[index];
            yield return item;
         }
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }

      public void Add(T item)
      {
         CheckResize();

         BackingStore[Count++] = item;
      }

      public void CheckResize()
      {
         if (Count < InitialSize)
         {
            return;
         }

         int newLength = 0;

         if (BackingStore.Length == Count)
         {  
            newLength = BackingStore.Length * 2;
            
         } //If 2/3rd is empty
         else if (BackingStore.Length > 4 && Count <= (1/3d * BackingStore.Length))
         {
            newLength = BackingStore.Length / 2;
         }

         var temp = new T[newLength];
         Array.Copy(BackingStore, 0, temp, 0, Count);
         BackingStore = temp;
      }

      public void Clear()
      {
         BackingStore = new T[InitialSize];
      }

      public bool Contains(T value)
      {
         foreach (var item in BackingStore)
         {
            if (item.CompareTo(value) == 0)
            {
               return true;
            }
         }

         return false;
      }

      public void CopyTo(T[] array, int arrayIndex)
      {
         for (var index = 0; index < Count; index++)
         {
            var item = BackingStore[index];
            array[arrayIndex++] = item;
         }
      }

      public bool Remove(T item)
      {
         for (int i = 0; i < Count; i++)
         {
            if (BackingStore[i].CompareTo(item) == 0)
            {
               BackingStore[i] = default(T);
               Array.Copy(BackingStore, i + 1, BackingStore, i, Count - (i + 1));
               --Count;
               CheckResize();
               return true;
            }
         }

         return false;
      }

      public int Count { get; private set; }
      public bool IsReadOnly => false;
      public int IndexOf(T item)
      {
         for (int i = 0; i < Count; i++)
         {
            if (BackingStore[i].CompareTo(item) == 0)
            {
               return i;
            }
         }

         return -1;
      }

      public void Insert(int index, T item)
      {
         if (index >= Count)
         {
            throw new InvalidOperationException();
         }

         CheckResize();
         Array.Copy(BackingStore, index, BackingStore, index + 1, Count - index);
         BackingStore[index] = item;
         ++Count;
      }

      public void RemoveAt(int index)
      {
         if (index >= Count)
         {
            throw new InvalidOperationException();
         }
         
         Array.Copy(BackingStore, index + 1, BackingStore, index, Count - (index + 1));
         BackingStore[Count - 1] = default(T);
         --Count;
         CheckResize();
      }

      public T this[int index]
      {
         get
         {
            if (index >= Count)
            {
               throw new InvalidOperationException();
            }

            return BackingStore[index];
         }
         set
         {
            if (index >= Count)
            {
               throw new InvalidOperationException();
            }

            BackingStore[index] = value;
         }
      }
   }
}
