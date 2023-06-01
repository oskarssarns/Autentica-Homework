using Autentica.Models;

namespace Autentica.Services.Interfaces
{
    public interface IGeoSearchService
    {
        Task<Place> GetExtremeNorthAsync();
        Task<Place> GetExtremeSouthAsync();
        Task<Place> GetExtremeWestAsync();
        Task<Place> GetExtremeEastAsync();
        Task<List<Place>> SearchPlaceByNameAsync(string searchQuery);
    }
}
