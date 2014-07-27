namespace Mojave.Astrology.Models {
    internal class SpecialPoint : IPoint {
        public int Id { get; set; }
        public string Name { get; set; }

        internal SpecialPoint(int id, string name) {
            Id = id;
            Name = name;
        }
    }
}
