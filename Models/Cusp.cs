using System;

namespace Mojave.Astrology.Models {
    public interface ICusp : IPosition {}

    public class Cusp : ICusp {
        public Cusp(int id, double degree) {
            Id = id;
            Degree = degree;
        }

        public int Id { get; set; }

        public string Name {
            get {
                if (Id == 1) {
                    return "1st House Cusp";
                }
                if (Id == 2) {
                    return "2nd House Cusp";
                }
                if (Id == 3) {
                    return "3rd House Cusp";
                }
                return String.Format("{0}th House Cusp", Id);
            }
        }

        public double Degree { get; set; }
        public IPoint Point { get; set; }
    }
}
