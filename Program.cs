using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
        var newPerson = Person.ConsolePersonInit();
        Person.ConsoleePersonInfo(newPerson);
        Console.ReadLine();
    }
}
