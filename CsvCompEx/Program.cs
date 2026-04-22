using System.Collections.Generic;
using CsvHelper;

namespace CsvCompEx
{
    public class  Program
    {
        static void Main(string[] args)
        {
            string filePath = "some-data.csv";

            List<CsvPersonData> importedRecords = CsvImporter.ImportSomeRecords(filePath);


            foreach (var record in importedRecords)
            {
                Console.WriteLine($"Record ID: {record.Id}");
                Console.WriteLine($"Name: {record.Name}");
                Console.WriteLine($"Gender: {record.Gender}");
                if (record.BirthdayYear >= 2000)
                {
                    Console.WriteLine($"Born in the 2000's : {record.BirthdayYear}");
                }
                else
                {
                    Console.WriteLine($"Born in the 90's : {record.BirthdayYear}");
                }
                Console.WriteLine($"Age : {record.Age}");
                Console.WriteLine("\n");
            }

            //Don't end
            Console.ReadKey();
        }

    }

}