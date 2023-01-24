
namespace Cursovaya
{
    partial class FilmView
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.film_name = new System.Windows.Forms.Label();
            this.director = new System.Windows.Forms.Label();
            this.release_date = new System.Windows.Forms.Label();
            this.genre = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // film_name
            // 
            this.film_name.AutoSize = true;
            this.film_name.Location = new System.Drawing.Point(3, 0);
            this.film_name.Name = "film_name";
            this.film_name.Size = new System.Drawing.Size(54, 13);
            this.film_name.TabIndex = 0;
            this.film_name.Text = "film_name";
            this.film_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // director
            // 
            this.director.AutoSize = true;
            this.director.Location = new System.Drawing.Point(145, 0);
            this.director.Name = "director";
            this.director.Size = new System.Drawing.Size(35, 13);
            this.director.TabIndex = 1;
            this.director.Text = "label2";
            this.director.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // release_date
            // 
            this.release_date.AutoSize = true;
            this.release_date.Location = new System.Drawing.Point(104, 0);
            this.release_date.Name = "release_date";
            this.release_date.Size = new System.Drawing.Size(35, 13);
            this.release_date.TabIndex = 2;
            this.release_date.Text = "label2";
            this.release_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // genre
            // 
            this.genre.AutoSize = true;
            this.genre.Location = new System.Drawing.Point(63, 0);
            this.genre.Name = "genre";
            this.genre.Size = new System.Drawing.Size(35, 13);
            this.genre.TabIndex = 3;
            this.genre.Text = "label2";
            this.genre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.film_name);
            this.flowLayoutPanel1.Controls.Add(this.genre);
            this.flowLayoutPanel1.Controls.Add(this.release_date);
            this.flowLayoutPanel1.Controls.Add(this.director);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(704, 40);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // FilmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FilmView";
            this.Size = new System.Drawing.Size(704, 40);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label film_name;
        private System.Windows.Forms.Label director;
        private System.Windows.Forms.Label release_date;
        private System.Windows.Forms.Label genre;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
