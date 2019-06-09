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
    public partial class SupplierPayments : Form
    {
        int _supplierId;
        public SupplierPayments(int supplierId)
        {
            _supplierId = supplierId;
            InitializeComponent();
        }

        private void SupplierPayments_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Entity.SupplierDuePayment supplierDuePayment = new Entity.SupplierDuePayment();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}