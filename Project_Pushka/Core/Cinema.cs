using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Cinema
    {
        public string Name { get; set; }

        // Агрегація
        private List<MotionPicture> _contentList;
        private List<Session> _sessions;
        private Dictionary<string, Ticket> _ticketDictionary;

        public Cinema(string name)
        {
            Name = name;
            _contentList = new List<MotionPicture>();
            _sessions = new List<Session>();
            _ticketDictionary = new Dictionary<string, Ticket>();
        }

        public void AddContent(MotionPicture content)
        {
            if (content != null) _contentList.Add(content);
        }

        public bool RemoveContent(MotionPicture content)
        {
            return _contentList.Remove(content);
        }

        public List<MotionPicture> GetAllContent() => _contentList;

        public void AddSession(Session session)
        {
            if (session != null) _sessions.Add(session);
        }

        public bool RemoveSession(Session session)
        {
            return _sessions.Remove(session);
        }

        public List<Session> GetAllSessions() => _sessions;

        public void AddTicket(Ticket ticket)
        {
            if (ticket != null && !string.IsNullOrEmpty(ticket.TicketId))
            {
                if (!_ticketDictionary.ContainsKey(ticket.TicketId))
                {
                    _ticketDictionary.Add(ticket.TicketId, ticket);
                }
            }
        }

        public bool RemoveTicket(string ticketId)
        {
            if (string.IsNullOrEmpty(ticketId)) return false;
            return _ticketDictionary.Remove(ticketId);
        }

        public List<Ticket> GetAllTickets() => _ticketDictionary.Values.ToList();

        public Ticket FindTicketFast(string ticketId)
        {
            if (_ticketDictionary.TryGetValue(ticketId, out Ticket foundTicket))
                return foundTicket;
            return null;
        }

        public List<Ticket> GetPaidTicketsByType(string type)
        {
            return _ticketDictionary
                .Where(kvp => kvp.Value.IsPaid && kvp.Value.TicketType == type)
                .Select(kvp => kvp.Value)
                .ToList();
        }

        public void PrintCinemaInfo()
        {
            Console.WriteLine($"\n====== КІНОТЕАТР: {Name.ToUpper()} ======");

            Console.WriteLine($"\n[Контент у прокаті: {_contentList.Count}]");
            foreach (var c in _contentList)
            {
                Console.Write(" * ");
                c.DisplayInfo();
            }

            Console.WriteLine($"\n[Заплановані сеанси: {_sessions.Count}]");
            foreach (var s in _sessions) Console.WriteLine(" * " + s.ToString());

            Console.WriteLine($"\n[Продані квитки: {_ticketDictionary.Count}]");
            foreach (var t in _ticketDictionary.Values) Console.WriteLine(" * " + t.ToString());

            Console.WriteLine("=====================================\n");
        }

        public IEnumerator<Session> GetEnumerator()
        {
            foreach (var session in _sessions)
            {
                yield return session;
            }
        }
    }
}