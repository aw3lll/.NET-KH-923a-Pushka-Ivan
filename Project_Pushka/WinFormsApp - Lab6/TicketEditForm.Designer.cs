
namespace WinFormsApp___Lab6
{
    partial class TicketEditForm
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
            cmbSessions = new ComboBox();
            txtCustomer = new TextBox();
            numRow = new NumericUpDown();
            numSeat = new NumericUpDown();
            chkIsPaid = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numRow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSeat).BeginInit();
            SuspendLayout();
            // 
            // cmbSessions
            // 
            cmbSessions.FormattingEnabled = true;
            cmbSessions.Location = new Point(107, 32);
            cmbSessions.Name = "cmbSessions";
            cmbSessions.Size = new Size(182, 33);
            cmbSessions.TabIndex = 0;
            // 
            // txtCustomer
            // 
            txtCustomer.Location = new Point(107, 86);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(182, 31);
            txtCustomer.TabIndex = 1;
            // 
            // numRow
            // 
            numRow.Location = new Point(107, 143);
            numRow.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            numRow.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRow.Name = "numRow";
            numRow.Size = new Size(180, 31);
            numRow.TabIndex = 2;
            numRow.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numSeat
            // 
            numSeat.Location = new Point(107, 197);
            numSeat.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numSeat.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSeat.Name = "numSeat";
            numSeat.Size = new Size(180, 31);
            numSeat.TabIndex = 3;
            numSeat.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chkIsPaid
            // 
            chkIsPaid.AutoSize = true;
            chkIsPaid.Location = new Point(166, 251);
            chkIsPaid.Name = "chkIsPaid";
            chkIsPaid.Size = new Size(65, 29);
            chkIsPaid.TabIndex = 4;
            chkIsPaid.Text = "Так";
            chkIsPaid.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 32);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 5;
            label1.Text = "Сеанс";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 84);
            label2.Name = "label2";
            label2.Size = new Size(43, 25);
            label2.TabIndex = 6;
            label2.Text = "Ім'я";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 143);
            label3.Name = "label3";
            label3.Size = new Size(41, 25);
            label3.TabIndex = 7;
            label3.Text = "Ряд";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 197);
            label4.Name = "label4";
            label4.Size = new Size(60, 25);
            label4.TabIndex = 8;
            label4.Text = "Місце";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 251);
            label5.Name = "label5";
            label5.Size = new Size(111, 25);
            label5.TabIndex = 9;
            label5.Text = "Оплачений?";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(40, 302);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 34);
            btnSave.TabIndex = 10;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(193, 302);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(136, 34);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // TicketEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 396);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chkIsPaid);
            Controls.Add(numSeat);
            Controls.Add(numRow);
            Controls.Add(txtCustomer);
            Controls.Add(cmbSessions);
            Name = "TicketEditForm";
            Text = "TicketEditForm";
            Load += TicketEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)numRow).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSeat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ComboBox cmbSessions;
        private TextBox txtCustomer;
        private NumericUpDown numRow;
        private NumericUpDown numSeat;
        private CheckBox chkIsPaid;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSave;
        private Button btnCancel;
    }
}