using System;
using System.Collections.Generic;

namespace nVentive.Umbrella.Collections
{
    public class ListAdapter<T, U> : CollectionAdapter<T, U>, IList<U>
    {
        public ListAdapter(IList<T> target, Func<U, T> from, Func<T, U> to)
            : base(target, from, to)
        {
        }

        protected new IList<T> Target
        {
            get { return (IList<T>) base.Target; }
        }

        #region IList<U> Members

        /// <summary>
        /// See base.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual int IndexOf(U item)
        {
            return Target.IndexOf(From(item));
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, U item)
        {
            Target.Insert(index, From(item));
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            Target.RemoveAt(index);
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public U this[int index]
        {
            get { return To(Target[index]); }
            set { Target[index] = From(value); }
        }

        #endregion
    }
}