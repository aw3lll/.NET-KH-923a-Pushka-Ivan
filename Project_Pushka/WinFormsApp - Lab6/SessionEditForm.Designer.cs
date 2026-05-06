
namespace WinFormsApp___Lab6
{
    partial class SessionEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbMovies = new ComboBox();
            dtpTime = new DateTimePicker();
            txtHall = new TextBox();
            numPrice = new NumericUpDown();
            numSeats = new NumericUpDown();
            chkIsVip = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSeats).BeginInit();
            SuspendLayout();
            // 
            // cmbMovies
            // 
            cmbMovies.FormattingEnabled = true;
            cmbMovies.Location = new Point(179, 62);
            cmbMovies.Name = "cmbMovies";
            cmbMovies.Size = new Size(177, 33);
            cmbMovies.TabIndex = 0;
            // 
            // dtpTime
            // 
            dtpTime.Location = new Point(179, 168);
            dtpTime.Name = "dtpTime";
            dtpTime.Size = new Size(177, 31);
            dtpTime.TabIndex = 1;
            // 
            // txtHall
            // 
            txtHall.Location = new Point(179, 116);
            txtHall.Name = "txtHall";
            txtHall.Size = new Size(177, 31);
            txtHall.TabIndex = 2;
            // 
            // numPrice
            // 
            numPrice.Location = new Point(179, 221);
            numPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numPrice.Minimum = new decimal(new int[] { 150, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(177, 31);
            numPrice.TabIndex = 3;
            numPrice.Value = new decimal(new int[] { 150, 0, 0, 0 });
            numPrice.ValueChanged += numPrice_ValueChanged;
            // 
            // numSeats
            // 
            numSeats.Location = new Point(179, 267);
            numSeats.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numSeats.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            numSeats.Name = "numSeats";
            numSeats.Size = new Size(177, 31);
            numSeats.TabIndex = 4;
            numSeats.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // chkIsVip
            // 
            chkIsVip.AutoSize = true;
            chkIsVip.Location = new Point(228, 322);
            chkIsVip.Name = "chkIsVip";
            chkIsVip.Size = new Size(65, 29);
            chkIsVip.TabIndex = 5;
            chkIsVip.Text = "Так";
            chkIsVip.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(46, 370);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(148, 34);
            btnSave.TabIndex = 6;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(209, 370);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(147, 34);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 62);
            label1.Name = "label1";
            label1.Size = new Size(60, 25);
            label1.TabIndex = 8;
            label1.Text = "Фільм";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 116);
            label2.Name = "label2";
            label2.Size = new Size(40, 25);
            label2.TabIndex = 9;
            label2.Text = "Зал";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 170);
            label3.Name = "label3";
            label3.Size = new Size(119, 25);
            label3.TabIndex = 10;
            label3.Text = "Дата початку";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 221);
            label4.Name = "label4";
            label4.Size = new Size(77, 25);
            label4.TabIndex = 11;
            label4.Text = "Вартість";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 271);
            label5.Name = "label5";
            label5.Size = new Size(131, 25);
            label5.TabIndex = 12;
            label5.Text = "Кількість місць";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 322);
            label6.Name = "label6";
            label6.Size = new Size(77, 25);
            label6.TabIndex = 13;
            label6.Text = "VIP зал?";
            // 
            // SessionEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 453);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkIsVip);
            Controls.Add(numSeats);
            Controls.Add(numPrice);
            Controls.Add(txtHall);
            Controls.Add(dtpTime);
            Controls.Add(cmbMovies);
            Name = "SessionEditForm";
            Text = "SessionEditForm";
            Load += SessionEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSeats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ComboBox cmbMovies;
        private DateTimePicker dtpTime;
        private TextBox txtHall;
        private NumericUpDown numPrice;
        private NumericUpDown numSeats;
        private CheckBox chkIsVip;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}