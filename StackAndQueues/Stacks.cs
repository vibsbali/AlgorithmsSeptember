using System;

namespace StackAndQueues
{
   public class Stacks<T>
   {
      public Stacks(int initialSize = 4)
      {
         if (initialSize < 4)
         {
            InitialSize = 4;
         }

         BackingStore = new T[InitialSize];
      }

      public void Push(T item)
      {
         CheckResize();
         BackingStore[Count++] = item;
      }

      public T Pop()
      {
         if (Count == 0)
         {
            throw new InvalidOperationException();
         }

         var itemToReturn = BackingStore[--Count];
         CheckResize();
         return itemToReturn;
      }

      public T Peek()
      {
         if (Count > 0)
         {
            return BackingStore[Count - 1];
         }

         return default(T);
      }

      public bool TryPop(out T value)
      {
         value = default(T);
         if (Count == 0)
         {
            return false;
         }

         value = BackingStore[--Count];
         CheckResize();
         return true;
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
         else if (BackingStore.Length > 4 && Count <= (1 / 3d * BackingStore.Length))
         {
            newLength = BackingStore.Length / 2;
         }

         var temp = new T[newLength];
         Array.Copy(BackingStore, 0, temp, 0, Count);
         BackingStore = temp;
      }

      public int Count { get; private set; }

      private T[] BackingStore { get; set; }

      public int InitialSize { get; set; }
   }
}
