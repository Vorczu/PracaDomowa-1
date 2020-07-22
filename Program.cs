using PracaDomowa;
using System;

public class Program
{

    public static void Main()
	{
        var newPerson = SampleFact.CreatePerson();
        ConsolePersonInfo(newPerson);
        Console.ReadLine();
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
