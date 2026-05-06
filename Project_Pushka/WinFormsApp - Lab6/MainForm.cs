using System;
using System.Windows.Forms;
using System.Linq;
using Core;

namespace WinFormsApp___Lab6
{
    public partial class MainForm : Form
    {
        private Cinema _cinema = new Cinema("Multiplex");

        private BindingSource _movieBS = new BindingSource();
        private BindingSource _sessionBS = new BindingSource();
        private BindingSource _ticketBS = new BindingSource();

        public MainForm()
        {
            InitializeComponent();

            btnAddMovie.Click += btnAddMovie_Click;
            btnDeleteMovie.Click += btnDeleteMovie_Click;

            btnAddSession.Click += btnAddSession_Click;
            btnDeleteSession.Click += btnDeleteSession_Click;

            btnAddTicket.Click += btnAddTicket_Click;
            btnDeleteTicket.Click += btnDeleteTicket_Click;

            btnLoadJson.Click += btnLoadJson_Click;
            btnSaveJson.Click += btnSaveJson_Click;

            InitializeDataBindings();
        }

        private void RefreshMovieGrid()
        {
            dgvMovies.DataSource = null;
            dgvMovies.Columns.Clear();

            _movieBS.DataSource = _cinema.ContentList.OfType<Movie>().ToList();
            dgvMovies.DataSource = _movieBS;

            if (dgvMovies.Columns["Tags"] != null) dgvMovies.Columns["Tags"].Visible = false;

            if (dgvMovies.Columns["Title"] != null) dgvMovies.Columns["Title"].HeaderText = "Назва";
            if (dgvMovies.Columns["DurationMinutes"] != null) dgvMovies.Columns["DurationMinutes"].HeaderText = "Тривалість (хв)";
            if (dgvMovies.Columns["Genre"] != null) dgvMovies.Columns["Genre"].HeaderText = "Жанр";
            if (dgvMovies.Columns["Rating"] != null) dgvMovies.Columns["Rating"].HeaderText = "Рейтинг";
            if (dgvMovies.Columns["IsThreeD"] != null) dgvMovies.Columns["IsThreeD"].HeaderText = "3D";

            if (dgvMovies.Columns["Title"] != null) dgvMovies.Columns["Title"].DisplayIndex = 0;
            if (dgvMovies.Columns["DurationMinutes"] != null) dgvMovies.Columns["DurationMinutes"].DisplayIndex = 1;
            if (dgvMovies.Columns["Genre"] != null) dgvMovies.Columns["Genre"].DisplayIndex = 2;
            if (dgvMovies.Columns["Rating"] != null) dgvMovies.Columns["Rating"].DisplayIndex = 3;
            if (dgvMovies.Columns["IsThreeD"] != null) dgvMovies.Columns["IsThreeD"].DisplayIndex = 4;
        }

        private void RefreshSessionGrid()
        {
            dgvSessions.DataSource = null;
            dgvSessions.Columns.Clear();

            _sessionBS.DataSource = _cinema.Sessions.ToList();
            dgvSessions.DataSource = _sessionBS;

            if (dgvSessions.Columns["Film"] != null) dgvSessions.Columns["Film"].HeaderText = "Фільм";

            if (dgvSessions.Columns["HallName"] != null) dgvSessions.Columns["HallName"].HeaderText = "Зал";
            if (dgvSessions.Columns["StartTime"] != null) dgvSessions.Columns["StartTime"].HeaderText = "Час";
            if (dgvSessions.Columns["TicketPrice"] != null) dgvSessions.Columns["TicketPrice"].HeaderText = "Ціна";
            if (dgvSessions.Columns["AvailableSeats"] != null) dgvSessions.Columns["AvailableSeats"].HeaderText = "Місць";
            if (dgvSessions.Columns["IsVipHall"] != null) dgvSessions.Columns["IsVipHall"].HeaderText = "VIP";
        }

