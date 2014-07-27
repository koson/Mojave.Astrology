using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojave.Astrology.Models {

    public class ChartDescriptor {
        public string Name { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string LocationName { get; set; }
        public double UtcOffset { get; set; }
        public IEnumerable<IPoint> Points { get; set; } 
    }
}
