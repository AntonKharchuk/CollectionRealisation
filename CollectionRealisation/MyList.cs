using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CollectionRealisation
{
    public class MyList<T> : IList<T> , ICollection<T> 
    {
        //List

        //use this capacity with ctor()
        private const int DefaultCapacity = 4;

        //_items.Length
        private int _capacity;   

        //the arr, where data is stored
        private T[] _items;

        //num of elements is allredy set to _items 
        private int _size;
        
        //reference to ctor with int param and pass default capacity
        public MyList():this(DefaultCapacity)
        {
            
        }

        //set _capacity, _size and create arr with user's capacity
        public MyList(int capacity)
        {
            _capacity = capacity;
            _items = new T[_capacity];
            _size = 0;
        }

        //override the [] to referance to the item by index
        public T this[int index]
        {
            get {
                //check if index is valid
                if (!IndexIsBetweenZeroAndSize(index))
                {
                    throw new IndexOutOfRangeException();
                } 
                return _items[index]; }
            set { _items[index] = value;}
        }

        public int Count => _size;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            //check if overflow the arr capacity

            if (_size >= _capacity)
            {
                this.Resize();
            }
            _items[_size] = item;
            _size = _size + 1;
        }
        //set num of items to 0, create new T[] size of capacity
        public void Clear()
        {
            _size = 0;
            _items = new T[_capacity];
        }

        //go through items and search for match
        public bool Contains(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_items[i]is not null && _items[i]!.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        //copy data form this list to user's array starting from arrayIndex
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is not null && array.Rank is not 1)
            {
                throw  new InvalidDataException("Arr rank is not 1");
            }
            Array.Copy(_items, 0, array!, arrayIndex, _size);
        }


        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item);
        }

        //Insert item to the list and push items with bigger indexes to the tail end
        public void Insert(int index, T item)
        {
            if (index<0||index>_size+1)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (index == _size+1)
            {
                this.Add(item);
            }
            else
            {
                if (_size==_capacity)
                {
                    Resize();
                }
                Array.Copy(_items, index, _items, index+1, _size-index);

                _items[index] = item;
                
                _size++;

            }
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index>=0)
            {
                this.RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (!IndexIsBetweenZeroAndSize(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = default!;
            _size--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(this);
        }
        private bool IndexIsBetweenZeroAndSize(int index) => index >= 0 && index < _size;

        private void Resize()
        {
            _capacity *= 2; //  double the capacity
            var newArray = new T[_capacity]; // create arr with new capacity
            Array.Copy(_items, newArray, _size);
            _items = newArray;
        }

        public override string ToString()
        {
            return string.Format("Count = {0}", _size); 
        }

    }
}
