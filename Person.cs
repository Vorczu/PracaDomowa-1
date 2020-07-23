using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthPlace { get; set; }
    public int Age { get; }
    public DateTime BirthDate { get; set; }

    public Person(Dictionary<string, string> PersonDataList)
    {
        // To replace || Object initialize from collection
        FirstName = PersonDataList.Single(x => x.Key == "FirstName").Value.ToString();
        LastName = PersonDataList.Single(x => x.Key == "LastName").Value.ToString();
        BirthPlace = PersonDataList.Single(x => x.Key == "Birthplace").Value.ToString();
        BirthDate = DateTime.Parse(PersonDataList.Single(x => x.Key == "DateOfBirth").Value);
        Age = AgeCalculator(BirthDate);

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

}