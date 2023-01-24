using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cursovaya
{
    public class Context : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public Context():base("DefaultConnection")
        {

        }
    }
}
