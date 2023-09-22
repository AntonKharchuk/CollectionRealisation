using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CollectionRealisation
{
    internal class MyListEnumerator<T> : IEnumerator<T>
    {
        private IList<T> _list;
        private int _index;

        private T _current;


        internal MyListEnumerator(IList<T> list)
        {
            _list = list;
            _index = 0;

            

            if (_list.Any() is true)
            {
                _current = _list[_index];
            }
            else
            {
                _current = default!;
            }
        }
        public T Current => _current;

        object IEnumerator.Current => _current!;

        public bool MoveNext()
        {
            if (_index<_list.Count)
            {
                _current = _list[_index];
                _index ++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _index = 0;
            _current = _list[0];
        }

        public void Dispose()
        {

        }
    }
}
