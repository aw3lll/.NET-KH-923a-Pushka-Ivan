using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Cinema
    {
        public string Name { get; set; }

        // Агрегація
        public List<MotionPicture> ContentList { get; set; }
        public List<Session> Sessions { get; set; }
        public Dictionary<string, Ticket> TicketDictionary { get; set; }

        public Cinema()
        {
            ContentList = new List<MotionPicture>();
            Sessions = new List<Session>();
            TicketDictionary = new Dictionary<string, Ticket>();
        }
        public Cinema(string name) : this()
        {
            Name = name;
        }
        public void AddContent(MotionPicture content)
        {
            if (content != null) ContentList.Add(content);
        }

        public bool RemoveContent(MotionPicture content)
        {
            return ContentList.Remove(content);
        }

        public List<MotionPicture> GetAllContent() => ContentList;

        public void AddSession(Session session)
        {
            if (session != null) Sessions.Add(session);
        }

        public bool RemoveSession(Session session)
        {
            return Sessions.Remove(session);
        }

        public List<Session> GetAllSessions() => Sessions;

        public void AddTicket(Ticket ticket)
        {
            if (ticket != null && !string.IsNullOrEmpty(ticket.TicketId))
            {
                if (!TicketDictionary.ContainsKey(ticket.TicketId))
                {
                    TicketDictionary.Add(ticket.TicketId, ticket);
                }
            }
        }

        public bool RemoveTicket(string ticketId)
        {
            if (string.IsNullOrEmpty(ticketId)) return false;
            return TicketDictionary.Remove(ticketId);
        }

        public List<Ticket> GetAllTickets() => TicketDictionary.Values.ToList();

        public Ticket FindTicketFast(string ticketId)
        {
            if (TicketDictionary.TryGetValue(ticketId, out Ticket foundTicket))
                return foundTicket;
            return null;
        }

        public List<Ticket> GetPaidTicketsByType(string type)
        {
            return TicketDictionary
                .Where(kvp => kvp.Value.IsPaid && kvp.Value.TicketType == type)
                .Select(kvp => kvp.Value)
                .ToList();
        }
        public void PrintCinemaInfo()
        {
            Console.WriteLine($"\n====== КІНОТЕАТР: {Name?.ToUpper()} ======");

            Console.WriteLine($"\n[Контент у прокаті: {ContentList.Count}]");
            foreach (var c in ContentList)
            {
                Console.Write(" * ");
                c.DisplayInfo();
            }

            Console.WriteLine($"\n[Заплановані сеанси: {Sessions.Count}]");
            foreach (var s in Sessions) Console.WriteLine(" * " + s.ToString());

            Console.WriteLine($"\n[Продані квитки: {TicketDictionary.Count}]");
            foreach (var t in TicketDictionary.Values) Console.WriteLine(" * " + t.ToString());

            Console.WriteLine("=====================================\n");
        }

        public IEnumerator<Session> GetEnumerator()
        {
            foreach (var session in Sessions)
            {
                yield return session;
            }
        }
    }
}