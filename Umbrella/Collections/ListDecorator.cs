using System.Collections;
using System.Collections.Generic;
using nVentive.Umbrella.Decorator;

namespace nVentive.Umbrella.Collections
{
    public class ListDecorator<T> : Decorator<IList<T>>, IList<T>
    {
        public ListDecorator()
            : this(new List<T>())
        {
        }

        public ListDecorator(IList<T> target)
            : base(target)
        {
        }

        #region IList<T> Members

        public virtual int IndexOf(T item)
        {
            return Target.IndexOf(item);
        }

        public virtual void Insert(int index, T item)
        {
            Target.Insert(index, item);
        }

        public virtual void RemoveAt(int index)
        {
            Target.RemoveAt(index);
        }

        public virtual T this[int index]
        {
            get { return Target[index]; }
            set { Target[index] = value; }
        }

        public virtual void Add(T item)
        {
            Target.Add(item);
        }

        public virtual void Clear()
        {
            Target.Clear();
        }

        public virtual bool Contains(T item)
        {
            return Target.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            Target.CopyTo(array, arrayIndex);
        }

        public virtual int Count
        {
            get { return Target.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return Target.IsReadOnly; }
        }

        public virtual bool Remove(T item)
        {
            return Target.Remove(item);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return Target.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}