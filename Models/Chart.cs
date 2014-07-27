using System.Collections.Generic;

namespace Mojave.Astrology.Models {
    public interface IChart {
        IEnumerable<IPosition> Positions { get; set; }
        IEnumerable<ICusp> Cusps { get; set; }
        ILocaleTime LocaleTime { get; set; }
        ILocation Location { get; set; }
    }

    public class ChartBase : IChart {
        public IEnumerable<IPosition> Positions { get; set; }
        public IEnumerable<ICusp> Cusps { get; set; }
        public ILocaleTime LocaleTime { get; set; }
        public ILocation Location { get; set; }
    }
}
