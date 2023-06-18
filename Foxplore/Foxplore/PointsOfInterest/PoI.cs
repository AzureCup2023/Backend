namespace Foxplore.PointsOfInterest;

public abstract class PoI : IPoI
{
    public PoIType Type { get; }
    public string Name { get; }
    public float Latitude { get; }
    public float Longitude { get; }
    
    protected PoI(string name, float longitude, float latitude, PoIType type)
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
        Type = type;
    }
}