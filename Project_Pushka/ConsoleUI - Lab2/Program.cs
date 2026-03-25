using System;
using System.Collections;
using System.Diagnostics;
using Core;

namespace ConsoleUI
{
    class Program
    {
        static void ChangePrice(Price price)
        {
            price.Amount = 666.66;
            Console.WriteLine($"Змiнена цiна всерединi методу: {price}");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Лаб 2.2
            Console.WriteLine("2. Дослiдження структур");
            Price newPrice = new Price(500.0, "грн");
            Console.WriteLine($"Початкова цiна: {newPrice}");
            ChangePrice(newPrice);
            Console.WriteLine($"Цiна пiсля виклику методу: {newPrice}");

            //Лаб 2.3
            Console.WriteLine("\n3. Аналіз Boxing/Unboxing");
            const int iteration = 1_000_000;
            Stopwatch progress_time = new Stopwatch();

            //Тест ArrayList
            ArrayList arrayList = new ArrayList();
            progress_time.Start();

            for (int i = 0; i < iteration; i++)
            {
                arrayList.Add(i);
            }
            progress_time.Stop();
            long first_time = progress_time.ElapsedMilliseconds;
            Console.WriteLine($"Нетипізований ArrayList: {progress_time.ElapsedMilliseconds} мс");
            progress_time.Reset();

            //Тест List
            List<int> myList = new List<int>();
            progress_time.Start();
            for (int i = 0; i < iteration; i++)
            {
                myList.Add(i);
            }
            progress_time.Stop();

            Console.WriteLine($"Типізований List: {progress_time.ElapsedMilliseconds} мс");
            Console.WriteLine($"Різниця у виконанні часу: {first_time - progress_time.ElapsedMilliseconds} мс");

            //Лаб 2.4
            Console.WriteLine("\n4. Створення колекції об'єктів класу Movie");
            List<Movie> movies = new List<Movie>
            {
                new Movie("Леон", 110, 8.5, "Кримінал", false),
                new Movie("Гладіатор", 155, 8.5, "Історія", false),
                new Movie("Матриця", 136, 8.7, "Фантастика", true),
                new Movie("Дюна", 155, 8.0, "Драма", true),
                new Movie("Сім", 127, 8.6, "Трилер", false),
                new Movie("Бійцівський клуб", 139, 8.8, "Драма", false),
                new Movie("Зоряні війни", 121, 8.6, "Пригоди", true),
                new Movie("Паразити", 132, 8.5, "Трилер", false),
                new Movie("Відступники", 151, 8.5, "Детектив", false),
                new Movie("Джокер", 122, 8.4, "Драма", false)
            };

            int counter = 1;
            foreach (var movie in movies)
            {
                Console.WriteLine($"{counter}. {movie}");
                counter++;
            }

            //Лаб 2.5
            var longMovies = movies.Where(n => n.DurationMinutes > 120).ToList();
            Console.WriteLine("\n5. Фільми тривалістю більше 120 хвилин:");
            longMovies.ForEach(n => Console.WriteLine(n));

            //Лаб 2.6
            var sortedMovies = movies.OrderByDescending(n => n.Rating).ThenBy(n => n.Title).ToList();
            Console.WriteLine("\n6. Фільми за рейтингом у алфавітному порядку:");
            sortedMovies.ForEach(n => Console.WriteLine(n));

            //Лаб 2.7
            List<string> movieTitles = movies.Select(n => n.Title).ToList();
            Console.WriteLine("\n7. Назви фільмів за допомогою Select:");
            movieTitles.ForEach(title => Console.WriteLine($"{title}"));

            //Лаб 2.8
            string searchTitle = "Дюна";
            Console.WriteLine($"\n8. Пошук фільма за назвою: {searchTitle}");
            Movie foundMovie = movies.FirstOrDefault(n => n.Title == searchTitle);
            if (foundMovie != null)
            {
                Console.WriteLine($"Знайдений об'єкт: {foundMovie}");
            }
            else
            {
                Console.WriteLine($"Фільма з назвою '{searchTitle}' не було знайдено.");
            }

            searchTitle = "Фільм";
            Console.WriteLine($"\nПошук фільма за назвою: {searchTitle}");
            foundMovie = movies.FirstOrDefault(n => n.Title == searchTitle);
            if (foundMovie != null)
            {
                Console.WriteLine($"Знайдений об'єкт: {foundMovie}");
            }
            else
            {
                Console.WriteLine($"Фільма з назвою '{searchTitle}' не було знайдено.");
            }
        }
    }
}