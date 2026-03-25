using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Movie
    {
        private string _title;
        private int _duration;

        public string Title
        {
            get { return _title; }
            set { if (!string.IsNullOrEmpty(value) && value.Length >= 2) _title = value; }
        }

        public int DurationMinutes
        {
            get { return _duration; }
            set { if (value > 0) _duration = value; }
        }

        public double Rating { get; set; }
        public string Genre { get; set; }
        public bool IsThreeD { get; set; }

        public Movie() { }
        public Movie(string title, int duration, double rating, string genre, bool isThreeD)
        {
            Title = title;
            DurationMinutes = duration;
            Rating = rating;
            Genre = genre;
            IsThreeD = isThreeD;
        }
        public override string ToString()
        {
            string type = IsThreeD ? "3D" : "2D";
            return $"Фiльм: \"{Title}\" | Жанр: {Genre} | Тривалiсть: {DurationMinutes} хв | Рейтинг: {Rating} | Формат: {type}";
        }
    }
}
