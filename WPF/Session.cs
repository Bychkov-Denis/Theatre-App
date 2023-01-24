using System;
using System.Collections.Generic;
using System.Text;

namespace WPF
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int Tickets_Count { get; set; }
    }
}
