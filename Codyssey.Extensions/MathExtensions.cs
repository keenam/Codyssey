﻿using System;

namespace Codyssey.Extensions
{
    /// <summary>
    /// Math extensions
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// Returns the value limited to the decimal count for comparison.
        /// </summary>
        /// <param name="value">The value to be truncated to the decimal count.</param>
        /// <param name="decimalCount">The decimal digits to truncate to.</param>
        /// <returns>Fixed point value</returns>
        /// <remarks>Use this to retrieve comparable values</remarks>
        public static double ToFixed(double value, int decimalCount)
        {
            if (decimalCount < 0 || decimalCount > 9)
            {
                throw new ArgumentException("Limit the decimal count to beteen 0 and 9", nameof(decimalCount));
            }
            var epsilon = Math.Pow(10, -decimalCount);
            return ((long)(value / epsilon)) * epsilon;
        }

        /// <summary>
        /// Returns the mid point of two values.
        /// </summary>
        public static int Mid(int x, int y)
        {
            return (x + y) >> 1;
        }
    }
}
