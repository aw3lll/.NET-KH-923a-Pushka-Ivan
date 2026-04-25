using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Documentary : MotionPicture
    {
        public string Topic { get; set; }

        public Documentary() { }
        public Documentary(string title, int duration, string topic)
            : base(title, duration)
        {
            Topic = topic;
        }

        public override string GetContentType() => "Документальне кіно";

        public override void DisplayInfo()
        {
            Console.WriteLine($"Док. фільм: \"{Title}\" | Тематика: {Topic}");
        }
    }
}
