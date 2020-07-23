using PracaDomowa;
using System;
using System.Collections.Generic;

public class Program
{
    private static Dictionary<string, string> _personDictInfo;

    public static void Main()
    {

        _personDictInfo = new Dictionary<string, string>();

        Console.WriteLine("WITAJ PODRÓZNIKU!\n");
        try
        {
            Console.Write("Podaj imię: ");
            var firstName = Console.ReadLine();
            if (Person.PersonDataCheck(firstName))
                _personDictInfo.Add("FirstName", firstName);
            else
                throw new ArgumentException("First Name");
            Console.Clear();

            Console.Write("Podaj nazwisko: ");
            var lastName = Console.ReadLine();
            if (Person.PersonDataCheck(lastName))
                _personDictInfo.Add("LastName", lastName);
            else
                throw new ArgumentException("Last Name");
            Console.Clear();

            Console.Write("Podaj miejsce urodzenia: ");
            var birthPlace = Console.ReadLine();
            if (Person.PersonDataCheck(birthPlace))
                _personDictInfo.Add("Birthplace", birthPlace);
            else
                throw new ArgumentException("Birthplace");
            Console.Clear();

            Console.Write("Podaj datę urodzenia w formacie 'dd.MM.rrrr' : ");
            var birthDate = Console.ReadLine();
            if (Person.PersonDateFormat(birthDate))
                _personDictInfo.Add("DateOfBirth", birthDate);
            else
                throw new ArgumentException("Birth Date");
            Console.Clear();
        }
        catch (ArgumentException)
        {
            Console.Clear();
            Console.WriteLine($"Błędne podane dane!");
        }

        var newPerson = new Person(_personDictInfo);
        ConsolePersonInfo(newPerson);
    }


    private static void ConsolePersonInfo(Person person)
    {
        var sex = person.FirstName.EndsWith('a') ? "Urodziłaś" : "Urodziłeś";
        Console.WriteLine(
            $"Witaj!\n" +
            $"Twoje imię to {person.FirstName} a nazwisko {person.LastName}\n" +
            $"{sex} się w miejscowości {person.BirthPlace} w {person.BirthDate.ToString("dd.MM.yyyy") } roku i aktualnie masz {person.Age}");
    }
}
