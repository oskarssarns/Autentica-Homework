using Autentica.Models;
using Autentica.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Autentica.Controllers
{
    public class GeoSearchController : Controller
    {
        private readonly IGeoSearchService _geoSearchService;

        public GeoSearchController(IGeoSearchService geoSearchService)
        {
            _geoSearchService = geoSearchService;
        }

        [HttpGet("ExtremeNorth")]
        public ActionResult<Place> GetExtremeNorth()
        {
            Place extremeNorth = _geoSearchService.GetExtremeNorth();

            if (extremeNorth == null)
                return NotFound();

            return Ok(extremeNorth);
        }

        [HttpGet("ExtremeSouth")]
        public ActionResult<Place> GetExtremeSouth()
        {
            Place extremeSouth = _geoSearchService.GetExtremeSouth();

            if (extremeSouth == null)
                return NotFound();

            return Ok(extremeSouth);
        }

        [HttpGet("ExtremeWest")]
        public ActionResult<Place> GetExtremeWest()
        {
            Place extremeWest = _geoSearchService.GetExtremeWest();

            if (extremeWest == null)
                return NotFound();

            return Ok(extremeWest);
        }

        [HttpGet("ExtremeEast")]
        public ActionResult<Place> GetExtremeEast()
        {
            Place extremeEast = _geoSearchService.GetExtremeEast();

            if (extremeEast == null)
                return NotFound();

            return Ok(extremeEast);
        }

        [HttpGet("SearchPlace")]
        public ActionResult<List<Place>> SearchPlaceByName(string searchQuery)
        {
            List<Place> searchResults = _geoSearchService.SearchPlaceByName(searchQuery);

            return Ok(searchResults);
        }
    }
}
