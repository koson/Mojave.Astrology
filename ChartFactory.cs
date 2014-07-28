using Mojave.Astrology.Extensions;
using Mojave.Astrology.Models;
using Mojave.Astrology.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mojave.Astrology {
    public interface IChartFactory {
        void SetProviders(IEnumerable<Type> providers);
        void AddProvider<TProvider>()
            where TProvider : IPointProvider, new();
        TChart Calculate<TChart>(DateTime dateTime, double longitude, double latitude, IEnumerable<IPoint> points)
            where TChart : IChart, new();
    }

    public class ChartFactory : IChartFactory {
        private readonly List<Type> _pointProviders = new List<Type> {typeof(SwissEphemerisCuspProvider), typeof(SwissEphemerisPointProvider), typeof(SupplementaryPointProvider)};

        public void AddProvider<TProvider>() where TProvider : IPointProvider, new() {
            _pointProviders.Add(typeof(TProvider));
        }

        public void SetProviders(IEnumerable<Type> providers) {
            _pointProviders.Clear();
            _pointProviders.AddRange(providers);
        }

        public virtual TChart Calculate<TChart>(DateTime dateTime, double longitude, double latitude, IEnumerable<IPoint> points)
            where TChart : IChart, new()
        {
            var julian = dateTime.ToJulianDay();

            var pointProviders = _pointProviders
                .Select(pointProvider => (IPointProvider) Activator.CreateInstance(pointProvider))
                .ToArray();

            var cuspProvider = pointProviders.OfType<ICuspProvider>().First();
            var cusps = cuspProvider.Cusps(julian, longitude, latitude).ToArray();

            return new TChart {
                Cusps = cusps,
                Positions = Positions(pointProviders, julian, longitude, latitude, cusps, points),
                LocaleTime = new LocaleTime {
                    JulianDay = julian,
                    Longitude = longitude,
                    Latitude = latitude,
                    Month = dateTime.Month,
                    Day = dateTime.Day,
                    Year = dateTime.Year,
                    Hour = dateTime.Hour,
                    Minute = dateTime.Minute
                }
            };
        }

        private Tuple<IPointProvider, IPoint> Prioritize(IPoint point, IEnumerable<IPointProvider> pointProviders) {
            var provider = pointProviders
                .OrderBy(pointProvider => pointProvider.Priority)
                .FirstOrDefault(pointProvider => pointProvider.Match(point));
            if (provider == null) {
                throw new ApplicationException(String.Format("No point provider found for point: {0} ({1})", point.Name, point.GetType().FullName));
            }
            return Tuple.Create(provider, point);
        }

        protected virtual IEnumerable<IPosition> Positions(IEnumerable<IPointProvider> pointProviders, double julian, double longitude, double latitude, IEnumerable<ICusp> cusps, IEnumerable<IPoint> points) {
            var positionCache = new List<IPosition>();
            return points
                .Select(point => Prioritize(point, pointProviders))
                .OrderBy(point => point.Item1.Priority)
                .Select(point => {
                    var position = new Position {
                        Degree = point.Item1.Calculate(point.Item2, julian, longitude, latitude, positionCache, cusps),
                        Name = point.Item2.Name,
                        Point = point.Item2
                    };
                    positionCache.Add(position);
                    return position;
                });
        }
    }
}
