using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCollections.Interfaces
{
    public interface IDynamicCollection<T> :IEnumerable<T>, IEnumerable
    {
        T this[int index] { get; set; }
        public int Length { get; }
        public int Capacity { get; set; }

        public void Add(T item);
        public void AddRange(IEnumerable<T> collection);
        public bool Remove(T item);
        public bool Insert(int index, T item);

    }
}
