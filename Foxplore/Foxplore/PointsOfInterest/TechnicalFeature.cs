using Foxplore.SerialisationWrappers.TechnicalFeatureWrapper;
using Foxplore.Utils;

namespace Foxplore.PointsOfInterest;

public class TechnicalFeature : PoI
{
    public TechnicalFeature(string name, float longitude, float latitude) 
        : base(name, longitude, latitude, PoIType.TechnicalFeature)
    {
    }
    
    public static TechnicalFeature FromFeature(Feature feat)
    {
        if (feat.Geometry.Type != GeometryType.Point)
        {
            throw new ArgumentException("Feature geometry must be a point");
        }

        var (lon, lat) = CoordinateConverter.JtskToWgs(feat.Geometry.Coordinates[0], feat.Geometry.Coordinates[1]);
        
        return new TechnicalFeature(
            "Technická památka",
            lon,
            lat);
    }
}