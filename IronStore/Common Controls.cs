using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronStore
{
    public partial class Common_Controls : Form
    {
        public Common_Controls()
        {
            InitializeComponent();
        }

        private void Common_Controls_Load(object sender, EventArgs e)
        {
            numericUpDown1.Select(0,numericUpDown1.Text.Length);
        }
    }
}
