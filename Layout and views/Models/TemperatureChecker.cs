using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout_and_views.Models
{
    public static class TemperatureChecker
    {
        public static bool HasFever(float degrees, string unit)
        {
            ValidUnit(unit);
            return (degrees >= (unit == "Celsius" ? 37.5 : 99.5));
        }

        public static bool HasHypothermia(float degrees, string unit)
        {
            ValidUnit(unit);
            return (degrees <= (unit == "Celsius" ? 35.0 : 95.0));
        }

        private static void ValidUnit(string unit)
        {
            if (!(unit == "Celsius" || unit == "Fahrenheit"))
                throw (new ArgumentException("Faulty unit"));
        }

    }
}