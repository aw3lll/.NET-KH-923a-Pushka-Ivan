using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Core;

namespace WinFormsApp___Lab6
{
    public partial class TicketEditForm : Form
    {
        public Ticket ResultTicket { get; private set; }

        public TicketEditForm(List<Session> availableSessions)
        {
            InitializeComponent();

            cmbSessions.DataSource = availableSessions;
            cmbSessions.DropDownStyle = ComboBoxStyle.DropDownList;

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSessions.SelectedItem == null || string.IsNullOrWhiteSpace(txtCustomer.Text))
            {
                MessageBox.Show("Обери сеанс та введи ім'я покупця!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedSession = (Session)cmbSessions.SelectedItem;

            string generatedId = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

            ResultTicket = new Ticket(
                generatedId,
                selectedSession,
                txtCustomer.Text,
                (int)numRow.Value,
                (int)numSeat.Value,
                "Standard",
                chkIsPaid.Checked
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TicketEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}