namespace Foxplore.PointsOfInterest;

public struct WGSCoordinate
{
    public float Latitude { get; }
    public float Longitude { get; }

    public WGSCoordinate(){}
    
    public WGSCoordinate(float longitude, float latitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}