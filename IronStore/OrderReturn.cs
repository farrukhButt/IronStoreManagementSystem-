using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronStore.Entity;
using IronStore.Helpers;

namespace IronStore
{
    public partial class OrderReturn : Form
    {
        Order order;
        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();

        public OrderReturn(string joinedOrderId)
        {
            InitializeComponent();
            var orderIds = StationIdHelper.SeperateStationId(joinedOrderId);

            int orderId = int.Parse(orderIds[1]);
            int stationOrderId = int.Parse(orderIds[0]);
            order = db.Orders.Where(aa => aa.OrderId == orderId && aa.StationOrderId==stationOrderId).Include(aa => aa.OrderLines).FirstOrDefault();
        }

        private void OrderReturn_Load(object sender, EventArgs e)
        {
            InitializeItemList();

            CustomerNameLabel.Text = order.Customer.Name;

            DuePaymensField.Value = LoadDuePayments();
            FinalDueAmountField.Value = DuePaymensField.Value;
                       

            #region orderPaymentInitializtion
            var orderPayment = db.OrderPaymentMades.Where(aa => aa.OrderId == order.OrderId && aa.StationOrderId==order.StationOrderId).FirstOrDefault();
            
            int orderPaymentMade = 0;
            if (orderPayment != null)
            {
                orderPaymentMade = orderPayment.PaymentMade;
            }
            AmountPaidField.Value = orderPaymentMade;

            #endregion

            #region DataGridOriginalInitialization

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

            #endregion
        }

        private void InitializeItemList()
        {
            var itemsList = Helpers.ItemDropDownList.GetOrderItems(order);
            ItemDropDown.DataSource = itemsList;
            ItemDropDown.DisplayMember = "ItemComplete";
            ItemDropDown.ValueMember = "ItemId";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ItemDropDown.SelectedValue == null)
            {
                return;
            }

            int itemId = int.Parse(ItemDropDown.SelectedValue.ToString());
            var itemComplete = ItemDropDown.Text;

            var totalOriginalWieghtKg = order.OrderLines.Where(aa => aa.ItemId == itemId).FirstOrDefault().WeightInKg;

            double totalWeightReturnedKg = 0;

            double grams = (double)GramField.Value;
            double kg = (double)KiloField.Value;

            if (grams == 0) { totalWeightReturnedKg = kg; }
            else { totalWeightReturnedKg = kg + (grams / 1000); }

            if (totalWeightReturnedKg > totalOriginalWieghtKg)
            {
                MessageBox.Show("weight returned cant be greater than weight bought");
                return;
            }

            var pricePerUnit = order.OrderLines.Where(aaa => aaa.ItemId == itemId).FirstOrDefault().PricePerUnit;

            var totalPrice = pricePerUnit * totalWeightReturnedKg;
            dataGridViewReturned.Rows.Add(itemComplete, kg, grams, pricePerUnit, totalPrice, null, null, null, itemId);



            var itemList = ItemDropDown.DataSource as List<ItemDropDownList>;
            var item = itemList.Where(aa => aa.ItemId == itemId).FirstOrDefault();
            itemList.Remove(item);

            ItemDropDown.DataSource = null;
            ItemDropDown.DataSource = itemList;
            ItemDropDown.DisplayMember = "ItemComplete";
            ItemDropDown.ValueMember = "ItemId";

            KiloField.Value = 0;
            GramField.Value = 0;

            ItemsReturnedValueField.Value += (decimal)totalPrice;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var rows = dataGridViewReturned.Rows;

            if (rows.Count == 0)
            {
                MessageBox.Show("please enter some values");
                return;
            }


            //var duePayments = LoadPreviousBill();
            //if (duePayments != null)
            //{
            //    if (duePayments < ItemsReturnedValueField.Value)
            //    {
            //        var amountToBeReturned = ItemsReturnedValueField.Value - duePayments;

            //        MessageBox.Show("You must atleast return Rs "+ amountToBeReturned);
            //        return;
            //    }
            //}

            if (AmountReturnedField.Value > AmountPaidField.Value || AmountReturnedField.Value > ItemsReturnedValueField.Value)
            {
                MessageBox.Show("Amount returned cannot be greater than amount paid or the items returned");
                return;
            }

            #region ReadingDataGridReturned

            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i];

                var itemId = int.Parse(row.Cells["ItemIdColumn"].Value.ToString());

                var kg = double.Parse(row.Cells["KiloColumn"].Value.ToString());
                var grams = double.Parse(row.Cells["GramColumn"].Value.ToString());
                double totalReturnedWeightInKg;
                if (grams == 0) { totalReturnedWeightInKg = kg; }
                else { totalReturnedWeightInKg = kg + (grams / 1000); }

                order.OrderLines.Where(aa => aa.ItemId == itemId).FirstOrDefault().WeightInKg -= totalReturnedWeightInKg;
                order.OrderLines.Where(aa => aa.ItemId == itemId).FirstOrDefault().StatusCode = (int)LocalDBStatusCode.Updated;
            }

            #endregion

            var orderPayment = db.OrderPaymentMades.Where(aa => aa.OrderId == order.OrderId && aa.StationOrderId==order.StationOrderId).FirstOrDefault();
            if (orderPayment != null)
            {
                orderPayment.PaymentMade -= (int)AmountReturnedField.Value;
                orderPayment.StatusCode =(int) LocalDBStatusCode.Updated;
            }
            try
            {
                db.SaveChanges();
                MessageBox.Show("Items returned");
                this.Close();
            }
            catch(Exception ee)
            { 
                MessageBox.Show("un expected error occured \n" + ee.ToString());
            }

        }

        private int LoadDuePayments()
        {
            int customerId =(int) order.CustomerId;
            int stationCustomerId = (int)order.StationCustomerId;           

            var OrderPayments =(int?) db.OrderLines.Where(aa => aa.Order.CustomerId == customerId && aa.Order.StationCustomerId==stationCustomerId).Select(aa => aa.PricePerUnit * aa.WeightInKg).Sum();

            if (OrderPayments == null)
            {
                OrderPayments = 0;
            }

            int paymentmadeCount = db.OrderPaymentMades.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId==stationCustomerId)
                .Select(aa => aa.PaymentMade).Count();

            int paymentsMade = 0;
            if (paymentmadeCount > 0)
            {
                paymentsMade = db.OrderPaymentMades.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId == stationCustomerId)
                .Select(aa => aa.PaymentMade).Sum();
            }

            int OrderPaymentDue = 0;            

            OrderPaymentDue =(int) OrderPayments- paymentsMade;

            return OrderPaymentDue;
        }

        private void ItemsReturnedValueField_ValueChanged(object sender, EventArgs e)
        {
            FinalDueAmountField.Value -= ItemsReturnedValueField.Value;
        }

        private void AmountReturnedField_ValueChanged(object sender, EventArgs e)
        {
            FinalDueAmountField.Value -= AmountReturnedField.Value;
        }
    }
}
