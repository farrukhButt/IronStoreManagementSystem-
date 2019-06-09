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
    public partial class ViewCustomerPayment : Form
    {
        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();

        public ViewCustomerPayment()
        {
            InitializeComponent();
         
        }

        private void InitializeCustomerList()
        {
            var customers = Helpers.CustomersDropDown.GetCustomerForDropDown();
            CustomerDropDown.DataSource = customers;
            CustomerDropDown.DisplayMember = "CustomerName";
            CustomerDropDown.ValueMember = "JoinedCustomerId";
        }

        public void SetCustomer(string joinedCustomerId)
        {
            CustomerDropDown.SelectedValue = joinedCustomerId;
        }

        private void CustomerDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomerDropDown.SelectedValue != null)
            {
                var joinedCustomerId = CustomerDropDown.SelectedValue.ToString();
                LoadDataGrid(joinedCustomerId);
                RemainingDuesField.Value = LoadDuePayments(joinedCustomerId);
            }
        }

        private int LoadDuePayments(string joinedCustomerId)
        {
            var customerIds = StationIdHelper.SeperateStationId(joinedCustomerId);
            int stationCustomerId = int.Parse(customerIds[0]);
            int customerId = int.Parse(customerIds[1]);


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

        private void LoadDataGrid(string joinedCustomerId)
        {
            var customerIds = StationIdHelper.SeperateStationId(joinedCustomerId);
            int stationCustomerId = int.Parse(customerIds[0]);
            int customerId = int.Parse(customerIds[1]);


            var payments = db.OrderPaymentMades.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId==stationCustomerId).ToList();

            if (payments.Count > 0)
            {
                var paymentGrid = payments.Select(
                    aa => new
                    {
                        CustomerName = aa.Customer.Name,
                        CustomerId = StationIdHelper.StationIdJoined(aa.StationCustomerId,aa.CustomerId),
                        Date = aa.Date,
                        Payment = aa.PaymentMade
                    }
                    ).ToList();
                dataGridView1.DataSource = paymentGrid;
            }

            else
            {
                MessageBox.Show("No payment to show");
            }

            

        }

        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            Add_New_Customer customerForm = new Add_New_Customer(this);
            customerForm.ShowDialog();
        }

        private void ViewCustomerPayment_Load(object sender, EventArgs e)
        {
            InitializeCustomerList();
            this.CustomerDropDown.SelectedIndexChanged += new System.EventHandler(this.CustomerDropDown_SelectedIndexChanged);
        }
    }
}
