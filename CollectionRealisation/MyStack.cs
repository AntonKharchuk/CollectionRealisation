using System;
using System.Collections;

namespace CollectionRealisation
{
    public class MyStack<T>: IEnumerable<T>, ICollection 
    {
        //use this capacity with ctor()
        private const int DefaultCapacity = 4;

        //the arr, where data is stored
        private T[] _items;

        //num of elements is allredy set to _items 
        private int _size;

        public event Action<T> Pushed;
        public event Action<T> Popped;
        public event Action Cleared;

        //reference to ctor with int param and pass default capacity
        public MyStack() : this(DefaultCapacity)
        {

        }

        //set _capacity, _size and create arr with user's capacity
        public MyStack(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
            _size = 0;
            Cleared?.Invoke();
        }

        public int Count => _size;

        public bool IsReadOnly => false;

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        public void Clear()
        {
            Array.Clear(_items, 0, _size);
            _size = 0;
        }

        //go through items and search for match
        public bool Contains(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_items[i] is not null && _items[i]!.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyStackEnumerator(this);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MyStackEnumerator(this);
        }

        //get top element of the stack
        public T Peek()
        {
            if (_size>0)
            {
                return _items[_size - 1];
            }
            throw new InvalidOperationException("EmptyStack");
        }

        //get top element of the stack and remove it from the stack
        public T Pop()
        {
            if (_size > 0)
            {
                _size--;
                var result = _items[_size];
                _items[_size] = default(T)!;

                Popped?.Invoke(result);

                return result;
            }
            throw new InvalidOperationException("EmptyStack");
        }

        //Push element to the top of the stack 
        public void Push(T item)
        {
            if (_size+1>_items.Length)
            {
                Resize();
            }

            _items[_size] = item;
            _size++;
            Pushed?.Invoke(item);
        }


        private void Resize()
        {
            var newCapacity = _items.Length *2; //  double the capacity
            var newArray = new T[newCapacity]; // create arr with new capacity
            Array.Copy(_items, newArray, _size);
            _items = newArray;
        }

        public override string ToString()
        {
            return string.Format("Count = {0}", _size);
        }

        //copy data form this list to user's array starting from index
        public void CopyTo(Array array, int index)
        {
            ArgumentNullException.ThrowIfNull(array);

            if (array is not null && array.Rank is not 1)
            {
                throw new InvalidDataException("Arr rank is not 1");
            }
            try
            {
                Array.Copy(_items, 0, array!, index, _size);
                Array.Reverse(array!, index, _size);
            }
            catch (ArrayTypeMismatchException)
            {
                throw new ArgumentException(nameof(array));
            }
        }
        public void CopyTo(T[] array, int index)
        {
            ArgumentNullException.ThrowIfNull(array);

            if (array is not null && array.Rank is not 1)
            {
                throw new InvalidDataException("Arr rank is not 1");
            }
            int srcIndex = 0;
            int dstIndex = index + _size;
            while (srcIndex < _size)
            {
                array![--dstIndex] = _items[srcIndex++];
            }
        }

        public class MyStackEnumerator : IEnumerator<T>
        {
            private MyStack<T> _stack;
            private int _index;

            private T _current;

            internal MyStackEnumerator(MyStack<T> stack)
            {
                _stack = stack;
                _index = stack.Count - 1;

                _current = default(T)!;
            }
        

            public T Current => _current;


            object IEnumerator.Current => _current!;

            public bool MoveNext()
            {
                if (_index >= 0)
                {
                    _current = _stack._items[_index];
                    _index--;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _index = _stack.Count - 1;
                _current = default!;
            }

            public void Dispose()
            {

            }
        }
    }
}
