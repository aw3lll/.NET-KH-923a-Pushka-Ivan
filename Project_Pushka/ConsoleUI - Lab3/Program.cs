using System;
using Core;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Метод розширення
            Console.WriteLine("=== Метод розширення ===");

            Movie myMovie = new Movie("Термінатор", 107, 8.1, "Бойовик", false);
            Session mySession = new Session(myMovie, "Головний зал", DateTime.Now, 150.5, 120);

            Console.WriteLine($"Ціна без розширення: {mySession.TicketPrice}");
            Console.WriteLine($"Ціна з розширенням:  {mySession.TicketPrice.ToCurrencyString()}");


            // Клас-контейнер та агрегація
            Console.WriteLine("\n=== Клас-контейнер ===");
            Cinema multiplex = new Cinema("Мультиплекс");

            Movie dune = new Movie("Дюна: Частина друга", 166, 8.9, "Фантастика", true);
            Movie oppenheimer = new Movie("Оппенгеймер", 180, 8.4, "Біографія", false);

            Session duneSession = new Session(dune, "IMAX Зал", DateTime.Now.AddHours(2), 350.00, 100, true);
            Session oppSession = new Session(oppenheimer, "Зал 2", DateTime.Now.AddHours(4), 200.00, 50, false);

            Ticket ticket1 = new Ticket("T-001", duneSession, "Іван Пушка", 10, 15, "VIP", true);
            Ticket ticket2 = new Ticket("T-002", duneSession, "Клієнт2", 10, 16, "VIP", true);
            Ticket ticket3 = new Ticket("T-003", oppSession, "Клієнт3", 5, 5);

            multiplex.AddMovie(myMovie);
            multiplex.AddMovie(dune);
            multiplex.AddMovie(oppenheimer);

            multiplex.AddSession(mySession);
            multiplex.AddSession(duneSession);
            multiplex.AddSession(oppSession);

            multiplex.AddTicket(ticket1);
            multiplex.AddTicket(ticket2);
            multiplex.AddTicket(ticket3);

            multiplex.PrintCinemaInfo();


            // Ітерація foreach
            Console.WriteLine("\n=== Демонстрація ітерації foreach ===");
            foreach (Session item in multiplex)
            {
                Console.WriteLine($"[Ітерація] Знайдено сеанс: {item.Film.Title} у залі {item.HallName}");
            }



            // Словник та LINQ
            Console.WriteLine("\n=== Демонстрація роботи зі Словником та LINQ ===");

            // пошук за ID
            string searchKey = "T-001";
            Console.WriteLine($"\nШукаємо квиток за ID '{searchKey}':");
            Ticket found = multiplex.FindTicketFast(searchKey);
            Console.WriteLine(found != null ? found.ToString() : "Квиток не знайдено!");

            // Фільтрація LINQ
            Console.WriteLine("\nШукаємо всі оплачені VIP квитки (через LINQ):");
            List<Ticket> vipTickets = multiplex.GetPaidTicketsByType("VIP");
            foreach (var t in vipTickets)
            {
                Console.WriteLine(t.ToString());
            }


            Console.WriteLine("\n=== Демонстрація роботи з HashSet ===");

            Movie commuter = new Movie("Пасажир", 104, 6.3, "Трилер", false);
            Movie nonStop = new Movie("Повітряний маршал", 106, 6.9, "Бойовик", false);

            bool added1 = commuter.AddTag("Трилер");
            Console.WriteLine($"Додаємо 'Трилер': {added1} (Всього тегів: {commuter.Tags.Count})");

            bool added2 = commuter.AddTag("Бойовик");
            Console.WriteLine($"Додаємо 'Бойовик': {added2} (Всього тегів: {commuter.Tags.Count})");

            // Спроба додати дублікат
            bool addedDuplicate = commuter.AddTag("Трилер");
            Console.WriteLine($"Додаємо дублікат 'Трилер': {addedDuplicate} (Всього тегів: {commuter.Tags.Count} - Колекція не змінилась!)");

            nonStop.AddTag("Трилер");
            nonStop.AddTag("Бойовик");
            nonStop.AddTag("Літак");

            HashSet<string> commonTags = new HashSet<string>(commuter.Tags);

            // Залишаємо тільки спільні теги
            commonTags.IntersectWith(nonStop.Tags);

            if (commonTags.Count > 0)
            {
                Console.WriteLine("Знайдено спільні теги:");
                foreach (var tag in commonTags)
                {
                    Console.WriteLine($" - {tag}");
                }
            }
            else
            {
                Console.WriteLine("Спільних тегів немає.");
            }
        }
    }
}