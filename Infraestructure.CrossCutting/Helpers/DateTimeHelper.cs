using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Infraestructure.CrossCutting.Helpers
{
    /// <summary>
    /// Contains extension methods for DateTime.
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Extension method to check if DateTime value is real date.
        /// </summary>
        /// <param name="dateTime">Checked value.</param>
        /// <returns>True if value is real date, false if not.</returns>
        public static bool HasMeaning(this DateTime dateTime)
        {
            return DateTime.MinValue < dateTime & dateTime < DateTime.MaxValue;
        }
    }
}
