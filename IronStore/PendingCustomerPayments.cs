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
using System.Diagnostics;
using System.Threading;
using IronStore.Helpers;

namespace IronStore
{
    public partial class PendingCustomerPayments : Form
    {
        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();

        public PendingCustomerPayments()
        {
            InitializeComponent();
          //  loadingLabel.Visible = true;           
        }

        private async void LoadButton_Click(object sender, EventArgs e)
        {
            WaitControls();
            
            await Task.Yield();

            int minPayment =(int) MinimumPaymentField.Value;            
            var customersIds = db.Customers.Select(ss=>new
            {

                customerId = ss.CustomerId,
                stationCustomerId = ss.StationCustomerId
            }                
                );            
            
            List<customerPayments> customerPaymentsList = new List<customerPayments>();
            
            foreach (var custId in customersIds)
            {
                int duePayment = LoadDuePayments(custId.customerId,custId.stationCustomerId);
                if (duePayment > minPayment)
                {
                    customerPayments custPayment = new customerPayments();
                    custPayment.CustomerName = db.Customers.Where(aa=>aa.CustomerId==custId.customerId && aa.StationCustomerId==custId.stationCustomerId).FirstOrDefault().Name;
                    custPayment.JoinedCustomerId = StationIdHelper.StationIdJoined(custId.stationCustomerId, custId.customerId);
                    
                    custPayment.DuePayment = duePayment;
                    customerPaymentsList.Add(custPayment);
                }

                
            }
            
            dataGridView1.DataSource = customerPaymentsList;
            LoadButton.Enabled = true;
            loadingLabel.Visible = false;
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

        private void WaitControls()
        {
            LoadButton.Enabled = false;
            loadingLabel.Visible = true;
        }

        private void useLess()
        {
            // int MinPayment =(int) MinimumPaymentField.Value;

            //// //var qwe = db.OrderLines.GroupBy(aa => aa.Order.CustomerId).Select(aa=>aa.Select(qq=>qq.PricePerUnit*qq.WeightInKg).Sum());


            //var ddd = from s in db.Customers
            //          join st in db.Orders
            //          on s.CustomerId equals st.OrderId
                      
            //          join d in db.OrderLines on st.OrderId equals d.OrderId
            //          group s by s.CustomerId
                      
            //          ;


            //// //   select SUM(PricePerUnit * WeightInKg), Customer.CustomerId from Customer
            //// //   inner join [Order]
            //// //   on [Order].CustomerId = Customer.CustomerId
            //// //   inner join [OrderLine]
            //// //   on [Order].OrderId =[OrderLine].OrderId
            //// // group by Customer.CustomerId




            //var tt =  db.OrderLines.GroupBy(aa => aa.Order.CustomerId).Select(rr => new { cust = rr.Key, paym = rr.Select( ee => (ee.PricePerUnit * ee.WeightInKg)).Sum() -  rr.Select(vv=>vv.Order.Customer.OrderPaymentMades.Select(ll=>ll.PaymentMade).Sum()).Sum()});

            //var dd = tt.ToList();

            //int r=1;

            //// List<customerPayments> customerPaymentsList = new List<customerPayments>();

            //// foreach (var ii in tt)
            //// { 
            ////     customerPayments custPayment = new customerPayments();
            ////     custPayment.CustomerName = db.Customers.Find(ii.cust).Name;


            ////     int count = db.OrderPaymentMades.Where(ss => ss.CustomerId == ii.cust).Count();

            ////     if (count > 0)
            ////     {
            ////         custPayment.CustomerPayment = (int)ii.paym - db.OrderPaymentMades.Where(ss => ss.CustomerId == ii.cust).Select(ttt => ttt.PaymentMade).Sum();
            ////     }

            ////     else
            ////         custPayment.CustomerPayment = (int)ii.paym;


            ////     customerPaymentsList.Add(custPayment);
            //// }
        }

    }

    public class customerPayments
    {
        public string CustomerName { get; set; }

        public int DuePayment { get; set; }

        public string JoinedCustomerId { get; set; }
    }

    
}