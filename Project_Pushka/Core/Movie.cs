using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Movie : MotionPicture
    {
        public double Rating { get; set; }
        public string Genre { get; set; }
        public bool IsThreeD { get; set; }

        public Movie(string title, int duration, double rating, string genre, bool isThreeD)
            : base(title, duration)
        {
            Rating = rating;
            Genre = genre;
            IsThreeD = isThreeD;
        }

        public override string GetContentType() => "Художній фільм";

        public override void ShowBasicInfo()
        {
            base.ShowBasicInfo();
            Console.WriteLine($"[Додатково] Жанр: {Genre}, Рейтинг: {Rating}");
        }

        public override void DisplayInfo()
        {
            string type = IsThreeD ? "3D" : "2D";
            Console.WriteLine($"Фiльм: \"{Title}\" | Жанр: {Genre} | Формат: {type}");
        }
    }
}
