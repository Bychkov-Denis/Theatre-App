using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для EditFilmModal.xaml
    /// </summary>
    public partial class EditFilmModal : Window
    {
        Action update_film;
        Film film;
        public EditFilmModal(Film film, Action update_film)
        {
            this.film = film;
            this.update_film = update_film;
            InitializeComponent();

            film_name.Text = film.Name;
            genre.Text = film.Genre;
            director.Text = film.Director;
            release_date.Text = film.Release_Date;
            start_rental.SelectedDate = film.Start_Rental;
            end_rental.SelectedDate = film.End_Rental;

            start_rental.DisplayDateStart = DateTime.Now;
            end_rental.DisplayDateStart = DateTime.Now;
            release_date.PreviewTextInput += Release_date_PreviewTextInput;
            edit_film.Click += Edit_film_Click;
        }
        private void Release_date_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
        // Редактирование фильма
        private void Edit_film_Click(object sender, RoutedEventArgs e)
        {
            int release_date_value;
            if (int.TryParse(release_date.Text, out release_date_value)
                && release_date_value > 1895
                && release_date_value < DateTime.Now.Year
                && film_name.Text.Length > 3
                && director.Text.Length > 3
                && genre.Text.Length > 2
            )
            {
                using (Context db = new Context())
                {
                    Film new_film = new Film
                    {
                        Id = film.Id,
                        Name = film_name.Text,
                        Director = director.Text,
                        Genre = genre.Text,
                        Release_Date = release_date.Text,
                        Start_Rental = start_rental.SelectedDate.Value,
                        End_Rental = end_rental.SelectedDate.Value
                    };
                    db.Entry(new_film).State = EntityState.Modified;
                    db.SaveChanges();
                }
                update_film.Invoke();
                Close();
            }
            release_date_error.Content = $"Число должно быть от 1895 до {DateTime.Now.Year}";
        }
    }
}
