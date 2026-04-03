using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Cinema
    {
        public string Name { get; set; }

        private List<Movie> _movies;
        private List<Session> _sessions;
        private Dictionary<string, Ticket> _ticketDictionary;

        public Cinema(string name)
        {
            Name = name;
            _movies = new List<Movie>();
            _sessions = new List<Session>();
            _ticketDictionary = new Dictionary<string, Ticket>();
        }

        public void AddMovie(Movie movie)
        {
            if (movie != null) _movies.Add(movie);
        }

        public bool RemoveMovie(Movie movie)
        {
            return _movies.Remove(movie);
        }

        public List<Movie> GetAllMovies() => _movies;

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

            Console.WriteLine($"\n[Фільми в прокаті: {_movies.Count}]");
            foreach (var m in _movies) Console.WriteLine(" * " + m.ToString());

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