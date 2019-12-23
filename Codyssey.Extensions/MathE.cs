using System;
using System.Collections.Generic;
using System.Text;

namespace Codyssey.Extensions
{
    /// <summary>
    /// Math extensions
    /// </summary>
    public static class MathE
    {
        /// <summary>
        /// Returns the value limited to the decimal count for comparison.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalCount"></param>
        /// <returns>Fixed point value</returns>
        /// <remarks>Use this to retrieve comparable values</remarks>
        public static double Floor(double value, int decimalCount)
        {
            if (decimalCount < 0 || decimalCount > 9)
            {
                throw new ArgumentException("Limit the decimal count to beteen 0 and 9", nameof(decimalCount));
            }
            var epsilon = Math.Pow(10, -decimalCount);
            return ((long)(value / epsilon)) * epsilon;
        }
    }
}
