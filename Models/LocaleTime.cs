namespace Mojave.Astrology.Models {
    public interface ILocaleTime {
        double JulianDay { get; }
        double Longitude { get; }
        double Latitude { get; }
        int Month { get; }
        int Day { get; }
        int Year { get; }
        int Hour { get; }
        int Minute { get; }
    }

    public class LocaleTime : ILocaleTime {
        public double JulianDay { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}
