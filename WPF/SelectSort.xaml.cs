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
    public partial class SelectSortModal : Window
    {
        Action<bool, bool> save_sorting;
        public SelectSortModal(string asceding_name, string descending_name, Action<bool,bool> save_sorting)
        {
            this.save_sorting = save_sorting;
            InitializeComponent();
            ascending.Content = asceding_name;
            descending.Content = descending_name;
            save.Click += Save_Click;
        }
        // Сохранение изменений после сортировки
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            save_sorting.Invoke(ascending.IsChecked.Value, descending.IsChecked.Value);
            Close();
        }
    }
}
