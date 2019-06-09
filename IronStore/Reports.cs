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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OrderByCustomer orderByCustomer = new OrderByCustomer();
            orderByCustomer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrderByDate orderByDate = new OrderByDate();
            orderByDate.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PendingCustomerPayments pendingCustomerPayment = new PendingCustomerPayments();
            pendingCustomerPayment.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PendingOrders pendingOrder = new PendingOrders();
            pendingOrder.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PositiveBalanceCustomer positiveBalance = new PositiveBalanceCustomer();
            positiveBalance.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewCustomerPayment customerPayments = new ViewCustomerPayment();
            customerPayments.Show();
        }
    }
}
