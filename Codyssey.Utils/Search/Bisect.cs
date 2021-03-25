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
            return this.GetInsertIndex(value, 0, this.items.Length - 1, this.median, InsertPosition.Before);
        }

        /// <summary>
        /// Gets the right index of the value.
        /// </summary>
        /// <param name="value">The value to compare</param>
        /// <returns>The insertion point after an existing item. 0 if it's the first.</returns>
        public int Right(T value)
        {
            return this.GetInsertIndex(value, 0, this.items.Length - 1, this.median, InsertPosition.After);
        }

        private int GetInsertIndex(T value, int left, int right, int compareIndex, InsertPosition insertAt)
        {
            if (compareIndex > right)
            {
                // insert last
                return right + 1;
            }

            if (compareIndex < left)
            {
                // insert first
                return left;
            }

            var result = comparer.Compare(this.items[compareIndex], value);
            if (insertAt == InsertPosition.After && result == 0 || result < 0)
            {
                // find the bigger number than current
                return this.GetInsertIndex(value, compareIndex + 1, right, compareIndex + (right - compareIndex) / 2 + 1, insertAt);
            }

            // the value is less than current item
            return this.GetInsertIndex(value, left, compareIndex - 1, compareIndex - (compareIndex - left) / 2 - 1, insertAt);
        }

        enum InsertPosition
        {
            Before,
            After
        }
    }
}
