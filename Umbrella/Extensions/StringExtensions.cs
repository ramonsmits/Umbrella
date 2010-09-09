// Project: Umbrella, File: StringExtensions.cs
// Namespace: nVentive.Umbrella.Extensions, Class: StringExtensions
// Path: C:\Projects - CodePlex\umbrella\Main\Src\Umbrella\Extensions, Author: stephane.lapointe
// Code lines: 89, Size of file: 3.63 KB
// Creation date: 11/11/2008 1:46 PM
// Last modified: 11/11/2008 2:14 PM
// Generated with Commenter

#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
#endregion

namespace nVentive.Umbrella.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string instance)
        {
            return string.IsNullOrEmpty(instance);
        }

        public static bool HasValue(this string instance)
        {
            return !string.IsNullOrEmpty(instance);
        }

        public static bool IsNumber(this string instance)
        {
            return instance.ToCharArray().All(Char.IsNumber);
        }

        public static bool IsDigit(this string instance)
        {
            return instance.ToCharArray().All(Char.IsDigit);
        }

        public static string JoinBy(this IEnumerable<string> items, string joinBy)
        {
            return string.Join(joinBy, items.ToArray());
        }

        public static string InvariantCultureFormat(this string instance, params object[] array)
        {
             return string.Format(CultureInfo.InvariantCulture, instance, array);
        }

        public static string CurrentCultureFormat(this string instance, params object[] array)
        {
             return string.Format(CultureInfo.CurrentCulture, instance, array);
        }

		/// <summary>
		/// Returns a string that contains a specified number of characters from the left side of a string.
		/// </summary>
		/// <param name="instance"><see cref="System.String"/> expression from which the leftmost characters are returned.</param>
		/// <param name="length"><see cref="System.Int32"/> expression. Numeric expression indicating how many characters to return.</param>
		/// <returns>If zero, a zero-length string ("") is returned. If greater than or equal to the number of characters in value, the complete string is returned.</returns>
		/// <exception cref="System.ArgumentException">length &lt; 0</exception>
		public static string Left(this string instance, int length)
		{
			return instance.LeftRightInternal(length, () => instance.Substring(0, length));
		}

		/// <summary>
		/// Returns a string containing a specified number of characters from the right side of a string.
		/// </summary>
		/// <param name="instance"><see cref="System.String"/> expression from which the rightmost characters are returned.</param>
		/// <param name="length"><see cref="System.Int32"/> expression. Numeric expression indicating how many characters to return.</param>
		/// <returns>If zero, a zero-length string ("") is returned. If greater than or equal to the number of characters in value, the complete string is returned.</returns>
		/// <exception cref="System.ArgumentException">length &lt; 0</exception>
		public static string Right(this string instance, int length)
		{
			return instance.LeftRightInternal(length, () => instance.Substring(instance.Length - length, length));
		}

		/// <summary>
		/// Returns a string that contains a specified number of characters of a string.
		/// </summary>
		/// <param name="instance"><see cref="System.String"/> expression from which the characters are returned.</param>
		/// <param name="length"><see cref="System.Int32"/> expression. Numeric expression indicating how many characters to return.</param>
		/// <param name="predicate"><see cref="Func&lt;string&gt;"/> expression that returns the substring.</param>
		private static string LeftRightInternal(this string instance, int length, Func<string> predicate)
		{
			if(length < 0)
				throw new ArgumentException("'length' must be greater than zero.", "length");

			if(instance == null || length == 0)
				return string.Empty;

			// return whole value if string length is greater or equal than length parameter, otherwise invoke the result for the value.
			return length >= instance.Length ? instance : predicate.Invoke();
		}

        /// <summary>
        /// Append a chunk at the end of a string
        /// </summary>
        /// <param name="target">target string object</param>
        /// <param name="chunk">Chunk to add</param>
        /// <returns>New string with the chunk at appended at the end.</returns>
        public static string Append(this string target, string chunk)
        {
            return target.Append(chunk, s => true);
        }

        /// <summary>
        /// Append a chunk at the end of a string only if the condition is met.
        /// </summary>
        /// <param name="target">target string object</param>
        /// <param name="chunk">Chunk to add</param>
        /// <param name="condition">Condition to meet for the chunk to be added</param>
        /// <returns>New string with the chunk at appended at the end or original string if condition is not met.</returns>
        public static string Append(this string target, string chunk, Func<string, bool> condition)
        {
            return target + (condition(target) ? chunk : "");
        }

        /// <summary>
        /// Append a chunk at the end of a string only if the string doen't end by it.
        /// </summary>
        /// <param name="target">target string object</param>
        /// <param name="chunk">Chunk to add</param>
        /// <returns>New string with the chunk at appended at the end or the original string if the target already end by chunk.</returns>
        public static string AppendIfMissing(this string target, string chunk)
        {
            return target.Append(chunk, s => !s.EndsWith(chunk));
        }

	}
}
