using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Session
    {
        private double _price;
        private int _seats;

        public Movie Film { get; set; }

        public string HallName { get; set; }
        public DateTime StartTime { get; set; }

        public double TicketPrice
        {
            get { return _price; }
            set { if (value >= 0) _price = value; }
        }

        public int AvailableSeats
        {
            get { return _seats; }
            set { if (value >= 0) _seats = value; }
        }

        public bool IsVipHall { get; set; }

        public Session() { }
        public Session(Movie film, string hall, DateTime time, double price, int seats, bool isVip = false)
        {
            Film = film;
            HallName = hall;
            StartTime = time;
            TicketPrice = price;
            AvailableSeats = seats;
            IsVipHall = isVip;
        }
        public override string ToString()
        {
            string vip = IsVipHall ? "(VIP зал)" : "(Стандарт)";
            string movieTitle = Film != null ? Film.Title : "Невідомий фільм";

            return $"Сеанс: «{movieTitle}» | {HallName} {vip} | Початок: {StartTime:dd.MM HH:mm} | Цiна: {TicketPrice} грн | Вільних місць: {AvailableSeats}";
        }
    }
}
