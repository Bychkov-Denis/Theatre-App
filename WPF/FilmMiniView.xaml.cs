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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для FilmView.xaml
    /// </summary>
    public partial class FilmMiniView : UserControl
    {
        Film film;
        Action<Film> open_full_info;
        public FilmMiniView(Film film, Action<Film> open_full_info)
        {
            this.film = film;
            this.open_full_info = open_full_info;
            InitializeComponent();
            container.MouseDown += Container_MouseDown;
            film_name.Content = film.Name;
            director.Content = film.Director;
            release_date.Content = film.Release_Date;
            genre.Content = film.Genre;
            // Проверка на начало проката фильма
            if (film.Start_Rental > DateTime.Now)
                container.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            //foreach (var item in film.Sessions)
            //    sessions_list.Children.Add(new SessionView(item));
        }

        private void Container_MouseDown(object sender, MouseButtonEventArgs e)
        {
            open_full_info.Invoke(film);
        }
    }
}
