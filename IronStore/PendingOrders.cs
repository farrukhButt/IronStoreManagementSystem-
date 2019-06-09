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
    public partial class PendingOrders : Form
    {

        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
        public PendingOrders()
        {
            InitializeComponent();
        }

        private void PendingOrders_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
        {
            var Pending = db.Orders.Where(aa => aa.IsAdvanceOrder == true && aa.IsDelivered == false)
                .OrderBy(aa => aa.DeliveryDate).ToList();

            var pendingOrder = Pending.Select(aa => new
            {
                Order_Id = StationIdHelper.StationIdJoined(aa.StationOrderId,aa.OrderId),
                Customer_Name = aa.Customer.Name,
                Date = aa.OrderDate,
                DeliveryDate = aa.DeliveryDate,
                Total_Bill = CalculateTotalBill(aa.OrderId,aa.StationOrderId)
            }
                ).ToList();

            dataGridView1.DataSource = pendingOrder;
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

        private int CalculateTotalBill(int orderId, int stationOrderId)
        {
            int TotalBill = (int)db.OrderLines.Where(aa => aa.OrderId == orderId && aa.StationOrderId==stationOrderId).Select(aa => aa.PricePerUnit * aa.WeightInKg).Sum();
            return TotalBill;
        }

        private void MarkOrderButton_Click(object sender, EventArgs e)
        {
            var SelectedRow = dataGridView1.CurrentRow;
            if (SelectedRow == null)
            {
                MessageBox.Show("No data selected");
                return;
            }
            var joinedOrderId = SelectedRow.Cells["Order_Id"].Value.ToString();

            var orderIds = StationIdHelper.SeperateStationId(joinedOrderId);

            int orderId = int.Parse(orderIds[1]);
            int stationOrderId = int.Parse(orderIds[0]);

            var order = db.Orders.Where(aa => aa.OrderId == orderId && aa.StationOrderId == stationOrderId).FirstOrDefault();
            order.IsDelivered = true;
            order.StatusCode =(int) LocalDBStatusCode.Updated;
            try
            {
                db.SaveChanges();
                MessageBox.Show("SuccessFully marked delivered");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Fail to mark order \n" + ee.Message );
            }

            OnLoad();
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
