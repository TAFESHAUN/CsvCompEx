//Mapper class with CSVHelper
using CsvHelper.Configuration;

namespace CsvCompEx
{
    public sealed class CsvMapper: ClassMap<CsvPersonData>
    {
        public CsvMapper() 
        {
            Map(m => m.Id).Index(0); //Col 0 Is always ID
            Map(m => m.Name).Index(1);
            Map(m => m.Gender).Index(2);
            Map(m => m.BirthdayYear).Index(3);
            Map(m => m.Age).Index(4);
        }
    }
}
