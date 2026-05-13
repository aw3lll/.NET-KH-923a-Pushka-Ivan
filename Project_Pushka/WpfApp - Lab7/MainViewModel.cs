using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Core;
using Microsoft.Win32;

namespace WpfApp___Lab7
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Cinema _cinema = new Cinema("Multiplex");

        public ObservableCollection<Movie> Movies { get; set; } = new();
        public ObservableCollection<Session> Sessions { get; set; } = new();
        public ObservableCollection<Ticket> Tickets { get; set; } = new();

        public ICommand AddMovieCommand { get; }
        public ICommand AddSessionCommand { get; }
        public ICommand AddTicketCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }

        public MainViewModel()
        {
            AddMovieCommand = new RelayCommand(_ => AddMovie());
            AddSessionCommand = new RelayCommand(_ => AddSession());
            AddTicketCommand = new RelayCommand(_ => AddTicket());
            DeleteCommand = new RelayCommand(param => Delete(param));
            SaveCommand = new RelayCommand(_ => Save());
            LoadCommand = new RelayCommand(_ => Load());

            SyncCollections();
        }

        private void AddMovie()
        {
            var win = new MovieEditWindow();
            if (win.ShowDialog() == true && win.ResultMovie != null)
            {
                _cinema.AddContent(win.ResultMovie);
                SyncCollections();
            }
        }

        private void AddSession()
        {
            if (!_cinema.ContentList.Any()) return;
            var win = new SessionEditWindow(_cinema.ContentList.OfType<Movie>().ToList());
            if (win.ShowDialog() == true && win.ResultSession != null)
            {
                _cinema.AddSession(win.ResultSession);
                SyncCollections();
            }
        }

        private void AddTicket()
        {
            if (!_cinema.Sessions.Any()) return;
            var win = new TicketEditWindow(_cinema.Sessions.ToList());
            if (win.ShowDialog() == true && win.ResultTicket != null)
            {
                _cinema.AddTicket(win.ResultTicket);
                SyncCollections();
            }
        }

        private void Delete(object? parameter)
        {
            if (parameter == null) return;
            if (MessageBox.Show("Видалити обраний елемент?", "Підтвердження", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

            if (parameter is Movie m)
            {
                var sessions = _cinema.Sessions.Where(s => s.Film == m).ToList();
                foreach (var s in sessions)
                {
                    var tickets = _cinema.GetAllTickets().Where(t => t.CinemaSession == s).ToList();
                    foreach (var t in tickets) _cinema.RemoveTicket(t.TicketId);
                    _cinema.RemoveSession(s);
                }
                _cinema.RemoveContent(m);
            }
            else if (parameter is Session s)
            {
                var tickets = _cinema.GetAllTickets().Where(t => t.CinemaSession == s).ToList();
                foreach (var t in tickets) _cinema.RemoveTicket(t.TicketId);
                _cinema.RemoveSession(s);
            }
            else if (parameter is Ticket t)
            {
                _cinema.RemoveTicket(t.TicketId);
            }
            SyncCollections();
        }

        private void Save()
        {
            var sfd = new SaveFileDialog { Filter = "JSON|*.json" };
            if (sfd.ShowDialog() == true) DataManager.SaveToJson(_cinema, sfd.FileName);
        }

        private void Load()
        {
            var ofd = new OpenFileDialog { Filter = "JSON|*.json" };
            if (ofd.ShowDialog() == true)
            {
                var d = DataManager.LoadFromJson(ofd.FileName);
                if (d != null) { _cinema = d; SyncCollections(); }
            }
        }

        private void SyncCollections()
        {
            Movies.Clear();
            foreach (var m in _cinema.ContentList.OfType<Movie>()) Movies.Add(m);
            Sessions.Clear();
            foreach (var s in _cinema.Sessions) Sessions.Add(s);
            Tickets.Clear();
            foreach (var t in _cinema.GetAllTickets()) Tickets.Add(t);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}