        private void RefreshTicketGrid()
        {
            dgvTickets.DataSource = null;
            dgvTickets.Columns.Clear();

            _ticketBS.DataSource = _cinema.GetAllTickets();
            dgvTickets.DataSource = _ticketBS;

            if (dgvTickets.Columns["TicketId"] != null) dgvTickets.Columns["TicketId"].HeaderText = "ID Квитка";
            if (dgvTickets.Columns["CinemaSession"] != null) dgvTickets.Columns["CinemaSession"].HeaderText = "Сеанс";
            if (dgvTickets.Columns["CustomerName"] != null) dgvTickets.Columns["CustomerName"].HeaderText = "Покупець";
            if (dgvTickets.Columns["RowNumber"] != null) dgvTickets.Columns["RowNumber"].HeaderText = "Ряд";
            if (dgvTickets.Columns["SeatNumber"] != null) dgvTickets.Columns["SeatNumber"].HeaderText = "Місце";
            if (dgvTickets.Columns["TicketType"] != null) dgvTickets.Columns["TicketType"].HeaderText = "Тип";
            if (dgvTickets.Columns["IsPaid"] != null) dgvTickets.Columns["IsPaid"].HeaderText = "Оплачено";
        }

        private void InitializeDataBindings()
        {
            dgvMovies.AllowUserToAddRows = false;
            dgvSessions.AllowUserToAddRows = false;
            dgvTickets.AllowUserToAddRows = false;

            RefreshMovieGrid();
            RefreshSessionGrid();
            RefreshTicketGrid();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            using (var form = new MovieEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _cinema.AddContent(form.ResultMovie);
                    RefreshMovieGrid();
                }
            }
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            if (_cinema.ContentList.Count == 0)
            {
                MessageBox.Show("Спочатку додай хоча б один фільм!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new SessionEditForm(_cinema.ContentList))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _cinema.AddSession(form.ResultSession);
                    RefreshSessionGrid();
                }
            }
        }

        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            if (_cinema.Sessions.Count == 0)
            {
                MessageBox.Show("Спочатку створи сеанс!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new TicketEditForm(_cinema.Sessions))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _cinema.AddTicket(form.ResultTicket);
                    RefreshTicketGrid();
                }
            }
        }
        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            if (dgvMovies.CurrentRow != null)
            {
                var movie = (MotionPicture)dgvMovies.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show($"Видалити фільм '{movie.Title}'? Це знищить всі його сеанси та квитки!",
                    "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    var sessionsToDelete = _cinema.Sessions.Where(s => s.Film == movie).ToList();

                    foreach (var session in sessionsToDelete)
                    {
                        var ticketsToDelete = _cinema.GetAllTickets().Where(t => t.CinemaSession == session).ToList();
                        foreach (var t in ticketsToDelete)
                        {
                            _cinema.RemoveTicket(t.TicketId);
                        }

                        _cinema.RemoveSession(session);
                    }

                    _cinema.RemoveContent(movie);

                    RefreshMovieGrid();
                    RefreshSessionGrid();
                    RefreshTicketGrid();
                }
            }
        }

        private void btnDeleteSession_Click(object sender, EventArgs e)
        {
            if (dgvSessions.CurrentRow != null)
            {
                var session = (Session)dgvSessions.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show("Скасувати цей сеанс та всі пов'язані квитки?",
                    "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    var ticketsToDelete = _cinema.GetAllTickets().Where(t => t.CinemaSession == session).ToList();

                    foreach (var t in ticketsToDelete)
                    {
                        _cinema.RemoveTicket(t.TicketId);
                    }

                    _cinema.RemoveSession(session);

                    RefreshSessionGrid();
                    RefreshTicketGrid();
                }
            }
        }
        private void btnDeleteTicket_Click(object sender, EventArgs e)
        {
            if (dgvTickets.CurrentRow != null)
            {
                var ticket = (Ticket)dgvTickets.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show($"Анулювати квиток №{ticket.TicketId}?",
                    "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (confirm == DialogResult.Yes)
                {
                    _cinema.RemoveTicket(ticket.TicketId);
                    RefreshTicketGrid();
                }
            }
        }

        private void btnSaveJson_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "JSON|*.json" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DataManager.SaveToJson(_cinema, sfd.FileName);
                MessageBox.Show("Дані успішно збережені!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLoadJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "JSON|*.json" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var loadedData = DataManager.LoadFromJson(ofd.FileName);
                if (loadedData != null)
                {
                    _cinema = loadedData;
                    InitializeDataBindings();
                    MessageBox.Show("Дані успішно завантажено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}