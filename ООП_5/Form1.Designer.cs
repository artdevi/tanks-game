namespace ООП_5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer_sec = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_hp = new System.Windows.Forms.Label();
            this.label_press = new System.Windows.Forms.Label();
            this.label_gameover = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 70;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timer_sec
            // 
            this.timer_sec.Enabled = true;
            this.timer_sec.Interval = 1000;
            this.timer_sec.Tick += new System.EventHandler(this.timer_sec_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(61, 618);
            this.progressBar1.Maximum = 3000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(257, 30);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Value = 3000;
            // 
            // label_hp
            // 
            this.label_hp.AutoSize = true;
            this.label_hp.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_hp.Location = new System.Drawing.Point(12, 618);
            this.label_hp.Name = "label_hp";
            this.label_hp.Size = new System.Drawing.Size(43, 28);
            this.label_hp.TabIndex = 2;
            this.label_hp.Text = "HP";
            // 
            // label_press
            // 
            this.label_press.AutoSize = true;
            this.label_press.BackColor = System.Drawing.Color.DarkKhaki;
            this.label_press.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_press.Location = new System.Drawing.Point(202, 110);
            this.label_press.Name = "label_press";
            this.label_press.Size = new System.Drawing.Size(226, 28);
            this.label_press.TabIndex = 3;
            this.label_press.Text = "Press SPACE to start";
            // 
            // label_gameover
            // 
            this.label_gameover.AutoSize = true;
            this.label_gameover.BackColor = System.Drawing.Color.DarkKhaki;
            this.label_gameover.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_gameover.Location = new System.Drawing.Point(199, 48);
            this.label_gameover.Name = "label_gameover";
            this.label_gameover.Size = new System.Drawing.Size(229, 50);
            this.label_gameover.TabIndex = 4;
            this.label_gameover.Text = "Game Over";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 653);
            this.Controls.Add(this.label_gameover);
            this.Controls.Add(this.label_press);
            this.Controls.Add(this.label_hp);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Есть пробитие!";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer_sec;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_hp;
        private System.Windows.Forms.Label label_press;
        private System.Windows.Forms.Label label_gameover;
    }
}

