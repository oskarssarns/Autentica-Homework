using Autentica.Models;
using Autentica.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Autentica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeoSearchController : Controller
    {
        private readonly IGeoSearchService _geoSearchService;

        public GeoSearchController(IGeoSearchService geoSearchService)
        {
            _geoSearchService = geoSearchService;
        }

        [HttpGet("ExtremeNorth")]
        public async Task<ActionResult<Place>> GetExtremeNorth()
        {
            Place extremeNorth = await _geoSearchService.GetExtremeNorthAsync();

            if (extremeNorth == null)
                return NotFound();

            return Ok(extremeNorth);
        }

        [HttpGet("ExtremeSouth")]
        public async Task<ActionResult<Place>> GetExtremeSouth()
        {
            Place extremeSouth = await _geoSearchService.GetExtremeSouthAsync();

            if (extremeSouth == null)
                return NotFound();

            return Ok(extremeSouth);
        }

        [HttpGet("ExtremeWest")]
        public async Task<ActionResult<Place>> GetExtremeWest()
        {
            Place extremeWest = await _geoSearchService.GetExtremeWestAsync();

            if (extremeWest == null)
                return NotFound();

            return Ok(extremeWest);
        }

        [HttpGet("ExtremeEast")]
        public async Task<ActionResult<Place>> GetExtremeEast()
        {
            Place extremeEast = await _geoSearchService.GetExtremeEastAsync();

            if (extremeEast == null)
                return NotFound();

            return Ok(extremeEast);
        }

        [HttpGet("SearchPlace")]
        public async Task<ActionResult<List<Place>>> SearchPlaceByName([Required] string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
                return BadRequest("Search query cannot be empty.");

            List<Place> searchResults = await _geoSearchService.SearchPlaceByNameAsync(searchQuery);

            return Ok(searchResults);
        }
    }
}
