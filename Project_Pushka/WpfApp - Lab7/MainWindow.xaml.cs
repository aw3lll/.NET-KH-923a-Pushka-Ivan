using System;
using System.Linq;
using System.Windows;
using Core;
using Microsoft.Win32;
using System.Collections.Generic;

namespace WpfApp___Lab7
{
    public partial class MainWindow : Window
    {
        private Cinema _cinema = new Cinema("Multiplex");

        public MainWindow()
        {
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            dgMovies.ItemsSource = null;
            dgMovies.ItemsSource = _cinema.ContentList.OfType<Movie>().ToList();
            dgSessions.ItemsSource = null;
            dgSessions.ItemsSource = _cinema.Sessions.ToList();
            dgTickets.ItemsSource = null;
            dgTickets.ItemsSource = _cinema.GetAllTickets();
        }

        private void btnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            var win = new MovieEditWindow();
            if (win.ShowDialog() == true && win.ResultMovie != null)
            {
                _cinema.AddContent(win.ResultMovie);
                RefreshData();
            }
        }

        private void btnAddSession_Click(object sender, RoutedEventArgs e)
        {
            if (!_cinema.ContentList.Any()) { MessageBox.Show("Спочатку додайте фільм!"); return; }
            var win = new SessionEditWindow(_cinema.ContentList.OfType<Movie>().ToList());
            if (win.ShowDialog() == true && win.ResultSession != null)
            {
                _cinema.AddSession(win.ResultSession);
                RefreshData();
            }
        }

        private void btnAddTicket_Click(object sender, RoutedEventArgs e)
        {
            if (!_cinema.Sessions.Any()) { MessageBox.Show("Спочатку створіть сеанс!"); return; }
            var win = new TicketEditWindow(_cinema.Sessions.ToList());
            if (win.ShowDialog() == true && win.ResultTicket != null)
            {
                _cinema.AddTicket(win.ResultTicket);
                RefreshData();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MainTabs.SelectedIndex == 0 && dgMovies.SelectedItem is Movie m)
            {
                if (MessageBox.Show($"Видалити фільм '{m.Title}' каскадом?", "Увага", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
            }
            else if (MainTabs.SelectedIndex == 1 && dgSessions.SelectedItem is Session s)
            {
                if (MessageBox.Show("Скасувати сеанс та всі квитки?", "Увага", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var tickets = _cinema.GetAllTickets().Where(t => t.CinemaSession == s).ToList();
                    foreach (var t in tickets) _cinema.RemoveTicket(t.TicketId);
                    _cinema.RemoveSession(s);
                }
            }
            else if (MainTabs.SelectedIndex == 2 && dgTickets.SelectedItem is Ticket t)
            {
                if (MessageBox.Show("Анулювати квиток?", "Увага", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    _cinema.RemoveTicket(t.TicketId);
            }
            RefreshData();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = "JSON|*.json" };
            if (sfd.ShowDialog() == true) DataManager.SaveToJson(_cinema, sfd.FileName);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog { Filter = "JSON|*.json" };
            if (ofd.ShowDialog() == true)
            {
                var d = DataManager.LoadFromJson(ofd.FileName);
                if (d != null) { _cinema = d; RefreshData(); }
            }
        }
    }
}