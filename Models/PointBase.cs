using System;
using System.Collections.Generic;

namespace Mojave.Astrology.Models {
    public abstract class PointBase : IPoint {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract double Calculate(double julianDay, double longitude, double latitude, IEnumerable<IPosition> positions, IEnumerable<ICusp> cusps);
    }

    internal class CalculatedPoint : PointBase {
        private readonly Func<double, double, double, IEnumerable<IPosition>, IEnumerable<ICusp>, double> _calculator;

        public CalculatedPoint(int id, string name, Func<double, double, double, IEnumerable<IPosition>, IEnumerable<ICusp>, double> calculator) {
            Id = id;
            Name = name;
            _calculator = calculator;
        }

        public override double Calculate(double julianDay, double longitude, double latitude, IEnumerable<IPosition> positions, IEnumerable<ICusp> cusps) {
            return _calculator.Invoke(julianDay, longitude, latitude, positions, cusps);
        }
    }
}
