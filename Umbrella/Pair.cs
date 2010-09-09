﻿using System;
using System.Collections.Generic;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella
{
    public interface IDataAccess
    {
    }

    public interface IDatabase
    {
    }

    public class Database : IDatabase, IDataAccess
    {
    }

    //TODO Replace with Tuple
    /// <summary>
    /// Represents a Pair of Ts.
    /// </summary>
    /// <typeparam name="T">The type of elements in this Pair.</typeparam>
    public class Pair<T>
    {
        private static readonly Func<Pair<T>, IEnumerable<object>> Fields = item => new object[] {item.X, item.Y};

        /// <summary>
        /// Constructs a new Pair.
        /// </summary>
        public Pair()
        {
        }

        /// <summary>
        /// Constructs a new Pair with it's X and Y items set.
        /// </summary>
        /// <param name="x">The X item.</param>
        /// <param name="y">The Y item.</param>
        public Pair(T x, T y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Accessor for the X item.
        /// </summary>
        public T X { get; set; }

        /// <summary>
        /// Acessor for the Y item.
        /// </summary>
        public T Y { get; set; }

        /// <summary>
        /// See Object pattern.
        /// </summary>
        public override int GetHashCode()
        {
            return this.Equality().GetHashCode(Fields);
        }

        /// <summary>
        /// See Object pattern.
        /// </summary>
        public override bool Equals(object obj)
        {
            return this.Equality().Equal(obj, Fields);
        }
    }

    public class Pair<TKey, TValue>
    {
        private static readonly Func<Pair<TKey, TValue>, IEnumerable<object>> Fields =
            item => new object[] {item.Key, item.Value};

        public Pair()
        {
        }

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public override int GetHashCode()
        {
            return this.Equality().GetHashCode(Fields);
        }

        public override bool Equals(object obj)
        {
            return this.Equality().Equal(obj, Fields);
        }
    }
}