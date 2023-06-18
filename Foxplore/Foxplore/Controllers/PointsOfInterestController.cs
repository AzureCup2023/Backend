using Foxplore.PointsOfInterest;
using Foxplore.SerialisationWrappers.ViewpointWrapper;
using Microsoft.AspNetCore.Mvc;

namespace Foxplore.Controllers;

[ApiController]
[Route("[controller]")]
public class PointsOfInterestController : ControllerBase
{
    private readonly PoIContext _context;

    public PointsOfInterestController(PoIContext context)
    {
        _context = context;
    }   
    
    [HttpGet(Name = "GetViewPoints")]
    public IEnumerable<Viewpoint> GetViewpoints()
    {
        return _context.ViewPoints.ToList();
    }
    
    [HttpGet(Name = "GetParks")]
    public IEnumerable<Park> GetParks()
    {
        return _context.Parks.ToList();
    }

    // [HttpGet(Name = "GetAll")]
    // public IEnumerable<PoI> GetAll()
    // {
    //     List<PoI> result = new();
    //     result.AddRange(_context.ViewPoints);
    //     result.AddRange(_context.Parks);
    //     return result.ToList();
    // }
}