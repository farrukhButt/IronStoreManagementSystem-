using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronStore.Helpers;
using IronStore.Entity;

namespace IronStore
{
    public partial class AddOldPayment : Form
    {
        int customerId;
        int stationCustomerId;
        AddOrder orderForm;
        public AddOldPayment(int custId,int stationCustId, AddOrder ord)
        {
            customerId = custId;
            stationCustomerId = stationCustId;
            orderForm = ord;
            InitializeComponent();
        }

        private void AddOldPayment_Load(object sender, EventArgs e)
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var customer = db.Customers.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId == stationCustomerId).FirstOrDefault();
            CustomerNameLabel.Text = customer.Name;
            CustomerIdLabel.Text = StationIdHelper.StationIdJoined(stationCustomerId, customerId);
            OldDuePaymentLabel.Text = LoadPreviousBill().ToString();
        }




        private int LoadPreviousBill()
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var OrderPaymentsDue = db.OrderLines.Where(aa => aa.Order.CustomerId == customerId && aa.Order.StationCustomerId == stationCustomerId).Select(aa => aa.PricePerUnit * aa.WeightInKg).Sum();
            if (OrderPaymentsDue == null)
            {
                OrderPaymentsDue = 0;
            }

            int paymentmadeCount = db.OrderPaymentMades.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId == stationCustomerId)
                .Select(aa => aa.PaymentMade).Count();

            double paymentsMade = 0;
            if (paymentmadeCount > 0)
            {
                paymentsMade = db.OrderPaymentMades.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId == stationCustomerId)
                .Select(aa => aa.PaymentMade).Sum();
            }




            OrderPaymentsDue -= paymentsMade;

            return (int)OrderPaymentsDue;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {

                FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();

                string oldPaymentItemName = "OldPaymentItem";

                var oldPaymentItemCount = db.Items.Where(aa => aa.ItemName == oldPaymentItemName).Count();

                Item oldPaymentItem;

                if (oldPaymentItemCount == 0)
                {
                    oldPaymentItem = new Item();
                    oldPaymentItem.IsExtra = true;
                    oldPaymentItem.ItemName = oldPaymentItemName;
                    oldPaymentItem.StatusCode = (int)LocalDBStatusCode.Added;

                    db.Items.Add(oldPaymentItem);
                    db.SaveChanges();
                }

                else
                {
                    oldPaymentItem = db.Items.Where(aa => aa.ItemName == oldPaymentItemName).FirstOrDefault();
                }


                Order order = new Order();
                order.CustomerId = customerId;
                order.IsAdvanceOrder = false;
                order.IsDelivered = true;
                order.OrderDate = DateTime.Now;
                order.StationCustomerId = stationCustomerId;
                order.StationOrderId = (int)Station.StationId;
                order.StatusCode = (int)LocalDBStatusCode.Added;


                OrderLine orderLine = new OrderLine();
                orderLine.ItemId = oldPaymentItem.ItemId;
                orderLine.PricePerUnit = (int)OldPaymentField.Value;
                orderLine.StationOrderLineId = (int)Station.StationId;
                orderLine.StatusCode = (int)LocalDBStatusCode.Added;
                orderLine.WeightInKg = 1;

                order.OrderLines.Add(orderLine);

                db.Orders.Add(order);

                db.SaveChanges();

                MessageBox.Show("Your Payment has been added successfully");

                int bill = LoadPreviousBill();
                orderForm.UpdateOldPayments(bill);

                this.Close();
            }
            catch(Exception ee)
            {
                MessageBox.Show("Un expected error has occured" + System.Environment.NewLine + ee.Message);
            }
        }
    }
}
