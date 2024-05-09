using AuctionService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers;

public class DatabaseController : ControllerBase
{
    private readonly SeedDataService _seedDataService;

    public DatabaseController(SeedDataService seedDataService)
    {
        _seedDataService = seedDataService;
    }

    [HttpGet("seed")]
    public IActionResult Seed()
    {
        _seedDataService.SeedAuctions();
        return Ok();
    }
}
