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
    public partial class OrderExtras : Form
    {
        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
        public OrderExtras()
        {
            InitializeComponent();
        }

        private void ReturnOrderButton_Click(object sender, EventArgs e)
        {
            string joinedOrderId = OrderIdField.Text;

            List<string> orderIds;
            int stationOrderId;
            int orderId;

            try
            {
                orderIds=StationIdHelper.SeperateStationId(joinedOrderId);
                stationOrderId = int.Parse(orderIds[0]);
                orderId = int.Parse(orderIds[1]);
            }
            catch
            {
                MessageBox.Show("Order id is not in correct format");
                return;
            }


            var orderCount = db.Orders.Where(aa => aa.OrderId == orderId && aa.StationOrderId == stationOrderId).Count();
            Order order;
            if (orderCount > 0)
            {
                order = db.Orders.Where(aa => aa.OrderId == orderId && aa.StationOrderId == stationOrderId).FirstOrDefault();
            }

            if (orderCount == 0)
            {
                MessageBox.Show("No such order found");
                return;
            }

            OrderReturn orderReturnForm = new OrderReturn(joinedOrderId);
            orderReturnForm.ShowDialog();
        }

        private void OrderDetailButton_Click(object sender, EventArgs e)
        {
            string joinedOrderId = OrderIdField.Text;

            List<string> orderIds;
            int stationOrderId;
            int orderId;

            try
            {
                orderIds = StationIdHelper.SeperateStationId(joinedOrderId);
                stationOrderId = int.Parse(orderIds[0]);
                orderId = int.Parse(orderIds[1]);
            }
            catch
            {
                MessageBox.Show("Order id is not in correct format");
                return;
            }


            var orderCount = db.Orders.Where(aa => aa.OrderId == orderId && aa.StationOrderId == stationOrderId).Count();
            Order order;
            if (orderCount > 0)
            {
                order = db.Orders.Where(aa => aa.OrderId == orderId && aa.StationOrderId == stationOrderId).FirstOrDefault();
            }

            if (orderCount == 0)
            {
                MessageBox.Show("No such order found");
                return;
            }

            CompleteOrderDetails orderDetail = new CompleteOrderDetails(joinedOrderId);
            orderDetail.Show();
        }
    }
}
