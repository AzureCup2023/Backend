using Foxplore.PointsOfInterest;
using Foxplore.SerialisationWrappers.ViewpointWrapper;
using Microsoft.AspNetCore.Mvc;

namespace Foxplore.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PointsOfInterestController : ControllerBase
{
    private readonly InMemoryDatabase _context;

    public PointsOfInterestController(InMemoryDatabase context)
    {
        _context = context;
    }   
    
    [HttpGet(Name = "GetViewpoints")]
    public IEnumerable<Viewpoint> GetViewpoints()
    {
        return _context.PoIs.OfType<Viewpoint>().ToList();
    }
    
    [HttpGet(Name = "GetParks")]
    public IEnumerable<Park> GetParks()
    {
        return _context.PoIs.OfType<Park>().ToList();
    }
    
    [HttpGet(Name = "GetTechnicalFeatures")]
    public IEnumerable<TechnicalFeature> GetTechnicalFeatures()
    {
        return _context.PoIs.OfType<TechnicalFeature>().ToList();
    }
    
    [HttpGet(Name = "GetAll")]
    public IEnumerable<IPoI> GetAll()
    {
        return _context.PoIs.ToList();
    }
}