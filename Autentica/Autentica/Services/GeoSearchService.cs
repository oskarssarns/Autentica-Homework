using Autentica.Models;
using Autentica.Services.Interfaces;
using System.Globalization;
using System.Text;

namespace Autentica.Services
{
    public class GeoSearchService : IGeoSearchService
    {
        private readonly List<Place> _apdzivotasVietas;

        public GeoSearchService()
        {
            _apdzivotasVietas = LoadApgrozijumaVietasFromFile();
        }

        private List<Place> LoadApgrozijumaVietasFromFile()
        {
            List<Place> apdzivotasVietas = new List<Place>();
            string filePath = Path.Combine("Database", "AW_VIETU_CENTROIDI.CSV");
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines.Skip(1))
            {
                string[] fields = line.Split(';');

                for (int i = 0; i < fields.Length; i++)
                {
                    fields[i] = fields[i].Trim('#');
                }

                Place vieta = new Place
                {
                    Code = fields[0],
                    TypeCode = fields[1],
                    Name = fields[2],
                    LocationCode = fields[3],
                    LocationType = fields[4],
                    Std = fields[5],
                    CoordinateX = fields[6],
                    CoordinateY = fields[7],
                    DDN = fields[8],
                    DDE = fields[9]
                };

                apdzivotasVietas.Add(vieta);
            }

            return apdzivotasVietas;
        }

        public Place GetExtremeEast()
        {
            decimal maxEast = decimal.MinValue;
            Place extremeEast = null;

            foreach (var vieta in _apdzivotasVietas)
            {
                if (decimal.TryParse(vieta.DDE, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal longitude))
                {
                    if (longitude > maxEast)
                    {
                        maxEast = longitude;
                        extremeEast = vieta;
                    }
                }
            }

            return extremeEast;
        }

        public Place GetExtremeNorth()
        {
            decimal maxNorth = decimal.MinValue;
            Place extremeNorth = null;

            foreach (var vieta in _apdzivotasVietas)
            {
                if (decimal.TryParse(vieta.DDN, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal latitude))
                {
                    if (latitude > maxNorth)
                    {
                        maxNorth = latitude;
                        extremeNorth = vieta;
                    }
                }
            }

            return extremeNorth;
        }

        public Place GetExtremeSouth()
        {
            decimal maxSouth = decimal.MaxValue;
            Place extremeSouth = null;

            foreach (var vieta in _apdzivotasVietas)
            {
                if (decimal.TryParse(vieta.DDN, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal latitude))
                {
                    if (latitude < maxSouth)
                    {
                        maxSouth = latitude;
                        extremeSouth = vieta;
                    }
                }
            }

            return extremeSouth;
        }

        public Place GetExtremeWest()
        {
            decimal maxWest = decimal.MaxValue;
            Place extremeWest = null;

            foreach (var vieta in _apdzivotasVietas)
            {
                if (decimal.TryParse(vieta.DDE, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal longitude))
                {
                    if (longitude < maxWest)
                    {
                        maxWest = longitude;
                        extremeWest = vieta;
                    }
                }
            }

            return extremeWest;
        }

        public List<Place> SearchPlaceByName(string searchQuery)
        {
            string? normalizedSearchQuery = RemoveDiacritics(searchQuery);
            List<Place> searchResults = _apdzivotasVietas
            .Where(vieta => vieta.Name != null && RemoveDiacritics(vieta.Name)
            .Contains(normalizedSearchQuery, StringComparison.OrdinalIgnoreCase))
            .Take(5)
            .ToList();

            return searchResults;
        }

        #region Helpers
        private string RemoveDiacritics(string text)
        {
            var normalizedText = text.Normalize(NormalizationForm.FormKD);
            var builder = new StringBuilder();

            foreach (var c in normalizedText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);
            }

            return builder.ToString();
        }
        #endregion
    }
}
