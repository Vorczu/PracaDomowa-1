using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

public class Person
{
    public string _firstName { get; set; }
    public string _lastName { get; set; }
    public string _birthPlace { get; set; }
    public int _age { get; }
    public DateTime _birthDate { get; set; }

    public Person(DateTime BrithDate)
    {
        _age = AgeCalculator(BrithDate);
    }

    public static Person PersonBuilder()
    {

        Console.WriteLine("WITAJ PODRÓZNIKU!\n");
        Console.Write("Podaj imię: ");
        var firstName = PersonStringDataCheck(Console.ReadLine());
        Console.Clear();

        Console.Write("Podaj nazwisko: ");
        var lastName = PersonStringDataCheck(Console.ReadLine());
        Console.Clear();

        Console.Write("Podaj miejsce urodzenia: ");
        var birthPlace = PersonStringDataCheck(Console.ReadLine());
        Console.Clear();

        Console.Write("Podaj datę urodzenia w formacie 'dd.MM.rrrr' : ");
        var birthDate = DataFormat(Console.ReadLine());
        Console.Clear();

        var newPerson = new Person(birthDate)
        {
            _firstName = firstName,
            _lastName = lastName,
            _birthPlace = birthPlace,
            _birthDate = birthDate,
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

    private static string PersonStringDataCheck(string Textdata)
    {
        if (Textdata.All(Char.IsLetter))
        {
            return Textdata;
        }else
        {
            Console.WriteLine("Błędne dane!!! Imię, nazwisko oraz miejsce urodzenie nie może zawierać cyfr oraz znaków!");
            FormFillError();
        }
        return null;
    }

    public static DateTime DataFormat(string DataText)
    {
        DateTime data = new DateTime(1111,1,1);
        try
        {
            data = DateTime.Parse(DataText, null);
        }
        catch (Exception)
        {
            Console.WriteLine("Niepoprawny format daty");
            FormFillError();
        }

        return data;
    }

    private static void FormFillError()
    {
        Console.Write("Czy chcesz ponownie wypełnićp pola? [Tak - T || Nie - N]: ");
        var decheck = Console.ReadLine();
        if (decheck == "T")
        {
            SimplePersonInfo(PersonBuilder());
            Console.Clear();
        }
        else if (decheck == "N")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Błędny wpis!");
            Console.WriteLine("=====================");
            FormFillError();
        }
    }

    public static void SimplePersonInfo(Person person)
    {
        var sex = person._firstName.EndsWith('a') ? "Urodziłaś" : "Urodziłeś";
        Console.WriteLine(
            $"Witaj!\n" +
            $"Twoje imię to {person._firstName} a nazwisko {person._lastName}\n" +
            $"{sex} się w miejscowości { person._birthPlace} w { person._birthDate.ToString("dd.MM.yyyy") } roku i aktualnie masz { person._age}");
    }
}