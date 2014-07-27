using Mojave.Astrology.Models;
using System.Collections.Generic;

namespace Mojave.Astrology.Providers {
    public class SupplementaryPointProvider : IPointProvider {
        public int Priority { get { return 20; } }

        public bool Match(IPoint point) {
            return point is PointBase;
        }

        public double Calculate(IPoint point, double julianDay, double longitude, double latitude, IEnumerable<IPosition> positions, IEnumerable<ICusp> cusps) {
            var pointBase = point as PointBase;
            return pointBase.Calculate(julianDay, longitude, latitude, positions, cusps);
        }
    }
}
