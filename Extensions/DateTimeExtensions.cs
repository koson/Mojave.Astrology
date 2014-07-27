using System;

namespace Mojave.Astrology.Extensions {
    public static class DateTimeExtensions {
        public static double ToJulianDay(this DateTime dateTime) {
            return dateTime.ToOADate() + 2415018.5;
        }
    }
}
