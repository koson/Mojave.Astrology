using System;
using System.Data.Odbc;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Mojave.Astrology {
    internal class SwissEph : IDisposable {
        internal static readonly SwissEph Instance = new SwissEph();

        [DllImport("SwissEphemeris/swedll32.dll")]
        private static extern void swe_set_ephe_path(string path);

        [DllImport("SwissEphemeris/swedll32.dll")]
        private static extern int swe_calc_ut(double tjd_ut, int ipl,
            int iflag, double[] xx, StringBuilder serr);

        [DllImport("SwissEphemeris/swedll32.dll")]
        private static extern int swe_houses(double tjd_ut, double geolat, double geolon,
            int hsys, double[] cusps, double[] ascmc);

        [DllImport("SwissEphemeris/swedll32.dll")]
        private static extern void swe_close();

        [DllImport("SwissEphemeris/swedll64.dll", EntryPoint = "swe_set_ephe_path")]
        private static extern void swe_set_ephe_path64(string path);

        [DllImport("SwissEphemeris/swedll64.dll", EntryPoint = "swe_calc_ut")]
        private static extern int swe_calc_ut64(double tjd_ut, int ipl,
            int iflag, double[] xx, StringBuilder serr);

        [DllImport("SwissEphemeris/swedll64.dll", EntryPoint = "swe_houses")]
        private static extern int swe_houses64(double tjd_ut, double geolat, double geolon,
            int hsys, double[] cusps, double[] ascmc);

        [DllImport("SwissEphemeris/swedll64.dll", EntryPoint = "swe_close")]
        private static extern void swe_close64();


        internal SwissEph() {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "Ephemerides");
            path = path.Remove(0, path.IndexOf('\\') + 1);
            if (Environment.Is64BitProcess) {
                swe_set_ephe_path64(path);
            } else {
                swe_set_ephe_path(path);
            }
        }

        internal double Calculate(double julianDay, int position) {
            var errorMessage = new StringBuilder(256);
            var degrees = new double[6];

            if (Environment.Is64BitProcess) {
                swe_calc_ut64(julianDay, position, (int) Flags.SEFLG_SPEED | (int) Flags.SEFLG_TRUEPOS, degrees, errorMessage);
            } else {
                swe_calc_ut(julianDay, position, (int)Flags.SEFLG_SPEED | (int)Flags.SEFLG_TRUEPOS, degrees, errorMessage);                 
            }

            if (!String.IsNullOrEmpty(errorMessage.ToString()))
                throw new Exception(errorMessage.ToString());
            return degrees[0];
        }

        internal Tuple<double[], double[]> Houses(double julianDay, double longitude, double latitude) {
            var cusps = new double[13];
            var ascmc = new double[10];

            if (Environment.Is64BitProcess) {
                swe_houses64(julianDay, latitude, longitude, HouseSystems.Placidus, cusps, ascmc);
            } else {
                swe_houses(julianDay, latitude, longitude, HouseSystems.Placidus, cusps, ascmc);
            }

            return Tuple.Create(cusps, ascmc);
        }

        void IDisposable.Dispose() {
            if (Environment.Is64BitProcess) {
                swe_close64();
            } else {
                swe_close();
            }
        }

        internal static class Positions {
            public const int SE_ECL_NUT = -1;
            public const int SE_SUN = 0;
            public const int SE_MOON = 1;
            public const int SE_MERCURY = 2;
            public const int SE_VENUS = 3;
            public const int SE_MARS = 4;
            public const int SE_JUPITER = 5;
            public const int SE_SATURN = 6;
            public const int SE_URANUS = 7;
            public const int SE_NEPTUNE = 8;
            public const int SE_PLUTO = 9;
            public const int SE_MEAN_NODE = 10;
            public const int SE_TRUE_NODE = 11;
            public const int SE_MEAN_APOG = 12;
            public const int SE_OSCU_APOG = 13;
            public const int SE_EARTH = 14;
            public const int SE_CHIRON = 15;
            public const int SE_PHOLUS = 16;
            public const int SE_CERES = 17;
            public const int SE_PALLAS = 18;
            public const int SE_JUNO = 19;
            public const int SE_VESTA = 20;
            public const int SE_intP_APOG = 21;
            public const int SE_intP_PERG = 22;
            public const int SE_NPLANETS = 23;
            public const int SE_FICT_OFFSET = 40;
            public const int SE_NFICT_ELEM = 15;

            /* Hamburger or Uranian "planets" */
            public const int SE_CUPIDO = 40;
            public const int SE_HADES = 41;
            public const int SE_ZEUS = 42;
            public const int SE_KRONOS = 43;
            public const int SE_APOLLON = 44;
            public const int SE_ADMETOS = 45;
            public const int SE_VULKANUS = 46;
            public const int SE_POSEIDON = 47;

            /* other fictitious bodies */
            public const int SE_ISIS = 48;
            public const int SE_NIBIRU = 49;
            public const int SE_HARRINGTON = 50;
            public const int SE_NEPTUNE_LEVERRIER = 51;
            public const int SE_NEPTUNE_ADAMS = 52;
            public const int SE_PLUTO_LOWELL = 53;
            public const int SE_PLUTO_PICKERING = 54;
            public const int SE_AST_OFFSET = 10000;
        }

        private enum Flags {
            SEFLG_JPLEPH = 1, // use JPL ephemeris 
            SEFLG_SWIEPH = 2, // use SWISSEPH ephemeris, default
            SEFLG_MOSEPH = 4, // use Moshier ephemeris 

            SEFLG_HELCTR = 8, // return heliocentric position 
            SEFLG_TRUEPOS = 16, // return true positions, not apparent 
            SEFLG_J2000 = 32, // no precession, i.e. give J2000 equinox 
            SEFLG_NONUT = 64, // no nutation, i.e. mean equinox of date 
            SEFLG_SPEED3 = 128, // speed from 3 positions (do not use it, SEFLG_SPEED is
            // faster and preciser.) 
            SEFLG_SPEED = 256 // high precision speed (analyt. comp.)
        }

        internal static class HouseSystems {
            public static int Placidus = 'P';
            public static int Koch = 'K';
            public static int Porphyrius = 'O';
            public static int Regiomontanus = 'R';
            public static int Campanus = 'C';
            public static int Equal = 'A';
            public static int Vehlow = 'V';
            public static int Whole = 'W';
            public static int Axial = 'X';
            public static int Azimuthal = 'H';
            public static int Polich = 'T';
            public static int Alcabitus = 'B';
            public static int Morinus = 'M';
        }
    }
}
