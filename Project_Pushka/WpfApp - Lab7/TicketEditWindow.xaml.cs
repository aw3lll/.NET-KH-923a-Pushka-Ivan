using System;
using System.Collections.Generic;
using System.Windows;
using Core;

namespace WpfApp___Lab7
{
    public partial class TicketEditWindow : Window
    {
        public Ticket? ResultTicket { get; private set; }
        public TicketEditWindow(List<Session> sessions)
        {
            InitializeComponent();
            cmbSession.ItemsSource = sessions;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSession.SelectedItem is Session s && int.TryParse(txtRow.Text, out int r) && int.TryParse(txtSeat.Text, out int st))
            {
                string id = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                ResultTicket = new Ticket(id, s, txtName.Text, r, st, "Standard", chkPaid.IsChecked ?? false);
                DialogResult = true;
            }
            else MessageBox.Show("Перевірте числа!");
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}