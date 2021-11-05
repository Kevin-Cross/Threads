using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab2
{
    public class DynamicArray<T> : IDisposable, IEnumerable<T> where T : new()
    {
        private bool _Disposed = false;
        private T[] _Items;

        public DynamicArray(int x)
        {
            Console.WriteLine($"Creating DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
            _Items = new T[x];
        }

        public DynamicArray(IEnumerable<T> items)
        {
            Console.WriteLine($"Creating DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");

            _Items = (T[])items;
            
        }
        public T this[int index]
        {
            get
            {
                return _Items[index];
            }
            set
            {
                _Items[index] = value;
            }
        }
        public void Resize(int x)
        {
            T[] items = new T[x];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new T();
            }
            for (int i = 0; i < items.Length && i < _Items.Length; i++)
            {
                items[i] = _Items[i];
            }
            _Items = items;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return (_Items as IEnumerable<T>).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Items.GetEnumerator();
        }

        public void Dispose()
        {
            Console.WriteLine($"Disposing DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed == true)
            {
                return;
            }
            if (disposing == true)
            {
                for (int i = 0; i < _Items.Length; i++)
                {
                    _Items[i] = default(T);
                }
                _Disposed = true;
                return;
            }
        }
        ~DynamicArray()
        {
            Console.WriteLine($"Finalizing DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
