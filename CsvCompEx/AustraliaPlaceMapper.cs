using CsvHelper.Configuration;

namespace CsvCompEx
{
    public sealed class AustraliaPlaceMapper : ClassMap<AustraliaPlace>
    {
        public AustraliaPlaceMapper()
        {
            Map(m => m.Id).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.State).Index(2);
            Map(m => m.Population).Index(3);
            Map(m => m.Description).Index(4);
        }
    }
}