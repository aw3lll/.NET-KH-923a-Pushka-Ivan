using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Ticket
    {
        private int _row;
        private int _seat;

        public string CustomerName { get; set; }
        public bool IsPaid { get; set; }

        public int RowNumber
        {
            get { return _row; }
            set { if (value > 0 && value <= 30) _row = value; }
        }

        public int SeatNumber
        {
            get { return _seat; }
            set { if (value > 0 && value <= 100) _seat = value; }
        }

        public string TicketType { get; set; }

        public Ticket() { }
        public Ticket(string name, int row, int seat)
        {
            CustomerName = name;
            RowNumber = row;
            SeatNumber = seat;
        }
        public string GetInfo()
        {
            string status = IsPaid ? "Оплачено" : "Не оплачено";
            return $"Квиток на iм'я {CustomerName} | Ряд: {RowNumber}, Мiсце: {SeatNumber} | Тип: {TicketType} | Статус: {status}";
        }
    }
}
