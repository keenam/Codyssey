using System;
using System.Collections.Generic;

namespace Codyssey.Utils.Search
{
    /// <summary>
    /// A Bisect utility on a sorted items to find the insertion point.
    /// </summary>
    /// <remarks>
    /// Call <see cref="Right"/> to return an insertion point after existing item.
    /// Call <see cref="Left"/> to return the position of the existing item (hence replacing it)
    /// </remarks>
    public class Bisect<T>
    {
        private readonly T[] items;
        private readonly IComparer<T> comparer;
        private readonly int median;

        public Bisect(T[] items, IComparer<T> comparer)
        {
            this.items = items;
            this.comparer = comparer;
            this.median = items.Length / 2;
        }

        public int Left(T value)
        {
            var insertIndex = Array.BinarySearch(items, value, comparer);
            if (insertIndex < 0)
            {
                insertIndex = ~insertIndex;
            }
            else
            {
                for (insertIndex--; insertIndex >= 0 && comparer.Compare(value, items[insertIndex]) == 0; insertIndex--)
                    ;

                // we went left one step too far, bring back
                insertIndex++;
            }
            return insertIndex;
        }

        /// <summary>
        /// Gets the right index of the value.
        /// </summary>
        /// <param name="value">The value to compare</param>
        /// <returns>The insertion point after an existing item. 0 if it's the first.</returns>
        public int Right(T value)
        {
            var insertIndex = Array.BinarySearch(items, value, comparer);
            if (insertIndex < 0)
            {
                insertIndex = ~insertIndex;
            }
            else
            {
                for (insertIndex++; insertIndex < items.Length && comparer.Compare(value, items[insertIndex]) == 0; insertIndex++) ;
            }
            return insertIndex;
        }
    }
}
