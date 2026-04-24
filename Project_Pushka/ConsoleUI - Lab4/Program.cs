using System;
using System.Collections.Generic;
using Core;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Композиція
        CinemaController controller = new CinemaController("Multiplex");
        controller.PrintSystemStatus();

        // Створення об'єктів ззовні (для агрегації)
        Movie dune = new Movie("Dune: Part Two", 166, 8.8, "Sci-Fi", true);
        Documentary nature = new Documentary("Our Planet", 50, "Nature & Animals");

        // Демонстрація агрегації
        controller.ManagedCinema.AddContent(dune);
        controller.ManagedCinema.AddContent(nature);

        Console.WriteLine("\nПоліморфізм: ");

        // Масив інтерфейсного типу
        IShow[] displayables = new IShow[]
        {
            dune,
            nature
        };

        foreach (var item in displayables)
        {
            Console.WriteLine("-------------------------------------------------");
            item.DisplayInfo(); // Виклик через інтерфейс IShow

            if (item is MotionPicture mp)
            {
                Console.WriteLine($"\nТип контенту: {mp.GetContentType()}"); // абстрактний метод
                mp.ShowBasicInfo(); // віртуальний метод
            }
        }
        Console.WriteLine("-------------------------------------------------");

        Console.ReadLine();
    }
}