using System.Collections.Generic;

namespace Mojave.Astrology.Models {
    public interface IPointProvider {
        /// <summary>
        /// Priority; lower executes sooner
        /// </summary>
        int Priority { get; }

        bool Match(IPoint point);

        double Calculate(IPoint point, double julianDay, double longitude, double latitude, IEnumerable<IPosition> positions, IEnumerable<ICusp> cusps);
    }

    public interface ICuspProvider : IPointProvider {
        IEnumerable<ICusp> Cusps(double julianDay, double longitude, double latitude);
    }
}
