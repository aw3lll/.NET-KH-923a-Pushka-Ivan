using System;
using Core;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            string version = Environment.OSVersion.ToString();

            long ramBytes = GC.GetTotalMemory(true);
            double ramKb = ramBytes / 1024.0 ;

            Console.WriteLine("Системна iнформацiя");
            Console.WriteLine($"Версiя ОС: {version}");
            Console.WriteLine($"Використана пам'ять: {ramKb:F2} кб");

            //Задание 2

            Movie myMovie = new Movie("Iнтерстеллар", 169, 8.7)
            {
                Genre = "Наукова фантастика",
                IsThreeD = false
            };

            Session mySession = new Session("IMAX Зал", DateTime.Now.AddHours(3), 250.0)
            {
                AvailableSeats = 120,
                IsVipHall = false
            };

            Ticket myTicket = new Ticket("Oleg", 7, 42)
            {
                TicketType = "Студентський",
                IsPaid = true
            };

            Console.WriteLine("Данi об'єктiв класiв:");

            Console.WriteLine(myMovie);
            Console.WriteLine(mySession);
            Console.WriteLine(myTicket);

            Console.ReadKey();
        }
    }
}