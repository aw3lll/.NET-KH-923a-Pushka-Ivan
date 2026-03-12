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
        public Session(string hall, DateTime time, double price)
        {
            HallName = hall;
            StartTime = time;
            TicketPrice = price;
        }
        public override string ToString()
        {
            string vip = IsVipHall ? "(VIP зал)" : "(Стандарт)";
            return $"Сеанс у {HallName} {vip} | Початок: {StartTime:dd.MM HH:mm} | Цiна: {TicketPrice} грн | Вiльно мiсць: {AvailableSeats}";
        }
    }
}
