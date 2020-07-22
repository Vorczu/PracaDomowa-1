using PracaDomowa;
using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
        var newPerson = Builder.ConsolePersonInit();
        Builder.ConsoleePersonInfo(newPerson);
        Console.ReadLine();
    }
}
