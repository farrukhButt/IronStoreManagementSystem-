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
using System.Data.Entity;
using IronStore.Helpers;

namespace IronStore
{
    public partial class OrderByCustomer : Form
    {
        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();

        public OrderByCustomer()
        {
            InitializeComponent();
            InitializeCustomerList();
        }

        private void InitializeCustomerList()
        {

            CustomerDropDown.DataSource = Helpers.CustomersDropDown.GetCustomerForDropDown();
            CustomerDropDown.DisplayMember = "CustomerName";
            CustomerDropDown.ValueMember = "JoinedCustomerId";
        }

        public void SetCustomer(string joinedCustomerId)
        {
            CustomerDropDown.SelectedValue = joinedCustomerId;
        }

        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            Add_New_Customer customerForm = new Add_New_Customer(this);
            customerForm.ShowDialog();
        }

        private void CustomerDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomerDropDown.SelectedValue != null)
            {
                var joinedCustomerId = CustomerDropDown.SelectedValue.ToString();
                LoadDataGrid(joinedCustomerId);
            }
        }


        private void LoadDataGrid(string joinedCustomerId)
        {
            var customerIds = StationIdHelper.SeperateStationId(CustomerDropDown.SelectedValue.ToString());

            int customerId = int.Parse(customerIds[1]);
            int stationCustomerId = int.Parse(customerIds[0]);


            var orders = db.Orders.Where(aa => aa.CustomerId==customerId && aa.StationCustomerId==stationCustomerId).OrderByDescending(aa => aa.OrderDate).ToList();

            if (orders.Count==0)
            {
                MessageBox.Show("No Order to show");
                dataGridView1.DataSource = null;
                return;
            }

            var orderDataGrid = orders.Select(aa => new
            {
                Order_Id = StationIdHelper.StationIdJoined(aa.StationOrderId,aa.OrderId),
                Customer_Name = aa.Customer.Name,
                Date = aa.OrderDate,
                IsAdvanceOrder = IsAdvance(aa.IsAdvanceOrder),
                DeliveryDate = DeliveryDate(aa),
                IsDelivered = IsDelivered(aa),
                Total_Bill = CalculateTotalBill(StationIdHelper.StationIdJoined(aa.StationOrderId, aa.OrderId))
            }
                ).ToList();


            dataGridView1.DataSource = orderDataGrid;

        }

        private void OrderByCustomer_Load(object sender, EventArgs e)
        {
            InitializeCustomerList();
            this.CustomerDropDown.SelectedIndexChanged += new System.EventHandler(this.CustomerDropDown_SelectedIndexChanged);
        }

        private string IsAdvance(bool isAdvance)
        {
            if (isAdvance)
            {
                return "Yes";
            }

            else
                return "No";
        }

        private string DeliveryDate(Order order)
        {
            if (order.IsAdvanceOrder)
            {
                return order.DeliveryDate.ToString();
            }

            else return "--";
        }

        private string IsDelivered(Order order)
        {
            if (order.IsAdvanceOrder)
            {
                if (order.IsDelivered)
                    return "Yes";

                else
                    return "No";
            }

            else return "--";
        }

        private int CalculateTotalBill(string joinedOrderId)
        {
            var OrderIds = StationIdHelper.SeperateStationId(joinedOrderId);

            int orderId = int.Parse(OrderIds[1]);
            int stationOrderId = int.Parse(OrderIds[0]);

            int TotalBill = (int)db.OrderLines.Where(aa => aa.OrderId == orderId && aa.StationOrderId==stationOrderId).Select(aa => aa.PricePerUnit * aa.WeightInKg).Sum();
            return TotalBill;
        }

        private void CompleteOrderButton_Click(object sender, EventArgs e)
        {
            var SelectedRow = dataGridView1.CurrentRow;
            if (SelectedRow == null)
            {
                MessageBox.Show("No data selected");
                return;
            }
            var joinedOrderId = SelectedRow.Cells["Order_Id"].Value.ToString();
            CompleteOrderDetails completeOrder = new CompleteOrderDetails(joinedOrderId);
            completeOrder.Show();
        }
    }
}
