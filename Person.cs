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

    

    public Person()
    {


    }
    public Person(string BrithDate)
    {
        Age = AgeCalculator(DateTime.Parse(BrithDate));
    }




    public static Person PersonBuilder(Dictionary<string, string> PersonDataList)
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

    private int AgeCalculator(DateTime BirthDate)
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

    public static bool PersonDataCheck(string Textdata)
    {
        return Textdata.All(Char.IsLetter) ? true : false;
    }

    public static bool PersonDateFormat(string DateText)
    {
        try
        { DateTime.Parse(DateText, null); }
        catch (Exception)
        { return false; }

        return true;
    }

    public void ConsoleePersonInfo()
    {
        var sex = FirstName.EndsWith('a') ? "Urodziłaś" : "Urodziłeś";
        Console.WriteLine(
            $"Witaj!\n" +
            $"Twoje imię to {FirstName} a nazwisko {LastName}\n" +
            $"{sex} się w miejscowości {BirthPlace} w {BirthDate.ToString("dd.MM.yyyy") } roku i aktualnie masz {Age}");
    }
}