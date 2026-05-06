using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Core;

namespace WinFormsApp___Lab6
{
    public partial class SessionEditForm : Form
    {
        public Session ResultSession { get; private set; }

        public SessionEditForm(List<MotionPicture> availableMovies)
        {
            InitializeComponent();

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            cmbMovies.DataSource = availableMovies;
            cmbMovies.DisplayMember = "Title";
            cmbMovies.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbMovies.SelectedItem == null || string.IsNullOrWhiteSpace(txtHall.Text))
            {
                MessageBox.Show("Обери фільм та введи назву залу!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedMovie = (Movie)cmbMovies.SelectedItem;

            ResultSession = new Session(
                selectedMovie,
                txtHall.Text,
                dtpTime.Value,
                (double)numPrice.Value,
                (int)numSeats.Value,
                chkIsVip.Checked
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SessionEditForm_Load(object sender, EventArgs e)
        {

        }

        private void numPrice_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}