using Foxplore.PointsOfInterest;
using Foxplore.SerialisationWrappers.ParkWrapper;
using Foxplore.SerialisationWrappers.TechnicalFeatureWrapper;
using Foxplore.SerialisationWrappers.ViewpointWrapper;
using Microsoft.EntityFrameworkCore;
using Xunit;
using GeometryType = Foxplore.SerialisationWrappers.ParkWrapper.GeometryType;

namespace Foxplore.Utils;

public static class DbInitializer
{
    public static void Initialize(PoIContext context)
    {
        context.Database.EnsureCreated();

        if (context.ViewPoints.Any())
            return; // already seeded
        
        //read viewpoints.json
        var viewpoints = LoadViewpoints();
        foreach (var view in viewpoints)
        {
            context.ViewPoints.Add(view);
        }

        //read parks.json
        var parks = LoadParks();
        foreach (var park in parks)
        {
            context.Parks.Add(park);
        }

        var technicalFeatures = LoadTechnicalFeatures();
        foreach (var technicalFeature in technicalFeatures)
        {
            context.TechnicalFeatures.Add(technicalFeature);
        }
        
        context.SaveChanges();
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
        var viewpoints = DbInitializer.LoadViewpoints();
        Assert.Equal(245, viewpoints.Count());
    }
    
    [Fact]
    public void TestLoadParks()
    {
        var parks = DbInitializer.LoadParks();
        Assert.Equal(11, parks.Count());
    }
}