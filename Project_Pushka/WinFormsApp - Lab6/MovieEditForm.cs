using System;
using System.Windows.Forms;
using Core;

namespace WinFormsApp___Lab6
{
    public partial class MovieEditForm : Form
    {
        public Movie ResultMovie { get; private set; }

        public MovieEditForm()
        {
            InitializeComponent();

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Заповни назву та жанр!", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ResultMovie = new Movie(
                txtTitle.Text,
                (int)numDuration.Value,
                (double)numRating.Value,
                txtGenre.Text,
                chkIs3D.Checked
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MovieEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}