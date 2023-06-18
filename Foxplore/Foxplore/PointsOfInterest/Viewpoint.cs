using Foxplore.SerialisationWrappers.ViewpointWrapper;
using Foxplore.Utils;

namespace Foxplore.PointsOfInterest;

public sealed class Viewpoint : PoI
{
    public Viewpoint(): base("test", 0,0, PoIType.Test)
    {
    }
    
    private Viewpoint(string name, float longitude, float latitude) 
        : base(name, longitude, latitude, PoIType.ViewPoint)
    {
    }

    public static Viewpoint FromFeature(Feature feat)
    {
        if (feat.Geometry.Type != GeometryType.Point)
        {
            throw new ArgumentException("Feature geometry must be a point");
        }

        var (lon, lat) = CoordinateConverter.JtskToWgs(feat.Geometry.Coordinates[0], feat.Geometry.Coordinates[1]);
        
        return new Viewpoint(
            feat.Properties.Nazevstanoviste,
            lon,
            lat);
    }
}