
namespace WinFormsApp___Lab6
{
    partial class MovieEditForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            txtTitle = new TextBox();
            numDuration = new NumericUpDown();
            numRating = new NumericUpDown();
            txtGenre = new TextBox();
            chkIs3D = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 26);
            label1.Name = "label1";
            label1.Size = new Size(122, 25);
            label1.TabIndex = 0;
            label1.Text = "Назва фільму";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 82);
            label2.Name = "label2";
            label2.Size = new Size(131, 25);
            label2.TabIndex = 1;
            label2.Text = "Тривалість (хв)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 129);
            label3.Name = "label3";
            label3.Size = new Size(75, 25);
            label3.TabIndex = 2;
            label3.Text = "Рейтинг";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 179);
            label4.Name = "label4";
            label4.Size = new Size(58, 25);
            label4.TabIndex = 3;
            label4.Text = "Жанр";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 224);
            label5.Name = "label5";
            label5.Size = new Size(43, 25);
            label5.TabIndex = 4;
            label5.Text = "3D?";
            label5.Click += label5_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(63, 262);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 5;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(202, 262);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Скасувати";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(184, 26);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(180, 31);
            txtTitle.TabIndex = 7;
            // 
            // numDuration
            // 
            numDuration.Location = new Point(184, 82);
            numDuration.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            numDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(180, 31);
            numDuration.TabIndex = 8;
            numDuration.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numRating
            // 
            numRating.Location = new Point(184, 129);
            numRating.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(180, 31);
            numRating.TabIndex = 9;
            numRating.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(184, 176);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(180, 31);
            txtGenre.TabIndex = 10;
            // 
            // chkIs3D
            // 
            chkIs3D.AutoSize = true;
            chkIs3D.Location = new Point(249, 224);
            chkIs3D.Name = "chkIs3D";
            chkIs3D.Size = new Size(65, 29);
            chkIs3D.TabIndex = 11;
            chkIs3D.Text = "Так";
            chkIs3D.UseVisualStyleBackColor = true;
            // 
            // MovieEditForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 325);
            Controls.Add(chkIs3D);
            Controls.Add(txtGenre);
            Controls.Add(numRating);
            Controls.Add(numDuration);
            Controls.Add(txtTitle);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MovieEditForm";
            Text = "MovieEditForm";
            Load += MovieEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtTitle;
        private NumericUpDown numDuration;
        private NumericUpDown numRating;
        private TextBox txtGenre;
        private CheckBox chkIs3D;
    }
}