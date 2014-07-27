using System.Collections.Generic;
using Mojave.Astrology.Models;

namespace Mojave.Astrology.Providers {
    public class SwissEphemerisPointProvider : IPointProvider {
        public int Priority { get { return 10; } }

        public bool Match(IPoint point) {
            return point is SwissEphemerisPoint;
        }

        public double Calculate(IPoint point, double julianDay, double longitude, double latitude, IEnumerable<IPosition> positions, IEnumerable<ICusp> cusps) {
            var swissPoint = point as SwissEphemerisPoint;
            return SwissEph.Instance.Calculate(julianDay, swissPoint.SwissEphemerisId);
        }
    }
}
