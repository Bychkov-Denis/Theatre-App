using System;
using System.Collections.Generic;
using System.Text;

namespace WPF
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Release_Date { get; set; }
        public string Genre { get; set; }
        public DateTime Start_Rental { get; set; }
        public DateTime End_Rental { get; set; }
        public List<Session> Sessions { get; set; } = new List<Session>();
    }
}
