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
    public partial class AddOrderPayment : Form
    {
        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();

        Customer customer;

        public AddOrderPayment(string joinedCustomerId)
        {
            InitializeComponent();
            InitializeValue(joinedCustomerId);

        }

        private void InitializeValue(string joinedCustomerId)
        {
            var customerIds = StationIdHelper.SeperateStationId(joinedCustomerId);
            
            int customerId = int.Parse(customerIds[1]);
            int stationCustomerId = int.Parse(customerIds[0]);

            customer = db.Customers.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId == stationCustomerId).FirstOrDefault();
            CustomerLabel.Text = customer.Name;

            var duePay = LoadPreviousBill();
            int duePayment = 0;
            if (duePay != null)
            {
                duePayment =(int) duePay;
            }

            DueAmountField.Value = duePayment;

        }

        private int? LoadPreviousBill()
        {
            int customerId = customer.CustomerId;
            int stationCustomerId = customer.StationCustomerId;

            var OrderPaymentsDue = (int?)db.OrderLines.Where(aa => aa.Order.CustomerId == customerId && aa.Order.StationCustomerId==stationCustomerId).Select(aa => aa.PricePerUnit * aa.WeightInKg).Sum();

            if (OrderPaymentsDue == null)
            {
                OrderPaymentsDue = 0;
            }

            int paymentmadeCount = db.OrderPaymentMades.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId == stationCustomerId)
                .Select(aa => aa.PaymentMade).Count();

            int paymentsMade = 0;
            if (paymentmadeCount > 0)
            {
                paymentsMade = db.OrderPaymentMades.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId == stationCustomerId)
                .Select(aa => aa.PaymentMade).Sum();
            }

            OrderPaymentsDue -= paymentsMade;

            return OrderPaymentsDue;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (AmountPaidField.Value == 0)
            {
                MessageBox.Show("Please enter Amount Paid");
                return;
            }

            else if (AmountPaidField.Value > DueAmountField.Value)
            {
                MessageBox.Show("Amount paid cannot be greater than due amount");
                return;
            }

            OrderPaymentMade orderPayment = new OrderPaymentMade();
            orderPayment.CustomerId = customer.CustomerId;
            orderPayment.Date = DateTime.Now;
            orderPayment.StationCustomerId = customer.StationCustomerId;
            orderPayment.StationOrderPaymentMadeId =(int) Station.StationId;
            orderPayment.PaymentMade =(int) AmountPaidField.Value;
            orderPayment.StatusCode =(int) LocalDBStatusCode.Added;

            db.OrderPaymentMades.Add(orderPayment);

            try
            {
                db.SaveChanges();
                MessageBox.Show("Payment added successfully");
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Unexpected error occured \n" + ee.Message);
            }
        }

        private void AddOrderPayment_Load(object sender, EventArgs e)
        {

        }

        private void AmountPaidField_Enter(object sender, EventArgs e)
        {
            AmountPaidField.Select(0, AmountPaidField.Text.Length);
        }
    }
}
