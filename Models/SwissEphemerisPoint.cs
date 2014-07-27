namespace Mojave.Astrology.Models {
    internal class SwissEphemerisPoint : IPoint {
        public int Id { get; set; }
        public string Name { get; set; }
        internal int SwissEphemerisId { get; set; }

        internal SwissEphemerisPoint(int id, string name, int swissEphemerisId) {
            Id = id;
            Name = name;
            SwissEphemerisId = swissEphemerisId;
        }
    }
}
