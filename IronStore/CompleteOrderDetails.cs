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
    public partial class CompleteOrderDetails : Form
    {
        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
        Order order = new Order();

        public CompleteOrderDetails(string joinedOrderId)
        {
            InitializeComponent();
            var OrderIds = StationIdHelper.SeperateStationId(joinedOrderId);
            int orderId = int.Parse(OrderIds[1]);
            int stationOrderId = int.Parse(OrderIds[0]);

            order = db.Orders.Where(aa => aa.OrderId == orderId && aa.StationOrderId == stationOrderId).FirstOrDefault();
            
            InitializeOrderDetails();
            InitializeDataGrid();
        }

        

        private void InitializeOrderDetails()
        {
            CustomerLabel.Text = order.Customer.Name;
            OrderIdLabel.Text = StationIdHelper.StationIdJoined(order.StationOrderId, order.OrderId);

            if (order.Address != null)
            {
                AddressField.Text = order.Address;
            }

            if (order.Description != null)
            {
                DescriptionField.Text = order.Description;
            }

            if (order.IsAdvanceOrder)
            {
                AdvanceOrderLabel.Text = "Yes";
                DeliveryDateLabel.Text = order.DeliveryDate.ToString();
                if (order.IsDelivered) { DeliveredLabel.Text = "Yes"; }
                else { DeliveredLabel.Text = "No"; }
                
            }

            else
            {
                AdvanceOrderLabel.Text = "No";
                DeliveredLabel.Text = "--";
                DeliveryDateLabel.Text = "--";
            }

            OrderDateLabel.Text = order.OrderDate.ToString();

            int TotalBill = (int)db.OrderLines.Where(aa => aa.OrderId == order.OrderId && aa.StationOrderId==order.StationOrderId).Select(aa => aa.PricePerUnit * aa.WeightInKg).Sum();

            TotalBillLabel.Text = TotalBill.ToString();

        }

        private void InitializeDataGrid()
        {

            foreach (var orderline in order.OrderLines)
            {
                if (orderline.Item.IsExtra == true)
                {
                    dataGridViewOriginal.Rows.Add(orderline.Item.ItemName, null, null, null, orderline.PricePerUnit, null, null, null, orderline.ItemId);
                    continue;
                }

                var item = db.Items.Find(orderline.ItemId);
                var itemComplete = ItemDropDownList.ConverItemToItemComplete(item);

                var kg = Math.Truncate((double)orderline.WeightInKg);
                var grams = orderline.WeightInKg - kg;
                grams = grams * 1000;
                grams = Math.Truncate((double)grams);
                var totalprice = orderline.PricePerUnit * orderline.WeightInKg;

                dataGridViewOriginal.Rows.Add(itemComplete.ItemComplete, kg, grams, orderline.PricePerUnit, totalprice, orderline.Bundle, orderline.Lengths, orderline.PieceCut, orderline.ItemId);
            }

        }

    }
}
