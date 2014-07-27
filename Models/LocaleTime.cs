using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojave.Astrology.Models {
    public interface ILocaleTime {
        double JulianDay { get; }
        double Longitude { get; }
        double Latitude { get; }
    }

    public class LocaleTime : ILocaleTime {
        public double JulianDay { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
