namespace Mojave.Astrology.Models {
    internal class Angle : IPoint {
        public int Id { get; set; }
        public string Name { get; set; }

        internal Angle(int id, string name) {
            Id = id;
            Name = name;
        }
    }
}
