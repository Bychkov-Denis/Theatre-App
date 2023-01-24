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
    /// Логика взаимодействия для AddFilmModal.xaml
    /// </summary>
    public partial class AddFilmModal : Window
    {
        Action update_film_list;
        public AddFilmModal(Action update_film_list)
        {
            this.update_film_list = update_film_list;
            InitializeComponent();
            start_rental.DisplayDateStart = DateTime.Now;
            end_rental.DisplayDateStart = DateTime.Now;
            start_rental.SelectedDate = DateTime.Now;
            end_rental.SelectedDate = DateTime.Now;

            director.PreviewTextInput += Director_PreviewTextInput;
            release_date.PreviewTextInput += Release_date_PreviewTextInput;
            add_film.Click += Add_film_Click;
        }
        // Проверка данных при вводе режиссёра
        private void Director_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsWhiteSpace(e.Text, 0) && !char.IsLetter(e.Text, 0))
                e.Handled = true;
        }
        // Проверка данных при вводе даты выхода фильма
        private void Release_date_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
        // Добавление фильма
        private void Add_film_Click(object sender, RoutedEventArgs e)
        {
            int release_date_value;
            if(int.TryParse(release_date.Text, out release_date_value) 
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
                        Name = film_name.Text,
                        Director = director.Text,
                        Genre = genre.Text,
                        Release_Date = release_date.Text,
                        Start_Rental = start_rental.SelectedDate.Value,
                        End_Rental = end_rental.SelectedDate.Value
                    };
                    db.Films.Add(new_film);
                    db.SaveChanges();
                }
                update_film_list.Invoke();
                Close();
            }

            release_date_error.Content = "";

            if(release_date_value < 1895 || release_date_value > DateTime.Now.Year)
                release_date_error.Content = $"Число должно быть от 1895 до {DateTime.Now.Year}";
        }

    }
}
