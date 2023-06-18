namespace Foxplore.PointsOfInterest;

public interface IPoI
{
    public PoIType Type { get; }
    public string Name { get; }
    public float Latitude { get; }
    public float Longitude { get; }
}