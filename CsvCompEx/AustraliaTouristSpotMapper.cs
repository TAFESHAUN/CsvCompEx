using CsvHelper.Configuration;

namespace CsvCompEx
{
    public sealed class AustraliaTouristSpotMapper : ClassMap<AustraliaTouristSpot>
    {
        public AustraliaTouristSpotMapper()
        {
            Map(m => m.Id).Index(0);
            Map(m => m.Ranking).Index(1);
            Map(m => m.Name).Index(2);
            Map(m => m.State).Index(3);
            Map(m => m.Description).Index(4);
        }
    }
}