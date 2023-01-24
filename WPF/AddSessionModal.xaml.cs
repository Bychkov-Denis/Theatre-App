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
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для AddSessionModal.xaml
    /// </summary>
    public partial class AddSessionModal : Window
    {
        Film film;
        Action update_session_list;
        public AddSessionModal(Film film, Action update_session_list)
        {
            this.film = film;
            this.update_session_list = update_session_list;
            InitializeComponent();

            tickets_count.PreviewTextInput += Tickets_count_PreviewTextInput;
            add_session.Click += Add_session_Click;
        }

        private void Tickets_count_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
        // Добавление сеанса для фильма
        private void Add_session_Click(object sender, RoutedEventArgs e)
        {
            int tickets_count_value;
            if(int.TryParse(tickets_count.Text, out tickets_count_value)
                && tickets_count_value > 0
                && DateTime.Parse(session_date.Text) >= DateTime.Now
            )
            {
                using (Context db = new Context())
                {
                    Film film_entity = db.Films.Include(f => f.Sessions).FirstOrDefault(f => f.Id.Equals(film.Id));
                    if (film_entity != null)
                    {
                        Session new_session = new Session
                        {
                            Date = DateTime.Parse(session_date.Text),
                            Tickets_Count = int.Parse(tickets_count.Text),
                            FilmId = film_entity.Id,
                            Film = film_entity
                        };
                        film_entity.Sessions.Add(new_session);
                        db.SaveChanges();
                    }
                }
                update_session_list.Invoke();
                Close();
            }

            session_date_error.Visibility = Visibility.Collapsed;
            tickets_count_error.Visibility = Visibility.Collapsed;

            if (tickets_count_value < 1)
                tickets_count_error.Visibility = Visibility.Visible;
            if (DateTime.Parse(session_date.Text) < DateTime.Now)
                session_date_error.Visibility = Visibility.Visible;
        }
    }
}
