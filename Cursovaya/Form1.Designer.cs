
namespace Cursovaya
{
    partial class main_form
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
            this.film_list = new System.Windows.Forms.TableLayoutPanel();
            this.add_film = new System.Windows.Forms.Button();
            this.edit_film = new System.Windows.Forms.Button();
            this.delete_film = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // film_list
            // 
            this.film_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.film_list.ColumnCount = 1;
            this.film_list.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.film_list.Location = new System.Drawing.Point(12, 12);
            this.film_list.Name = "film_list";
            this.film_list.RowCount = 1;
            this.film_list.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 595F));
            this.film_list.Size = new System.Drawing.Size(952, 559);
            this.film_list.TabIndex = 0;
            // 
            // add_film
            // 
            this.add_film.Location = new System.Drawing.Point(13, 584);
            this.add_film.Name = "add_film";
            this.add_film.Size = new System.Drawing.Size(116, 23);
            this.add_film.TabIndex = 1;
            this.add_film.Text = "Add film";
            this.add_film.UseVisualStyleBackColor = true;
            // 
            // edit_film
            // 
            this.edit_film.Location = new System.Drawing.Point(412, 584);
            this.edit_film.Name = "edit_film";
            this.edit_film.Size = new System.Drawing.Size(116, 23);
            this.edit_film.TabIndex = 2;
            this.edit_film.Text = "Edit film";
            this.edit_film.UseVisualStyleBackColor = true;
            // 
            // delete_film
            // 
            this.delete_film.Location = new System.Drawing.Point(848, 584);
            this.delete_film.Name = "delete_film";
            this.delete_film.Size = new System.Drawing.Size(116, 23);
            this.delete_film.TabIndex = 3;
            this.delete_film.Text = "Delete film";
            this.delete_film.UseVisualStyleBackColor = true;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 619);
            this.Controls.Add(this.delete_film);
            this.Controls.Add(this.edit_film);
            this.Controls.Add(this.add_film);
            this.Controls.Add(this.film_list);
            this.Name = "main_form";
            this.Text = "Кинотеатр";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel film_list;
        private System.Windows.Forms.Button add_film;
        private System.Windows.Forms.Button edit_film;
        private System.Windows.Forms.Button delete_film;
    }
}

