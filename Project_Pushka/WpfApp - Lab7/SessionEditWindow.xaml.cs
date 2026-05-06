using System;
using System.Collections.Generic;
using System.Windows;
using Core;

namespace WpfApp___Lab7
{
    public partial class SessionEditWindow : Window
    {
        public Session? ResultSession { get; private set; }
        public SessionEditWindow(List<Movie> movies)
        {
            InitializeComponent();
            cmbFilm.ItemsSource = movies;
            dpDate.SelectedDate = DateTime.Now;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbFilm.SelectedItem is Movie m && int.TryParse(txtPrice.Text, out int p) && int.TryParse(txtSeats.Text, out int s))
            {
                ResultSession = new Session(m, txtHall.Text, dpDate.SelectedDate ?? DateTime.Now, p, s, chkIsVip.IsChecked ?? false);
                DialogResult = true;
            }
            else MessageBox.Show("Помилка вводу даних!");
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}