using Foxplore.PointsOfInterest;
using Foxplore.SerialisationWrappers.ParkWrapper;
using Foxplore.SerialisationWrappers.TechnicalFeatureWrapper;
using Foxplore.SerialisationWrappers.ViewpointWrapper;
using Foxplore.Utils;
using Xunit;
using GeometryType = Foxplore.SerialisationWrappers.ParkWrapper.GeometryType;

namespace Foxplore;

public class InMemoryDatabase
{
    public List<IPoI> PoIs { get; } = new();

    public InMemoryDatabase()
    {
        PoIs.AddRange(LoadParks());
        PoIs.AddRange(LoadViewpoints());
        PoIs.AddRange(LoadTechnicalFeatures());
    }
    
    internal static IEnumerable<Park> LoadParks()
    {
        return ParkWrapper.FromJson(File.ReadAllText("Data/parks.json"))
            .Features.Where(feat => feat.Geometry.Type == GeometryType.Polygon).Select(Park.FromFeature);
    }

    internal static IEnumerable<Viewpoint> LoadViewpoints()
    {
        return ViewpointWrapper.FromJson(File.ReadAllText("Data/viewpoints.json"))
            .Features.Select(Viewpoint.FromFeature);
    }
    
    internal static IEnumerable<TechnicalFeature> LoadTechnicalFeatures()
    {
        return TechnicalFeatureWrapper.FromJson(File.ReadAllText("Data/technicalFeatures.json"))
            .Features.Select(TechnicalFeature.FromFeature);
    }
}


public class InitializerTests
{
    [Fact]
    public void TestLoadViewpoints()
    {
        var viewpoints = InMemoryDatabase.LoadViewpoints();
        Assert.Equal(245, viewpoints.Count());
    }
    
    [Fact]
    public void TestLoadParks()
    {
        var parks = InMemoryDatabase.LoadParks();
        Assert.Equal(11, parks.Count());
    }
    
    [Fact]
    public void TestLoadTechnicalFeatures()
    {
        var technicalFeatures = InMemoryDatabase.LoadTechnicalFeatures();
        Assert.Equal(5488, technicalFeatures.Count());
    }
}