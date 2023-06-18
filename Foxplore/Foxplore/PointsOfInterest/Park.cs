using Foxplore.SerialisationWrappers.ParkWrapper;
using CoordinateConverter = Foxplore.Utils.CoordinateConverter;

namespace Foxplore.PointsOfInterest;

public sealed class Park : PoI
{
    public WGSCoordinate[] Coordinates;

    private Park(string name, float longitude, float latitude, WGSCoordinate[] coordinates) 
        : base(name, longitude, latitude, PoIType.Park)
    {
        Coordinates = coordinates;
    }
    
    public static Park FromFeature(Feature feat)
    {
        var coordinates = GetWGSCoordinates(feat.Geometry.Coordinates);
        var (longitude, latitude) = GetCenter(coordinates);
        
        return new Park(
            feat.Properties.Nazev,
            longitude,
            latitude,
            coordinates);
    }

    private static (float longitude, float latitude) GetCenter(WGSCoordinate[] coordinates)
    {
        var longitude = coordinates.Average(c => c.Longitude);
        var latitude = coordinates.Average(c => c.Latitude);
        return (longitude, latitude);
    }

    private static WGSCoordinate[] GetWGSCoordinates(Coordinate[][][] geometryCoordinates)
    {
        return geometryCoordinates.First()
            .Where(coordinate => coordinate.Length == 2)
            .Select(coordinate =>
            {
                var (lon, lat) = CoordinateConverter.JtskToWgs(coordinate[0].Double ?? 0d, coordinate[1].Double ?? 0d);
                return  new WGSCoordinate(lon, lat);
            })
            .ToArray();
    }
}