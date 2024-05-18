namespace Snake
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnStart = new Button();
            btnPause = new Button();
            pictureBoxBoard = new PictureBox();
            label1 = new Label();
            labelScore = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoard).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.MediumAquamarine;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(37, 307);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(159, 56);
            btnStart.TabIndex = 1;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnPause
            // 
            btnPause.BackColor = Color.MediumAquamarine;
            btnPause.FlatStyle = FlatStyle.Flat;
            btnPause.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPause.ForeColor = Color.White;
            btnPause.Location = new Point(37, 427);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(159, 56);
            btnPause.TabIndex = 2;
            btnPause.Text = "PAUSE";
            btnPause.UseVisualStyleBackColor = false;
            btnPause.Click += btnPause_Click_1;
            // 
            // pictureBoxBoard
            // 
            pictureBoxBoard.BackColor = Color.DarkSlateGray;
            pictureBoxBoard.Location = new Point(239, 12);
            pictureBoxBoard.Name = "pictureBoxBoard";
            pictureBoxBoard.Size = new Size(720, 625);
            pictureBoxBoard.TabIndex = 3;
            pictureBoxBoard.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 39.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.MediumAquamarine;
            label1.Location = new Point(23, 122);
            label1.Name = "label1";
            label1.Size = new Size(195, 71);
            label1.TabIndex = 4;
            label1.Text = "SCORE";
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelScore.ForeColor = Color.MediumAquamarine;
            labelScore.Location = new Point(61, 193);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(107, 32);
            labelScore.TabIndex = 5;
            labelScore.Text = "0 points";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 45F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.MediumAquamarine;
            label2.Location = new Point(4, 9);
            label2.Name = "label2";
            label2.Size = new Size(229, 81);
            label2.TabIndex = 6;
            label2.Text = "SNAKE\r\n";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(971, 649);
            Controls.Add(label2);
            Controls.Add(labelScore);
            Controls.Add(label1);
            Controls.Add(pictureBoxBoard);
            Controls.Add(btnPause);
            Controls.Add(btnStart);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Snake";
            ((System.ComponentModel.ISupportInitialize)pictureBoxBoard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnStart;
        private Button btnPause;
        private PictureBox pictureBoxBoard;
        private Label label1;
        private Label labelScore;
        private Label label2;
    }
}