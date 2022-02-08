using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCollections
{
    public sealed class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : this(8) { }
        public CycledDynamicArray(int capacity):base(capacity)
        {
        }
        public CycledDynamicArray(IEnumerable<T> collection) : this(collection.Count())
        {
            AddRange(collection);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(_storageArray, Length);
        }
    }
    internal sealed class CycledDynamicArrayEnumerator<T> : DynamicArrayEnumerator<T>
    {
        public CycledDynamicArrayEnumerator(T[] array, int countElement) : base(array, countElement)
        {
        }
        public override bool MoveNext()
        {
            position++;
            if (position == _countElement)
                position = 0;
            return true;
        }

    }
}
