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
    /// Логика взаимодействия для SessionView.xaml
    /// </summary>
    public partial class SessionView : UserControl
    {
        public SessionView(Session session)
        {
            InitializeComponent();
            date.Content = $"{session.Date.ToShortDateString()} {session.Date.ToShortTimeString()}" ;
            tickets_count.Content = session.Tickets_Count;

        }
    }
}
