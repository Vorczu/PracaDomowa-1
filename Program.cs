using PracaDomowa;
using System;

public class Program
{

    public static void Main()
	{
        var newPerson = SampleFact.CreatePerson();
        newPerson.ConsoleePersonInfo();
        Console.ReadLine();
    }
}
