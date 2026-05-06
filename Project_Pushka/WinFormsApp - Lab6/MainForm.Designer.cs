namespace WinFormsApp___Lab6
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Films = new TabPage();
            btnDeleteMovie = new Button();
            btnLoadJson = new Button();
            btnSaveJson = new Button();
            btnAddMovie = new Button();
            dgvMovies = new DataGridView();
            Sessions = new TabPage();
            btnDeleteSession = new Button();
            btnAddSession = new Button();
            dgvSessions = new DataGridView();
            Tickets = new TabPage();
            btnDeleteTicket = new Button();
            btnAddTicket = new Button();
            dgvTickets = new DataGridView();
            tabControl1.SuspendLayout();
            Films.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovies).BeginInit();
            Sessions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSessions).BeginInit();
            Tickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Films);
            tabControl1.Controls.Add(Sessions);
            tabControl1.Controls.Add(Tickets);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1350, 550);
            tabControl1.TabIndex = 0;
            // 
            // Films
            // 
            Films.Controls.Add(btnDeleteMovie);
            Films.Controls.Add(btnLoadJson);
            Films.Controls.Add(btnSaveJson);
            Films.Controls.Add(btnAddMovie);
            Films.Controls.Add(dgvMovies);
            Films.Location = new Point(4, 34);
            Films.Name = "Films";
            Films.Padding = new Padding(3);
            Films.Size = new Size(1342, 512);
            Films.TabIndex = 0;
            Films.Text = "Фільми";
            Films.UseVisualStyleBackColor = true;
            // 
            // btnDeleteMovie
            // 
            btnDeleteMovie.Location = new Point(1104, 140);
            btnDeleteMovie.Name = "btnDeleteMovie";
            btnDeleteMovie.Size = new Size(205, 75);
            btnDeleteMovie.TabIndex = 5;
            btnDeleteMovie.Text = "Видалити фільм";
            btnDeleteMovie.UseVisualStyleBackColor = true;
            // 
            // btnLoadJson
            // 
            btnLoadJson.Location = new Point(1104, 240);
            btnLoadJson.Name = "btnLoadJson";
            btnLoadJson.Size = new Size(205, 75);
            btnLoadJson.TabIndex = 2;
            btnLoadJson.Text = "Завантажити JSON";
            btnLoadJson.UseVisualStyleBackColor = true;
            // 
            // btnSaveJson
            // 
            btnSaveJson.Location = new Point(1104, 340);
            btnSaveJson.Name = "btnSaveJson";
            btnSaveJson.Size = new Size(205, 75);
            btnSaveJson.TabIndex = 3;
            btnSaveJson.Text = "Зберегти у JSON";
            btnSaveJson.UseVisualStyleBackColor = true;
            // 
            // btnAddMovie
            // 
            btnAddMovie.Location = new Point(1104, 40);
            btnAddMovie.Name = "btnAddMovie";
            btnAddMovie.Size = new Size(205, 75);
            btnAddMovie.TabIndex = 4;
            btnAddMovie.Text = "Додати фільм";
            btnAddMovie.UseVisualStyleBackColor = true;
            // 
            // dgvMovies
            // 
            dgvMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovies.Location = new Point(25, 25);
            dgvMovies.Name = "dgvMovies";
            dgvMovies.RowHeadersWidth = 62;
            dgvMovies.Size = new Size(1050, 400);
            dgvMovies.TabIndex = 0;
            // 
            // Sessions
            // 
            Sessions.Controls.Add(btnDeleteSession);
            Sessions.Controls.Add(btnAddSession);
            Sessions.Controls.Add(dgvSessions);
            Sessions.Location = new Point(4, 34);
            Sessions.Name = "Sessions";
            Sessions.Padding = new Padding(3);
            Sessions.Size = new Size(1342, 512);
            Sessions.TabIndex = 1;
            Sessions.Text = "Сеанси";
            Sessions.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSession
            // 
            btnDeleteSession.Location = new Point(1104, 140);
            btnDeleteSession.Name = "btnDeleteSession";
            btnDeleteSession.Size = new Size(205, 75);
            btnDeleteSession.TabIndex = 6;
            btnDeleteSession.Text = "Скасувати сеанс";
            btnDeleteSession.UseVisualStyleBackColor = true;
            // 
            // btnAddSession
            // 
            btnAddSession.Location = new Point(1104, 40);
            btnAddSession.Name = "btnAddSession";
            btnAddSession.Size = new Size(205, 75);
            btnAddSession.TabIndex = 5;
            btnAddSession.Text = "Створити сеанс";
            btnAddSession.UseVisualStyleBackColor = true;
            // 
            // dgvSessions
            // 
            dgvSessions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSessions.Location = new Point(25, 25);
            dgvSessions.Name = "dgvSessions";
            dgvSessions.RowHeadersWidth = 62;
            dgvSessions.Size = new Size(1050, 400);
            dgvSessions.TabIndex = 0;
            // 
            // Tickets
            // 
            Tickets.Controls.Add(btnDeleteTicket);
            Tickets.Controls.Add(btnAddTicket);
            Tickets.Controls.Add(dgvTickets);
            Tickets.Location = new Point(4, 34);
            Tickets.Name = "Tickets";
            Tickets.Size = new Size(1342, 512);
            Tickets.TabIndex = 2;
            Tickets.Text = "Квитки";
            Tickets.UseVisualStyleBackColor = true;
            // 
            // btnDeleteTicket
            // 
            btnDeleteTicket.Location = new Point(1104, 140);
            btnDeleteTicket.Name = "btnDeleteTicket";
            btnDeleteTicket.Size = new Size(205, 75);
            btnDeleteTicket.TabIndex = 7;
            btnDeleteTicket.Text = "Скасувати квиток";
            btnDeleteTicket.UseVisualStyleBackColor = true;
            // 
            // btnAddTicket
            // 
            btnAddTicket.Location = new Point(1104, 40);
            btnAddTicket.Name = "btnAddTicket";
            btnAddTicket.Size = new Size(205, 75);
            btnAddTicket.TabIndex = 6;
            btnAddTicket.Text = "Оформити квиток";
            btnAddTicket.UseVisualStyleBackColor = true;
            // 
            // dgvTickets
            // 
            dgvTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTickets.Location = new Point(25, 25);
            dgvTickets.Name = "dgvTickets";
            dgvTickets.RowHeadersWidth = 62;
            dgvTickets.Size = new Size(1050, 400);
            dgvTickets.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 595);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Система кінотеатру";
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            Films.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovies).EndInit();
            Sessions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSessions).EndInit();
            Tickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTickets).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Films;
        private TabPage Sessions;
        private TabPage Tickets;
        private DataGridView dgvMovies;
        private DataGridView dgvSessions;
        private DataGridView dgvTickets;
        private Button btnDeleteMovie;
        private Button btnLoadJson;
        private Button btnSaveJson;
        private Button btnAddMovie;
        private Button btnDeleteSession;
        private Button btnAddSession;
        private Button btnDeleteTicket;
        private Button btnAddTicket;
    }
}
