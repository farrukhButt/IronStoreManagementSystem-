using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronStore.Entity;
using IronStore.Helpers;

namespace IronStore
{
    public partial class PositiveBalanceCustomer : Form
    {
        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();

        public PositiveBalanceCustomer()
        {
            InitializeComponent();
        }

    

        private int LoadDuePayments(int customerId, int stationCustomerId)
        {

            var OrderPayments = (int?)db.OrderLines.Where(aa => aa.Order.CustomerId == customerId && aa.Order.StationCustomerId==stationCustomerId).Select(aa => aa.PricePerUnit * aa.WeightInKg).Sum();

            if (OrderPayments == null)
            {
                OrderPayments = 0;
            }

            int paymentmadeCount = db.OrderPaymentMades.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId == stationCustomerId)
                .Select(aa => aa.PaymentMade).Count();

            int paymentsMade = 0;
            if (paymentmadeCount > 0)
            {
                paymentsMade = db.OrderPaymentMades.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId == stationCustomerId)
                .Select(aa => aa.PaymentMade).Sum();
            }

            int OrderPaymentDue = 0;

            OrderPaymentDue = (int)OrderPayments - paymentsMade;

            return OrderPaymentDue;
        }

        private async void LoadButton_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            await Task.Yield();


            var customersIds = db.Customers.Select(ss => new
            {

                customerId = ss.CustomerId,
                stationCustomerId = ss.StationCustomerId
            }
                );

            List<customerPayments> customerPaymentsList = new List<customerPayments>();

            foreach (var custId in customersIds)
            {
                int duePayment = LoadDuePayments(custId.customerId,custId.stationCustomerId);
                if (duePayment < 0)
                {
                    customerPayments custPayment = new customerPayments();
                    custPayment.CustomerName = db.Customers.Where(aa => aa.CustomerId == custId.customerId && aa.StationCustomerId == custId.stationCustomerId).FirstOrDefault().Name;
                    custPayment.JoinedCustomerId = StationIdHelper.StationIdJoined(custId.stationCustomerId, custId.customerId);
                    custPayment.DuePayment = duePayment;
                    customerPaymentsList.Add(custPayment);
                }


            }

            dataGridView1.DataSource = customerPaymentsList;
            label1.Visible = false;
        }
    }
}
