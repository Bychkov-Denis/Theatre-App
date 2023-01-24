using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class FilmView : UserControl
    {
        Action open_film_list;
        Film film;
        public FilmView(Film film_for_view, Action open_film_list)
        {
            film = film_for_view;
            this.open_film_list = open_film_list;
            InitializeComponent();
            back_to_film_list.Click += Back_to_film_list_Click;
            film_name.Content = film.Name;
            genre.Content = film.Genre;
            director.Content = film.Director;
            release_date.Content = film.Release_Date;
            start_rental.Content = film.Start_Rental;
            end_rental.Content = film.End_Rental;
            add_session.Click += Add_session_Click;
            edit_film.Click += Edit_film_Click;
            delete_film.Click += Delete_film_Click;

            using(Context db = new Context())
            {
                foreach (var item in db.Sessions.Where(f=>f.FilmId.Equals(film.Id)))
                    session_list.Children.Add(new SessionView(item));
            }
        }
        // Удаление фильма
        private void Delete_film_Click(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                db.Entry(film).State = EntityState.Deleted;
                db.SaveChanges();
                open_film_list.Invoke();
            }
        }

        private void Edit_film_Click(object sender, RoutedEventArgs e)
        {
            EditFilmModal edit_film_modal = new EditFilmModal(film, new Action(Update_film_info));
            edit_film_modal.ShowDialog();
        }
        // Редактирование фильма
        private void Update_film_info()
        {
            using(Context db = new Context())
            {
                Film update_film = db.Films.FirstOrDefault(f => f.Id.Equals(film.Id));
                film = update_film;
                film_name.Content = film.Name;
                genre.Content = film.Genre;
                director.Content = film.Director;
                release_date.Content = film.Release_Date;
                start_rental.Content = film.Start_Rental;
                end_rental.Content = film.End_Rental;
            }
        }
        // Добавление сеанса
        private void Add_session_Click(object sender, RoutedEventArgs e)
        {
            AddSessionModal add_session_modal = new AddSessionModal(film, new Action(Update_Session_List));
            add_session_modal.ShowDialog();
        }
        // Обновление списка сеансов
        private void Update_Session_List()
        {
            session_list.Children.Clear();
            using(Context db = new Context())
            {
                foreach (var item in db.Sessions.Where(s=>s.FilmId.Equals(film.Id)))
                    session_list.Children.Add(new SessionView(item));
            }         
        }
        // Возврат к главной форме
        private void Back_to_film_list_Click(object sender, RoutedEventArgs e)
        {
            open_film_list.Invoke();
        }
    }
}
