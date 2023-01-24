using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cursovaya
{
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();
            film_list.RowCount = 1;
            film_list.Controls.Add(new FilmView(film_list.Width));
            Update();
        }
    }
}
