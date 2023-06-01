using Autentica.Models;

namespace Autentica.Services.Interfaces
{
    public interface IGeoSearchService
    {
        Place GetExtremeNorth();
        Place GetExtremeSouth();
        Place GetExtremeWest();
        Place GetExtremeEast();
        List<Place> SearchPlaceByName(string searchQuery);
    }
}
