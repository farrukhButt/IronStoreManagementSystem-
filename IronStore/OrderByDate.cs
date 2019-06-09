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
    public partial class OrderByDate : Form
    {
        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
        public OrderByDate()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            var startDate = StartDateField.Value.Date;
            var endDate = EndDateField.Value;

            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var orders = db.Orders.Where(aa => aa.OrderDate >= startDate && aa.OrderDate <= endDate).OrderBy(aa=>aa.OrderDate).ToList();

         

            var orderDataGrid = orders.Select(aa => new
            {
                Order_Id = StationIdHelper.StationIdJoined(aa.StationOrderId,aa.OrderId),
                Customer_Name = aa.Customer.Name,
                Date = aa.OrderDate,
                IsAdvanceOrder=IsAdvance(aa.IsAdvanceOrder),
                DeliveryDate=DeliveryDate(aa),
                IsDelivered=IsDelivered(aa),
                Total_Bill=CalculateTotalBill(StationIdHelper.StationIdJoined(aa.StationOrderId, aa.OrderId))
            }
                ).ToList();


            dataGridView1.DataSource = orderDataGrid;
        }

        private int CalculateTotalBill(string joinedOrderId)
        {
            var OrderIds = StationIdHelper.SeperateStationId(joinedOrderId);

            int orderId = int.Parse(OrderIds[1]);
            int stationOrderId = int.Parse(OrderIds[0]);

            int TotalBill = (int)db.OrderLines.Where(aa => aa.OrderId == orderId && aa.StationOrderId == stationOrderId).Select(aa => aa.PricePerUnit * aa.WeightInKg).Sum();
            return TotalBill;
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
