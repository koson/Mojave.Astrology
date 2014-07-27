namespace Mojave.Astrology.Models {
    public interface IPosition {
        string Name { get; }
        double Degree { get; }
        IPoint Point { get; }
    }

    public class Position : IPosition {
        public string Name { get; set; }
        public double Degree { get; set; }
        public IPoint Point { get; set; }
    }
}
