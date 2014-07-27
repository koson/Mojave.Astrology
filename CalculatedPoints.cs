using System.Collections.Generic;
using System.Linq;
using Mojave.Astrology.Models;

namespace Mojave.Astrology {
    internal static class CalculatedPoints {
        internal static double SouthNode(double julianDay, double longitude, double latitude, IEnumerable<IPosition> positions, IEnumerable<ICusp> cusps) {
            var northNode = positions.FirstOrDefault(position => position.Point == Points.NorthNode);
            double northNodePosition;
            if (northNode != null) {
                northNodePosition = northNode.Degree;
            } else {
                northNodePosition = SwissEph.Instance.Calculate(julianDay, SwissEph.Positions.SE_TRUE_NODE);
            }
            var result = northNodePosition + 180;
            if (result > 360) result -= 360;
            return result;
        }

        internal static double PartOfFotune(double julianDay, double longitude, double latitude, IEnumerable<IPosition> positions, IEnumerable<ICusp> cusps) {
            var cuspsEnumerated = cusps.ToArray();
            var ascendant = cuspsEnumerated[0];
            var descendant = cuspsEnumerated[6];

            var moon = positions.FirstOrDefault(position => position.Point == Points.Moon);
            var sun = positions.FirstOrDefault(position => position.Point == Points.Sun);

            var isDay = sun.Degree >= descendant.Degree || sun.Degree < ascendant.Degree;

            var result = isDay
                ? ascendant.Degree + moon.Degree - sun.Degree
                : ascendant.Degree + sun.Degree - moon.Degree;

            while (result > 360) result -= 360;
            while (result < 0) result += 360;
            return result;
        } 
    }
}
