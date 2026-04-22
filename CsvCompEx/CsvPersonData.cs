namespace CsvCompEx
{
    public class CsvPersonData
    {
        //SomeId,Name,Gender,BirthdayYear,Age
        public int Id { get; set; }
        //? this says the string can be NULL
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public int BirthdayYear { get; set; }
        public int Age { get; set; }

    }
}
