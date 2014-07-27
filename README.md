Mojave.Astrology
================

<p>A .NET abstraction of the Swiss Ephemeris.  Please see the Swiss Ephemeris for licensing information: http://www.astro.com/swisseph/</p>


<p>To use:</p>

<pre>
var factory = new ChartFactory();
var chart = factory.Calculate&lt;NatalChart&gt;(new DateTime(1990, 1, 6, 15, 4, 0), -83d, 42.5d, Points.Default);

foreach (var position in chart.Positions) {
   Console.WriteLine("{0}: {1} {2} {3}", position.Name, position.ToDegree(), position.ToSign(), position.ToSeconds());
}

foreach (var cusp in chart.Cusps) {
   Console.WriteLine("{0}: {1} {2} {3}", cusp.Name, cusp.ToDegree(), cusp.ToSign(), cusp.ToSeconds());
}
</pre>
