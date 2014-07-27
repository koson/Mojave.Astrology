using Mojave.Astrology.Models;

namespace Mojave.Astrology {
    public static class Points {
        public static IPoint Ascendant = new Angle(1, "Ascendant");
        public static IPoint Midheaven = new Angle(2, "Midheaven");
        public static IPoint Vertex = new Angle(3, "Vertex");
        public static IPoint EquatorialAscendant = new Angle(4, "Equatorial Ascendant");
        public static IPoint Sun = new SwissEphemerisPoint(10, "Sun", SwissEph.Positions.SE_SUN);
        public static IPoint Moon = new SwissEphemerisPoint(11, "Moon", SwissEph.Positions.SE_MOON);
        public static IPoint Mercury = new SwissEphemerisPoint(12, "Mercury", SwissEph.Positions.SE_MERCURY);
        public static IPoint Venus = new SwissEphemerisPoint(13, "Venus", SwissEph.Positions.SE_VENUS);
        public static IPoint Mars = new SwissEphemerisPoint(14, "Mars", SwissEph.Positions.SE_MARS);
        public static IPoint Jupiter = new SwissEphemerisPoint(15, "Jupiter", SwissEph.Positions.SE_JUPITER);
        public static IPoint Saturn = new SwissEphemerisPoint(16, "Saturn", SwissEph.Positions.SE_SATURN);
        public static IPoint Uranus = new SwissEphemerisPoint(17, "Uranus", SwissEph.Positions.SE_URANUS);
        public static IPoint Neptune = new SwissEphemerisPoint(18, "Neptune", SwissEph.Positions.SE_NEPTUNE);
        public static IPoint Pluto = new SwissEphemerisPoint(19, "Pluto", SwissEph.Positions.SE_PLUTO);
        public static IPoint NorthNode = new SwissEphemerisPoint(20, "North Node", SwissEph.Positions.SE_TRUE_NODE);
        public static IPoint SouthNode = new CalculatedPoint(21, "South Node", CalculatedPoints.SouthNode);
        public static IPoint Chrion = new SwissEphemerisPoint(30, "Chiron", SwissEph.Positions.SE_CHIRON);
        public static IPoint Pholus = new SwissEphemerisPoint(31, "Pholus", SwissEph.Positions.SE_PHOLUS);
        public static IPoint Ceres = new SwissEphemerisPoint(32, "Ceres", SwissEph.Positions.SE_CERES);
        public static IPoint Pallas = new SwissEphemerisPoint(33, "Pallas", SwissEph.Positions.SE_PALLAS);
        public static IPoint Juno = new SwissEphemerisPoint(34, "Juno", SwissEph.Positions.SE_JUNO);
        public static IPoint Vesta = new SwissEphemerisPoint(35, "Vesta", SwissEph.Positions.SE_VESTA);
        public static IPoint PartOfFortune = new CalculatedPoint(40, "Part of Fortune", CalculatedPoints.PartOfFotune);

        public static IPoint[] Default = {Sun, Moon, Mercury, Venus, Mars, Jupiter, Saturn, Uranus, Neptune, Pluto, NorthNode, PartOfFortune};
    }
}
