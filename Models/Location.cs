using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojave.Astrology.Models {
    public interface ILocation {
        string Name { get; }
        double Longitude { get; }
        double Latitude { get; }
        string TimeZone { get; }
    }

    public class Location : ILocation {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string TimeZone { get; set; }
    }
}
