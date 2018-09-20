namespace StackAndQueues
{
    public class Deque<T>
    {
        private T[] BackingStorage { get; set; }
        private int InitialSize { get; set; }
        private int Head { get; set; }
        private int Tail { get; set; }

        public int Count { get; private set; }

        public Deque(int size)
        {
            if (size < 4)
            {
                size = 4;
            }

            InitialSize = size;
            BackingStorage = new T[InitialSize];

            Head = 0;
            Tail = BackingStorage.Length - 1;
        }


        public void EnqueueFirst(T value)
        {
            CheckSize();


            --Head;
            if (Head < 0)
            {
                Head = BackingStorage.Length - 1;
            }

            BackingStorage[Head] = value;
            ++Count;
        }

        public void EnqueueLast(T value)
        {
            CheckSize();

            ++Tail;
            if (Tail > BackingStorage.Length - 1)
            {
                Tail = 0;
            }

            BackingStorage[Tail] = value;
            ++Count;
        }

        public T DequeueFirst()
        {
            var itemToReturn = BackingStorage[Head++];
            if (Head > BackingStorage.Length - 1)
            {
                Head = 0;
            }

            --Count;
            CheckSize();

            return itemToReturn;
        }

        public T DequeueLast()
        {
            var itemToReturn = BackingStorage[Tail--];
            if (Tail < 0)
            {
                Tail = BackingStorage.Length - 1;
            }

            --Count;
            CheckSize();

            return itemToReturn;
        }

        public void CheckSize()
        {
            
        }

    }
}
