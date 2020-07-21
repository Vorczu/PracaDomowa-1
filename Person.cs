using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthPlace { get; set; }
    public int Age { get; }
    public DateTime BirthDate { get; set; }

    private static Dictionary<string, string> _personDictInfo;

    public Person()
    {


    }
    public Person(string BrithDate)
    {
        Age = AgeCalculator(DateTime.Parse(BrithDate));
    }


    public static Person ConsolePersonInit()
    {
        _personDictInfo = new Dictionary<string, string>();

        Console.WriteLine("WITAJ PODRÓZNIKU!\n");
        try
        {
            Console.Write("Podaj imię: ");
            var firstName = Console.ReadLine();
            if (PersonDataCheck(firstName))
                _personDictInfo.Add("FirstName", firstName);
            else
                throw new ArgumentException("First Name");
            Console.Clear();

            Console.Write("Podaj nazwisko: ");
            var lastName = Console.ReadLine();
            if (PersonDataCheck(lastName))
                _personDictInfo.Add("LastName", lastName);
            else
                throw new ArgumentException("Last Name");
            Console.Clear();

            Console.Write("Podaj miejsce urodzenia: ");
            var birthPlace = Console.ReadLine();
            if (PersonDataCheck(birthPlace))
                _personDictInfo.Add("Birthplace", birthPlace);
            else
                throw new ArgumentException("Birthplace");
            Console.Clear();

            Console.Write("Podaj datę urodzenia w formacie 'dd.MM.rrrr' : ");
            var birthDate = Console.ReadLine();
            if (PersonDateFormat(birthDate))
                _personDictInfo.Add("DateOfBirth", birthDate);
            else
                throw new ArgumentException("Birth Date");
            Console.Clear();
        }
        catch (ArgumentException)
        {
            Console.Clear();
            Console.WriteLine($"Błędne podane dane!");
            ConsolePersonInit();
        }
        

        return PersonBuilder(_personDictInfo);
    }

    private static Person PersonBuilder(Dictionary<string, string> PersonDataList)
    {
        // To replace || Object initialize from collection
        var firstNameIndex = PersonDataList.Single(x => x.Key == "FirstName");
        var lastNameIndex = PersonDataList.Single(x => x.Key == "LastName");
        var birthPlaceIndex = PersonDataList.Single(x => x.Key == "Birthplace");
        var birthDateIndex = PersonDataList.Single(x => x.Key == "DateOfBirth");

        var newPerson = new Person(birthDateIndex.Value)
        {
            FirstName = firstNameIndex.Value,
            LastName = lastNameIndex.Value,
            BirthPlace = birthPlaceIndex.Value,
            BirthDate = DateTime.Parse(birthDateIndex.Value)
        };
        return newPerson;
    }

private static int AgeCalculator(DateTime BirthDate)
    {
        if (BirthDate.Month <= DateTime.Now.Month)
        {
            if (BirthDate.Day <= DateTime.Now.Day)
            {
                return DateTime.Now.Year - BirthDate.Year;
            }
        }
        else
        {
            return (DateTime.Now.Year - BirthDate.Year) - 1;
        }
        return 0;
    }

    private static bool PersonDataCheck(string Textdata)
    {
        return Textdata.All(Char.IsLetter) ? true : false;
    }

    private static bool PersonDateFormat(string DateText)
    {
        try
        { DateTime.Parse(DateText, null); }
        catch (Exception)
        { return false; }

        return true;
    }

    public static void ConsoleePersonInfo(Person person)
    {
        var sex = person.FirstName.EndsWith('a') ? "Urodziłaś" : "Urodziłeś";
        Console.WriteLine(
            $"Witaj!\n" +
            $"Twoje imię to {person.FirstName} a nazwisko {person.LastName}\n" +
            $"{sex} się w miejscowości { person.BirthPlace} w { person.BirthDate.ToString("dd.MM.yyyy") } roku i aktualnie masz { person.Age}");
    }
}