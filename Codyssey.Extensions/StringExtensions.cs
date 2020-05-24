using System;
using System.Collections.Generic;

namespace Codyssey.Extensions
{
    /// <summary>
    /// StringExtensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Efficiently splits the text in <c>char</c> enumerable by length.
        /// </summary>
        /// <param name="text">Text to retrieve char enumerable of <paramref name="length"/></param>
        /// <param name="length">Length to split by</param>
        /// <returns>A sequence of char enumerable that has upto the length of the character</returns>
        public static IEnumerable<IEnumerable<char>> SplitByLength(this string text, int length)
        {
            var max = text.Length;
            for (int start = 0; start < max; start += length)
            {
                yield return GetCharacters(text, start, Math.Min(start + length, max));
            }
        }

        /// <summary>
        /// Gets characters between start index and end - 1.
        /// </summary>
        /// <param name="source">String source to return characters</param>
        /// <param name="start">Start index</param>
        /// <param name="end">End index -1 to retrieve</param>
        public static IEnumerable<char> GetCharacters(this string source, int start, int end)
        {
            for (var index = start; index < end; ++index)
            {
                yield return source[index];
            }
        }
    }
}
