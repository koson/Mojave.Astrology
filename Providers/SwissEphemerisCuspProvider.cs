using System.Linq;
using Mojave.Astrology.Models;
using System;
using System.Collections.Generic;

namespace Mojave.Astrology.Providers {
    public class SwissEphemerisCuspProvider : ICuspProvider {
        private readonly IDictionary<string, double> _positions = new Dictionary<string, double>();

        public int Priority { get { return 5; } }

        public bool Match(IPoint point) {
            return point is Angle;
        }

        public double Calculate(IPoint point, double julianDay, double longitude, double latitude, IEnumerable<IPosition> positions, IEnumerable<ICusp> cusps) {
            if (_positions.ContainsKey(point.Name)) {
                return _positions[point.Name];
            }
            throw new NotImplementedException();
        }

        public IEnumerable<ICusp> Cusps(double julianDay, double longitude, double latitude) {
            var houses = SwissEph.Instance.Houses(julianDay, longitude, latitude);

            _positions.Add(Points.Ascendant.Name, houses.Item2[0]);
            _positions.Add(Points.Midheaven.Name, houses.Item2[1]);
            _positions.Add(Points.Vertex.Name, houses.Item2[3]);
            _positions.Add(Points.EquatorialAscendant.Name, houses.Item2[4]);

            return houses.Item1.Skip(1).Take(12).Select((t, i) => new Cusp(i + 1, t));
        }
    }
}
