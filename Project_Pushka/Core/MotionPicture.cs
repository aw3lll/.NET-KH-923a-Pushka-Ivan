using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Core
{
    [JsonDerivedType(typeof(Movie), typeDiscriminator: "movie")]
    [JsonDerivedType(typeof(Documentary), typeDiscriminator: "doc")]
    public abstract class MotionPicture : IShow
    {
        private string _title;
        private int _duration;

        public HashSet<string> Tags { get; set; }

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
        public MotionPicture()
        {
            Tags = new HashSet<string>();
        }

        public MotionPicture(string title, int duration)
        {
            Title = title;
            DurationMinutes = duration;
            Tags = new HashSet<string>();
        }

        // Віртуальний метод
        public virtual void ShowBasicInfo()
        {
            Console.WriteLine($"[Базове інфо] Назва: {Title}, Тривалість: {DurationMinutes} хв.");
        }

        // Абстрактний метод
        public abstract string GetContentType();

        // Реалізація інтерфейсу IShow
        public abstract void DisplayInfo();
    }
}
