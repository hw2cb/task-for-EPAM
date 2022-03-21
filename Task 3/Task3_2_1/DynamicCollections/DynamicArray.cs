using DynamicCollections.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCollections
{
    public class DynamicArray<T> : IDynamicCollection<T>, IEnumerable<T>, IEnumerable, ICloneable
    {
        protected T[] _storageArray;
        public DynamicArray():this(8){ }
        public DynamicArray(int capacity)
        {
            Capacity = capacity;
            _storageArray = new T[capacity];
        }
        public DynamicArray(IEnumerable<T> collection):this(collection.Count())
        {
            AddRange(collection);
        }

        public T this[int index] { 
            get 
            { 
                if(index>Capacity) throw new ArgumentOutOfRangeException();
                //доступ с конца
                //условие на проверку выхода за границу массива при доступе с конца
                if(index < -(Length)) throw new ArgumentOutOfRangeException();
                if(index<0) return _storageArray[Length+index];
                return _storageArray[index];
            }
            set
            {
                if (index < 0 || index > Capacity) throw new ArgumentOutOfRangeException();
                _storageArray[index] = value;
            }
        }
        
        public int Length { get; protected set; }
        private int _capacity;
        public int Capacity 
        { 
            get
            {
                return _capacity;
            }
            set
            {
                if(value <0 ) throw new ArgumentException("capacity should be > 0");
                _capacity = value;
                if (Length > value)
                {
                    Length = value;
                    ChangeCapacity();
                }
            }
        }
        private void ChangeCapacity()
        {
            T[] tempArray = _storageArray;
            _storageArray = new T[_capacity];
            Array.Copy(tempArray, _storageArray, Length);
        }
        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException();
            if(Length >= Capacity)
            {
                Capacity *= 2;
                ChangeCapacity();

            }
            _storageArray[Length++] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            //использую временную переменную, так как в методе Add будет считаться Length и если просчитать Length здесь,
            //то свойство посчитается два раза. 
            int tempLength = Length + collection.Count();
            bool isBigCollection = false;
            while(tempLength >= Capacity)
            {
                Capacity *= 2;
                isBigCollection = true;
            }
            if (isBigCollection)
            {
                //если коллекция имеет много элементов, то циклом while увеличиваем в два раза Capacity
                //пока условие не выполнится, ставится флаг что цикл запускался и тогда только один раз создается нужный массив
                ChangeCapacity();
            }
            foreach(T item in collection)
            {
                Add(item);
            }
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(_storageArray, Length);
        }

        public bool Insert(int index, T item)
        {
            
            if (index < 0 || index > Capacity) throw new ArgumentOutOfRangeException();
            if(item == null) throw new ArgumentNullException();
            Length++;
            if (Capacity <= Length)
            {
                Capacity *= 2;
                //не использую метод из за появления бага когда Length == Capacity
                T[] tempArray = _storageArray;
                _storageArray = new T[_capacity];
                tempArray.CopyTo(_storageArray, 0);
            }
            while(index < Length)
            {
                T temp = _storageArray[index];
                InsertElement(index, item);
                item = temp;
                index++;
            }
            
            //не понял при каких случаях нужно возвращать false.
            return true;
        }
        private void InsertElement(int index, T item)
        {
            _storageArray[index] = item;
        }
        public bool Remove(T item)
        {
            if (item == null) throw new ArgumentNullException();
            int index = Array.IndexOf(_storageArray, item, 0, Length);
            if(index < 0) return false;

            for(int i=index; i < Length-1; i++)
            {
                _storageArray[i] = _storageArray[i + 1];
            }
            Length--;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual object Clone()
        {
            return new DynamicArray<T>(this);
        }
        public T[] ToArray()
        {
            T[] result = new T[Length];
            for(int i=0; i < Length;i++)
            {
                result[i] = _storageArray[i];
            }
            return result;
        }
    }
    internal class DynamicArrayEnumerator<T> : IEnumerator<T>
    {
        public T Current => _array[position];

        object IEnumerator.Current => Current;
        private readonly T[] _array;
        protected int position = -1;
        protected readonly int _countElement;
        public DynamicArrayEnumerator(T [] array, int countElement)
        {
            _array = array;
            _countElement = countElement;
        }
        public void Dispose()
        {
        }

        public virtual bool MoveNext()
        {
            position++;
            return position < _countElement;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
