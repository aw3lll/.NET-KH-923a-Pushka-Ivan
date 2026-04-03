using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Ticket
    {
        public string TicketId { get; set; }

        private int _row;
        private int _seat;

        public Session CinemaSession { get; set; }

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
        public Ticket(string id, Session session, string name, int row, int seat, string ticketType = "Стандарт", bool isPaid = false)
        {
            TicketId = id;
            CinemaSession = session;
            CustomerName = name;
            RowNumber = row;
            SeatNumber = seat;
            TicketType = ticketType;
            IsPaid = isPaid;
        }
        public override string ToString()
        {
            string status = IsPaid ? "Оплачено" : "Не оплачено";
            string movieName = (CinemaSession != null && CinemaSession.Film != null) ? CinemaSession.Film.Title : "Невідомо";

            return $"[{TicketId}] Квиток: «{movieName}» | Ім'я: {CustomerName} | Ряд: {RowNumber}, Мiсце: {SeatNumber} | Статус: {status}";
        }
    }
}
