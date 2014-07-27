using Mojave.Astrology.Models;
using System;
using System.Linq;

namespace Mojave.Astrology.Extensions {
    public static class PositionExtensions {
        public static Sign ToSign(this IPosition position) {
            var signs = Enum.GetValues(typeof(Sign))
                .Cast<Sign>()
                .OrderBy(sign => (int)sign)
                .ToArray();

            for (int i = 0; i < signs.Length; i++) {
                if (position.Degree >= (int)signs[i] && ((i + 1) >= signs.Length || position.Degree < (int)signs[i + 1])) {
                    return signs[i];
                }
            }

            throw new IndexOutOfRangeException();
        }

        public static int ToDegree(this IPosition position) {
            var sign = position.ToSign();
            var degree = position.Degree - (int) sign;
            return (int) Math.Floor(degree);
        }

        public static int ToMinutes(this IPosition position) {
            return (int) Math.Floor((position.Degree - Math.Floor(position.Degree))*60.0);
        }

        public static int ToSeconds(this IPosition position) {
            var minutes = (position.Degree - Math.Floor(position.Degree))*60.0;
            return (int)Math.Floor((minutes - Math.Floor(minutes))*60);
        }
    }
}
