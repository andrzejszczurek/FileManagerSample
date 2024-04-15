using FileManagerSample.Models;
using FileManagerSample.Services;
using System;
using System.Collections.Generic;

namespace FileManagerSample;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("START");

        var fileService = new FileService();


        var user1 = new User("Jan", "Kowalski", 21);
        var user2 = new User("Michał", "Nowak", 34);
        var user3 = new User("Zbigniew", "Json", 16);

        fileService.SaveIntoProjektDirectory(user1);
        fileService.SaveIntoProjektDirectory(user2);
        fileService.SaveIntoProjektDirectory(user3);

        fileService.SaveIntoBinDirectory(user1);
        fileService.SaveIntoBinDirectory(user2);
        fileService.SaveIntoBinDirectory(user3);

        Console.WriteLine("From bin directory: ");
        Display(fileService.LoadFromBinDirectory());

        Console.WriteLine("From project directory: ");
        Display(fileService.LoadFromProjektDirectory());

        Console.WriteLine("KONIEC");
        Console.ReadKey();
    }

    private static void Display(List<User> users)
    {
        foreach (var user in users)
        {
            Console.WriteLine();
            Console.WriteLine($"\tName: {user.Name}, Surname: {user.Surname}, Age: {user.Age}, ");
            Console.WriteLine();
        }
    }
}
