using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

            InitializeComponent();

            using (Context db = new Context())
            {
                foreach (var item in db.Films.Where(f => f.End_Rental.Date < DateTime.Now.Date))
                    db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();

                Update_Film_List();
            }
            
            add_film.Click += Add_film_Click;

            film_name_container.MouseEnter += Film_name_container_MouseEnter;
            film_name_config_container.MouseLeave += Film_name_config_container_MouseLeave;
            director_container.MouseEnter += Director_container_MouseEnter;
            director_config_container.MouseLeave += Director_config_container_MouseLeave;
            release_date_container.MouseEnter += Release_date_container_MouseEnter;
            release_date_config_container.MouseLeave += Release_date_config_container_MouseLeave;
            genre_container.MouseEnter += Genre_container_MouseEnter;
            genre_config_container.MouseLeave += Genre_config_container_MouseLeave;

            film_name_search_textbox.TextChanged += Film_name_search_textbox_TextChanged;
            director_search_textbox.TextChanged += Director_search_textbox_TextChanged;
            release_date_search_textbox.TextChanged += Release_date_search_textbox_TextChanged;
            genre_search_textbox.TextChanged += Genre_search_textbox_TextChanged;

            film_name_sort_button.Click += Film_name_sort_button_Click;
            director_sort_button.Click += Director_sort_button_Click;
            release_date_sort_button.Click += Release_date_sort_button_Click;
            genre_sort_button.Click += Genre_sort_button_Click;
        }
        // Сортировка по жанру
        private void Genre_sort_button_Click(object sender, RoutedEventArgs e)
        {
            SelectSortModal select_sort = new SelectSortModal("По алфавиту", "Обратный", new Action<bool, bool>(save_sorting));
            select_sort.ShowDialog();
            void save_sorting(bool ascending, bool descending)
            {
                using (Context db = new Context())
                {
                    if (ascending)
                        Show_Film_List(db.Films.OrderBy(f => f.Genre).ToList());
                    else if (descending)
                        Show_Film_List(db.Films.OrderByDescending(f => f.Genre).ToList());
                }

            }
        }
        // Сортировка по дате выхода
        private void Release_date_sort_button_Click(object sender, RoutedEventArgs e)
        {
            SelectSortModal select_sort = new SelectSortModal("По возрастанию", "По убыванию", new Action<bool, bool>(save_sorting));
            select_sort.ShowDialog();
            void save_sorting(bool ascending, bool descending)
            {
                using (Context db = new Context())
                {
                    if (ascending)
                        Show_Film_List(db.Films.OrderBy(f => f.Release_Date).ToList());
                    else if (descending)
                        Show_Film_List(db.Films.OrderByDescending(f => f.Release_Date).ToList());
                }

            }
        }
        // Сортитровка по режиссёру
        private void Director_sort_button_Click(object sender, RoutedEventArgs e)
        {
            SelectSortModal select_sort = new SelectSortModal("По алфавиту", "Обратный", new Action<bool, bool>(save_sorting));
            select_sort.ShowDialog();
            void save_sorting(bool ascending, bool descending)
            {
                using (Context db = new Context())
                {
                    if (ascending)
                        Show_Film_List(db.Films.OrderBy(f => f.Director).ToList());
                    else if (descending)
                        Show_Film_List(db.Films.OrderByDescending(f => f.Director).ToList());
                }

            }
        }
        // Сортировка по названию фильма
        private void Film_name_sort_button_Click(object sender, RoutedEventArgs e)
        {
            SelectSortModal select_sort = new SelectSortModal("По алфавиту", "Обратный", new Action<bool, bool>(save_sorting));
            select_sort.ShowDialog();
            void save_sorting(bool ascending, bool descending)
            {
                using(Context db = new Context())
                {
                    if (ascending)
                        Show_Film_List(db.Films.OrderBy(f => f.Name).ToList());
                    else if(descending)
                        Show_Film_List(db.Films.OrderByDescending(f => f.Name).ToList());
                }
                
            }
        }
        // Поиск по жанру
        private void Genre_search_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (Context db = new Context())
            {
                Show_Film_List(db.Films.Where(f => f.Genre.StartsWith(genre_search_textbox.Text)).ToList());
            }
        }
        // Поиск по дате выхода
        private void Release_date_search_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (Context db = new Context())
            {
                Show_Film_List(db.Films.Where(f => f.Release_Date.StartsWith(release_date_search_textbox.Text)).ToList());
            }
        }
        // Поиск по режиссёру
        private void Director_search_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (Context db = new Context())
            {
                Show_Film_List(db.Films.Where(f => f.Director.StartsWith(director_search_textbox.Text)).ToList());
            }
        }
        // Поиск по названию фильма
        private void Film_name_search_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (Context db = new Context())
            {
                Show_Film_List(db.Films.Where(f => f.Name.StartsWith(film_name_search_textbox.Text)).ToList());
            }
        }

        #region Mouse_Enter_Leave_Actions
        private void Genre_config_container_MouseLeave(object sender, MouseEventArgs e)
        {
            genre_config_container.Visibility = Visibility.Hidden;
            genre_container.Visibility = Visibility.Visible;
        }

        private void Genre_container_MouseEnter(object sender, MouseEventArgs e)
        {
            genre_config_container.Visibility = Visibility.Visible;
            genre_container.Visibility = Visibility.Hidden;
        }

        private void Release_date_config_container_MouseLeave(object sender, MouseEventArgs e)
        {
            release_date_config_container.Visibility = Visibility.Hidden;
            release_date_container.Visibility = Visibility.Visible;
        }

        private void Release_date_container_MouseEnter(object sender, MouseEventArgs e)
        {
            release_date_config_container.Visibility = Visibility.Visible;
            release_date_container.Visibility = Visibility.Hidden;
        }

        private void Director_config_container_MouseLeave(object sender, MouseEventArgs e)
        {
            director_config_container.Visibility = Visibility.Hidden;
            director_container.Visibility = Visibility.Visible;
        }

        private void Director_container_MouseEnter(object sender, MouseEventArgs e)
        {
            director_config_container.Visibility = Visibility.Visible;
            director_container.Visibility = Visibility.Hidden;
        }

        private void Film_name_config_container_MouseLeave(object sender, MouseEventArgs e)
        {
            film_name_container.Visibility = Visibility.Visible;
            film_name_config_container.Visibility = Visibility.Hidden;
        }

        private void Film_name_container_MouseEnter(object sender, MouseEventArgs e)
        {
            film_name_container.Visibility = Visibility.Hidden;
            film_name_config_container.Visibility = Visibility.Visible;
        }
        #endregion
        private void Add_film_Click(object sender, RoutedEventArgs e)
        {
            AddFilmModal add_film_modal = new AddFilmModal(new Action(Update_Film_List));
            add_film_modal.ShowDialog();
        }

        private void Show_Film_List(List<Film> films)
        {
            films_list.Children.Clear();
            foreach (var item in films.Where(f => f.End_Rental.Date >= DateTime.Now.Date))
                films_list.Children.Add(new FilmMiniView(item, new Action<Film>(Open_Film_Info)));
        }
        // Обновление списка фильмов
        private void Update_Film_List()
        {
            using (Context db = new Context())
            {
                films_list.Children.Clear();
                foreach (var item in db.Films.Where(f => f.End_Rental.Date >= DateTime.Now.Date).OrderBy(f=>f.Name).ToList())
                    films_list.Children.Add(new FilmMiniView(item, new Action<Film>(Open_Film_Info)));
            }
        }

        private void Open_Film_Info(Film film)
        {
            film_list_container.Visibility = Visibility.Hidden;
            film_info_container.Visibility = Visibility.Visible;
            film_info_container.Children.Clear();
            film_info_container.Children.Add(new FilmView(film, new Action(Open_Film_List)));
        }

        private void Open_Film_List()
        {
            Update_Film_List();
            film_list_container.Visibility = Visibility.Visible;
            film_info_container.Visibility = Visibility.Hidden;
        }

        private void add_film_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
