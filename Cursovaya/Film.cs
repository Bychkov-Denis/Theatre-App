using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursovaya
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime Release_Date { get; set; }
        public string Genre { get; set; }
        public List<Session> Sessions { get; set; } = new List<Session>();
        public Film()
        {

        }
    }
}
