using GeoAPI.CoordinateSystems;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using Xunit;

namespace Foxplore.Utils;

public class CoordinateConverter
{
    public static (float, float) JtskToWgs(double X, double Y)
    {
	    var coordinateSystemFactory = new CoordinateSystemFactory();
	    var gcsWGS84 = coordinateSystemFactory.CreateGeographicCoordinateSystem("WGS84 Geographic", AngularUnit.Degrees, HorizontalDatum.WGS84, PrimeMeridian.Greenwich,
		    new AxisInfo("East", AxisOrientationEnum.East), new AxisInfo("North", AxisOrientationEnum.North));
	    var ellipsoid = coordinateSystemFactory.CreateFlattenedSphere("Bessel 1840", 6377397.155, 299.15281, LinearUnit.Metre);
	    var datum = coordinateSystemFactory.CreateHorizontalDatum("Bessel 1840", DatumType.HD_Geocentric, ellipsoid, null);
	    datum.Wgs84Parameters = new Wgs84ConversionInfo(570.8, 85.7, 462.8, 4.998, 1.587, 5.261, 3.56);
	    var gcsKrovak = coordinateSystemFactory.CreateGeographicCoordinateSystem("Bessel 1840", AngularUnit.Degrees, datum,
		    PrimeMeridian.Greenwich, new AxisInfo("Lon", AxisOrientationEnum.East),
		    new AxisInfo("Lat", AxisOrientationEnum.North));
	    var parameters = new List<ProjectionParameter>(5)
	    {
		    new("latitude_of_center", 49.5),
		    new("longitude_of_center", 24.83333333333333),
		    new("azimuth", 30.28813972222222),
		    new("pseudo_standard_parallel_1", 78.5),
		    new("scale_factor", 0.9999),
		    new("false_easting", 0),
		    new("false_northing", 0)
	    };
	    var projection = coordinateSystemFactory.CreateProjection("Krovak", "Krovak", parameters);

	    
	    var coordsys = coordinateSystemFactory.CreateProjectedCoordinateSystem("Krovak", gcsKrovak, projection, LinearUnit.Metre, new AxisInfo("East", AxisOrientationEnum.East), new AxisInfo("North", AxisOrientationEnum.North));
	    var transformation = new CoordinateTransformationFactory().CreateFromCoordinateSystems(coordsys, gcsWGS84);
	    var res = transformation.MathTransform.Transform(new[] {X, Y});

        return ((float, float))(res[0], res[1]);
    }
}


public class CoordinateConverterTest
{
    [Fact]
    public void Test1()
    {
	    Assert.Equal((14.407720000000001f, 50.14760583333333f), CoordinateConverter.JtskToWgs(-742856.0600445941, -1036254.5800429061));
    }
    [Fact]
    public void Test2()
    {
	    Assert.Equal((14.426888f, 50.0939462f), CoordinateConverter.JtskToWgs(-742312.0212341584, -1042353.7385388128));
    }
}