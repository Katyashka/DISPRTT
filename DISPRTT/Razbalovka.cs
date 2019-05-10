using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DISPRTT
{
    public partial class Razbalovka : Form
    {
        Predmet prd;
        public Razbalovka(Predmet predmet)
        {
            prd = predmet;
            InitializeComponent();
        }
    }
}
