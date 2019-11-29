using System;

namespace Codyssey.Extensions
{
    /// <summary>
    /// Western Easter
    /// </summary>
    public class WesternEaster
    {
        public readonly DateTime EasterSunday;

        public DateTime EasterMonday => this.EasterSunday.AddDays(1);

        public DateTime GoodFriday => this.EasterSunday.AddDays(-2);

        public WesternEaster(int year)
        {
            this.EasterSunday = WesternEaster.GetEasterSunday(year);
        }

        /// <summary>
        /// Calculates Gregorian Easter Sunday and returns the value.
        /// </summary>
        /// <param name="year">Desired year</param>
        /// <returns>Easter sunday for the given year.</returns>
        /// <remarks>
        /// <para>
        /// This algorithm appears in TAOCP Volume 1 with the credit given to the following people in 16th century:
        /// Neapolitan stronomer Aloysius Lilius
        /// German Jesuit mathematician Christopher Clavius
        /// </para>
        /// <para>The algorithm is good for years after 1582</para>
        /// </remarks>
        private static DateTime GetEasterSunday(int year)
        {
            const int minYear = 1583;
            const int maxYear = 9999;
            const int yearsInCentury = 100;

            if (year < minYear || year > maxYear)
            {
                throw new ArgumentException($"Year ({year}) must be in between {minYear} and {maxYear}.", nameof(year));
            }

            var goldenNumber = (year % 19) + 1; // 19-year Metonic cycle
            var century = (year / yearsInCentury) + 1;
            var years = (3 * century / 4) - 12;
            var correction = (((8 * century) + 5) / 25) - 5; // synch with the Moon's orbit

            var sunday = ((int)(5 * year / 4)) - years - 10;
            var epact = ((11 * goldenNumber) + 20 + correction - years) % 30;

            var easterSunday = 44 - epact;
            if (easterSunday < 21) // Easter is after march 21st
            {
                easterSunday += 30;
            }

            // advance to Sunday
            easterSunday = easterSunday + 7 - (((int)(sunday + easterSunday)) % 7);
            var easterMonth = 3; // March
            if (easterSunday > 31)
            {
                easterSunday -= 31;
                easterMonth = 4; // April
            }

            return new DateTime(year, easterMonth, easterSunday);
        }
    }
}
