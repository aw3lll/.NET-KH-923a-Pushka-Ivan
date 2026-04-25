using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Core
{
    public static class DataManager
    {
        // налаштування JsonSerializer
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve // циклічні зв'язки (квиток -> сеанс -> Фільм)
        };

        public static void SaveToJson(Cinema cinema, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(cinema, _options);
            File.WriteAllText(filePath, jsonString);
        }

        //Валідація та обробка помилок
        public static Cinema LoadFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"[Помилка] Файл '{filePath}' не знайдено!");
                return null;
            }

            try
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Cinema>(jsonString, _options);
            }
            catch (JsonException ex) // Обробка пошкодженого файлу
            {
                Console.WriteLine($"[Помилка десеріалізації] Файл пошкоджено: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Критична помилка] {ex.Message}");
                return null;
            }
        }

        // Робота з XML
        public static void ExportVipSessionsToXml(Cinema cinema, string filePath)
        {
            var vipSessions = cinema.Sessions.Where(s => s.IsVipHall).ToList();

            XDocument xDoc = new XDocument(
                new XElement("CinemaExport",
                    new XElement("CinemaName", cinema.Name),
                    new XElement("VipSessions",
                        from s in vipSessions
                        select new XElement("Session",
                            new XAttribute("Hall", s.HallName),
                            new XElement("FilmTitle", s.Film?.Title ?? "Невідомо"),
                            new XElement("Price", s.TicketPrice)
                        )
                    )
                )
            );

            xDoc.Save(filePath);
        }
    }
}
