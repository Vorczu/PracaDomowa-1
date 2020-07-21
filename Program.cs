using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
        var newPerson = Person.ConsolePersonInit();
        newPerson.ConsoleePersonInfo();
        Console.ReadLine();
    }
}
