using Microsoft.AspNetCore.Mvc;
using LunarExplorer.Data;
using LunarExplorer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Routing;
using LunarExplorer.Service;

namespace LunarExplorer.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]

    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly LuarExplorerContext _context;
    private readonly ILogger<WeatherForecastController> _logger;
 

    public WeatherForecastController(ILogger<WeatherForecastController> logger, LuarExplorerContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    // GET: Rover
    [HttpGet("rovers")]
    public async Task<ActionResult<IEnumerable<Rover>>> GetRovers()
    {
        if (_context.Rovers == null)
        {
            return NotFound();
        }
        return await _context.Rovers.ToListAsync();
    }

    [HttpGet("plateau")]
    public async Task<ActionResult<IEnumerable<Plateau>>> GetPlateaus()
    {
        if (_context.Plateaus == null)
        {
            return NotFound();
        }
        return await _context.Plateaus.ToListAsync();
    }

    [HttpGet("explore")]
    public async Task<ActionResult<IEnumerable<string>>> GetOutPut()
    {
        long di = 1;
        Plateau? plateau = await _context.Plateaus.FindAsync(di);
        List<Rover>? rovers = await _context.Rovers.ToListAsync();
        if (plateau == null)
        {
            return NotFound();
        }
        LunarExplorerService els = new LunarExplorerService(plateau, rovers );
        return els.Explore();
    }

    [HttpPost("rovers")]
    public async Task<ActionResult<Rover>> PostRover([FromBody] Rover rover)
    {
        if (_context.Rovers == null)
        {
            return Problem("Entity set 'LuarExplorerContext.Rovers'  is null.");
        }
        _context.Rovers.Add(rover);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRover", new { id = rover.Id }, rover);
    }

    [HttpPost("plateau")]
    public async Task<ActionResult<Plateau>> PostPlateau([FromBody] Plateau plateau)
    {
        if (_context.Plateaus == null)
        {
            return Problem("Entity set 'LuarExplorerContext.Plateaus'  is null.");
        }
        long di = 1;
        if(PlateauExists(di))
        {
            var p = await _context.Plateaus.FindAsync(di);
            if (p != null)
            {
                _context.Plateaus.Remove(p);
            }
           
        }
        plateau.Id = di;
        _context.Plateaus.Add(plateau);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPlateau", new { id = plateau.Id }, plateau);
    }  
    


    [HttpDelete("rovers/{id}")]
    public async Task<IActionResult> DeleteRover(long id)
    {
        if (_context.Rovers == null)
        {
            return NotFound();
        }
        var rover = await _context.Rovers.FindAsync(id);
        if (rover == null)
        {
            return NotFound();
        }

        _context.Rovers.Remove(rover);
        await _context.SaveChangesAsync();

        return NoContent();
    }



    private bool PlateauExists(long id)
    {
        return (_context.Plateaus?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}

