using System;
using Core;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string jsonPath = "cinema_data.json";
        string xmlPath = "vip_sessions.xml";
        string logPath = "system_log.txt";

        // використання using з ResourceManager
        using (ResourceManager logger = new ResourceManager(logPath))
        {
            logger.Log("Ініціалізація системи...");

            Cinema myCinema = new Cinema("Multiplex");
            Movie dune = new Movie("Dune", 160, 8.8, "Sci-Fi", true);
            Session session = new Session(dune, "IMAX", DateTime.Now.AddHours(2), 250, 100, true);
            Ticket t1 = new Ticket("T-001", session, "Ivan Pushka", 10, 15, "VIP", true);

            myCinema.AddContent(dune);
            myCinema.AddSession(session);
            myCinema.AddTicket(t1);

            logger.Log("Збереження у JSON...");
            DataManager.SaveToJson(myCinema, jsonPath);

            logger.Log("Експорт у XML...");
            DataManager.ExportVipSessionsToXml(myCinema, xmlPath);

            logger.Log("Тест завантаження з JSON...");
            Cinema loadedCinema = DataManager.LoadFromJson(jsonPath);

            if (loadedCinema != null)
            {
                logger.Log("Успішно завантажено. Інфо:");
                loadedCinema.PrintCinemaInfo();
            }

            logger.Log("Демонстрація обробки помилок (неіснуючий файл):");
            DataManager.LoadFromJson("fake_file.json");
        }

        Console.ReadLine();
    }
}