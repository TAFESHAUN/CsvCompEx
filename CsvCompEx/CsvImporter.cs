using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using System.IO; //USING Statements Not using File BUT can use it lets add it anyway

namespace CsvCompEx
{
    /// <summary>
    /// My logic for importing csv Data using the CsvHelper library.
    /// This class will import Csv using the idea of a person MAP'd to my RAW Csv Data
    /// </summary>
    public class CsvImporter
    {
        //Import Some Records
        public static List<CsvPersonData> ImportSomeRecords(string filePath)
        {
            //List to populate with imported DATA
            List<CsvPersonData> myRecords= new List<CsvPersonData>();

            //LOGIC to Do the IMPORT and Create

            //OPEN The FILE
            using (var reader = new StreamReader(filePath))
            {
                //Use the OPEN file WITH CsvHelper
                using (var csvHelp = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    //Regist Map TO the culture info so that we can MAP that person data to the RAW CSV Data
                    csvHelp.Context.RegisterClassMap<CsvMapper>();

                    //Temps - These used to quickly populate values as they read in
                    //Check local values IF we breakpoint - LEARN but also DEBUG
                    int currentId;
                    string? currentName;
                    string? currentGender;
                    int currentBirthYear;
                    int currentAge;

                    csvHelp.Read();

                    //SKIP header
                    csvHelp.ReadHeader();//QUICK skip jump over header values

                    //Read it in and create record BUT creat will a new function
                    //While - We don't know the end of the file BUT we also scale if the file gets bigger.
                    while (csvHelp.Read())
                    {
                        //Get the current record and map it to the class
                        //Proper checks OR try catch for empty fields, null values OR wrong values, titecase
                        currentId = csvHelp.GetField<int>(0);
                        currentName = csvHelp.GetField<string>(1);
                        currentGender = csvHelp.GetField<string>(2);
                        currentBirthYear = csvHelp.GetField<int>(3);
                        currentAge = csvHelp.GetField<int>(4);

                        //Populate myRecords that that data and we are DONE
                        myRecords.Add(CreatePersonRecord(currentId,currentName,currentGender,currentBirthYear,currentAge));
                    }
                }

            }
                //Return that List
                return myRecords;
        }


        //Create Records (use inside of import) Comeback to later
        public static CsvPersonData CreatePersonRecord(int id, string name, string gender, int birthYear, int age)
        {
            CsvPersonData record = new CsvPersonData(); // Construcutor for the person data class type

            record.Id = id;
            record.Name = name;
            record.Gender = gender;
            record.BirthdayYear = birthYear;
            record.Age = age;

            return record;
            //Build on this late Maybe make this its own library for creating records from csv data
        }

    }
}
