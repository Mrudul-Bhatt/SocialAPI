using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialAPI.Data;
using SocialAPI.Interfaces;
using SocialAPI.Models;

namespace SocialAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErrorController : Controller
{
    private readonly AppDbContext _db;

    public ErrorController(AppDbContext dbContext)
    {
        _db = dbContext;
    }

    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetSecret()
    {
        return "secret text";
    }

    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFound()
    {
        var thing = _db.AppUsers.Find(-1);
        if (thing == null) return NotFound();
        return thing;
    }

    [HttpGet("server-error")]
    public ActionResult<string> GetServerError()
    {
        var thing = _db.AppUsers.Find(-1);

        var thingToReturn = thing.ToString();

        return thingToReturn;
    }

    [HttpGet("bad-request")]
    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("This was not a good request");
    }

}