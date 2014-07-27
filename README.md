Mojave.Astrology
================

A .NET abstraction of the Swiss Ephemeris

To use:

var factory = new ChartFactory();
var chart = factory.Calculate<NatalChart>(new DateTime(1990, 1, 6, 15, 4, 0), -83d, 42.5d, Points.Default);

foreach (var position in chart.Positions) {
  Console.WriteLine("{0}: {1} {2} {3}", position.Name, position.ToDegree(), position.ToSign(), position.ToSeconds());
}

foreach (var cusp in chart.Cusps) {
  Console.WriteLine("{0}: {1} {2} {3}", cusp.Name, cusp.ToDegree(), cusp.ToSign(), cusp.ToSeconds());
}
