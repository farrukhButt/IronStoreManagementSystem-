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
    public partial class AddOrder : Form
    {
        private FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
        private bool isFirstAdd = true;
        private List<int> ListItemsIdsAdded = new List<int>();
        private Order _order;

        public AddOrder()
        {
            InitializeComponent();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            this.CustomerComboBox.SelectedIndexChanged -= new System.EventHandler(this.CustomerComboBox_SelectedIndexChanged);
            InitializeCustomerList();
            this.CustomerComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomerComboBox_SelectedIndexChanged);
            //this.ItemsCumboBox.SelectedIndexChanged -= new System.EventHandler();
            InitializeItemList();
            InitializeExtrasList();

            DeliveryDateField.Visible = false;
            DeliveryLabel.Visible = false;
        }

        #region ListInitialization

        private void InitializeItemList()
        {
            var itemsList = Helpers.ItemDropDownList.GetItemsList();
            ItemDropDown.DataSource = itemsList;
            ItemDropDown.DisplayMember = "ItemComplete";
            ItemDropDown.ValueMember = "ItemId";
            ItemsCumboBox.DataSource = itemsList;
            ItemsCumboBox.DisplayMember = "ItemComplete";
            ItemsCumboBox.ValueMember = "ItemId";
            ItemsCumboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ItemsCumboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void InitializeExtrasList()
        {
            var extrasList = Helpers.ItemDropDownList.GetExtrasList();
            ExtrasDropDown.DataSource = extrasList;
            ExtrasDropDown.DisplayMember = "ItemComplete";
            ExtrasDropDown.ValueMember = "ItemId";

        }

        private void InitializeCustomerList()
        {
            var customers = CustomersDropDown.GetCustomerForDropDown();
            CustomerDropDown.DataSource = customers;
            CustomerDropDown.DisplayMember = "CustomerName";
            CustomerDropDown.ValueMember = "JoinedCustomerId";
            CustomerComboBox.DataSource = customers;     
            CustomerComboBox.DisplayMember = "CustomerName";
            CustomerComboBox.ValueMember = "JoinedCustomerId";
            CustomerComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CustomerComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        #endregion


        private void AdvanceOrderCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (AdvanceOrderCheck.Checked)
            {
                DeliveryDateField.Visible = true;
                DeliveryLabel.Visible = true;
            }

            else
            {
                DeliveryDateField.Visible = false;
                DeliveryLabel.Visible = false;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
         {
            var itemId = int.Parse(ItemDropDown.SelectedValue.ToString());
            var extrasid = int.Parse(ExtrasDropDown.SelectedValue.ToString());

            

            if (itemId == 0 && extrasid == 0)
            {
                MessageBox.Show("Please select item or extras");
                return;
            }

            if (CustomerDropDown.SelectedValue == null)
            {
                MessageBox.Show("No customer selected");
                return;
            }

            if (CustomerComboBox.SelectedValue == null)
            {
                MessageBox.Show("No customer selected");
                return;
            }


            var extras = ExtrasDropDown.Text;

            #region itemDropDown

            if (itemId != 0)
            {
                var itemComplete = ItemDropDown.Text;
                var kg = KiloField.Value;
                var grams = GramField.Value;

                var pricePerUnit = PricePerUnitField.Value;

                var bundle = BundleField.Value;
                var lengths = LengthField.Value;
                var pieceCut = PieceCutField.Value;


                if (kg == 0 && grams == 0)
                {
                    MessageBox.Show("please enter weight");
                    return;
                }

                else if (pricePerUnit == 0)
                {
                    MessageBox.Show("Please enter Price per Unit");
                    return;
                }

                if (ListItemsIdsAdded.Contains(itemId))
                {
                    MessageBox.Show("an item cant be entered twice");
                    return;
                }

                else
                { ListItemsIdsAdded.Add(itemId); }

                decimal totalWeightInKg = 0;
                if (grams == 0) { totalWeightInKg = kg; }
                else { totalWeightInKg = kg + (grams / 1000); }

                var totalPrice = totalWeightInKg * pricePerUnit;

                totalPrice = Math.Round(totalPrice, 0);

                dataGridView1.Rows.Add(itemComplete, kg, grams, pricePerUnit, totalPrice, bundle, lengths, pieceCut, itemId);

                BillField.Value += totalPrice;
            }

            #endregion

            #region ExtrasDropDown
            else if (extrasid != 0)
            {


                var extraName = ExtrasDropDown.Text;
                var extraId = ExtrasDropDown.SelectedValue;
                var totalPrice = ExtrasPriceField.Value;

                if (totalPrice == 0)
                {
                    MessageBox.Show("Please enter total price");
                    return;
                }

                if (ListItemsIdsAdded.Contains(extrasid))
                {
                    MessageBox.Show("an extra cant be entered twice");
                    return;
                }

                else
                { ListItemsIdsAdded.Add(extrasid); }



                BillField.Value += totalPrice;

                dataGridView1.Rows.Add(extraName, null, null, null, totalPrice, null, null, null, extraId);
            }
            #endregion

            if (isFirstAdd)
            {
                isFirstAdd = false;
                LoadPreviousBill();
                //LoadCustomerAddress();               
            }
            TotalField.Value = (int) (BillField.Value + OldPaymentField.Value);      
            ResetControls();
        }



        private void ResetControls()
        {
            ItemDropDown.SelectedValue = 0;
            KiloField.Value = 0;
            GramField.Value = 0;
            PricePerUnitField.Value = 0;
            BundleField.Value = 0;
            LengthField.Value = 0;
            PieceCutField.Value = 0;
            ExtrasDropDown.SelectedValue = 0;
            ExtrasPriceField.Value = 0;
            CustomerDropDown.Enabled = false;
            CustomerComboBox.Enabled = false;
            AddCustomerButton.Enabled = false;
        }

        private void LoadPreviousBill()
        {
            var customerIds = StationIdHelper.SeperateStationId(CustomerComboBox.SelectedValue.ToString());
            int stationCustomerId = int.Parse(customerIds[0]);
            int customerId = int.Parse(customerIds[1]);
            

            //var OrderPaymentsDue = db.OrderLines.Where(aa => aa.Order.CustomerId == customerId &&
            //  (aa.IsReturned == false || aa.IsReturned == null).Select(aa => aa.PricePerUnit * aa.WeightInKg).Sum();

            //var ItemsReturnedPayments = db.OrderLines.Where(aa => aa.Order.CustomerId == customerId &&
            //  (aa.IsReturned == true)).Select(aa => aa.PricePerUnit * aa.WeightInKg).Sum();


            var OrderPaymentsDue = db.OrderLines.Where(aa => aa.Order.CustomerId == customerId && aa.Order.StationCustomerId==stationCustomerId).Select(aa => aa.PricePerUnit * aa.WeightInKg).Sum();
            if (OrderPaymentsDue == null)
            {
                OrderPaymentsDue = 0;
            }

            int paymentmadeCount = db.OrderPaymentMades.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId==stationCustomerId)
                .Select(aa => aa.PaymentMade).Count();

            double paymentsMade = 0;
            if (paymentmadeCount > 0)
            {
                paymentsMade = db.OrderPaymentMades.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId == stationCustomerId)
                .Select(aa => aa.PaymentMade).Sum();
            }

            
                        

            OrderPaymentsDue -= paymentsMade;

            OldPaymentField.Value = (int)OrderPaymentsDue;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var totalPrice = int.Parse(e.Row.Cells["TotalPriceColumn"].Value.ToString());
            BillField.Value -= totalPrice;

            var itemId= int.Parse(e.Row.Cells["ItemIdColumn"].Value.ToString());
            ListItemsIdsAdded.Remove(itemId);
            TotalField.Value =(int) (BillField.Value + OldPaymentField.Value);
        }

        private void LoadCustomerDataf()
        {
                List<string> customerIds = StationIdHelper.SeperateStationId(CustomerComboBox.SelectedValue.ToString());
                int customerId = int.Parse(customerIds[1]);
                int stationCustomerId = int.Parse(customerIds[0]);
                var custoemr = db.Customers.Where(aa => aa.CustomerId == customerId && aa.StationCustomerId == stationCustomerId).FirstOrDefault();
                AddressTextBox.Text = custoemr.Address;
                CustomerPhone.Text = custoemr.Phone;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please enter orders");
                return;
            }
            #region order
            Order order = new Order();
            List<OrderLine> orderLinesList = new List<OrderLine>();
            order.OrderLines = orderLinesList;

            var customerIds = StationIdHelper.SeperateStationId(CustomerComboBox.SelectedValue.ToString());

            int customerId = int.Parse(customerIds[1]);
            int stationCustomerId = int.Parse(customerIds[0]);

            order.CustomerId = customerId;
            order.StationCustomerId = stationCustomerId;
            order.IsAdvanceOrder = AdvanceOrderCheck.Checked;
            order.Address = AddressTextBox.Text;
            order.Description = DescriptionTextBox.Text;
            order.IsDelivered = true;
            order.OrderDate = DateTime.Now;
            order.StationOrderId =(int) Station.StationId;
            order.StatusCode = (int)LocalDBStatusCode.Added;
            if (order.IsAdvanceOrder)
            {
                order.IsAdvanceOrder=true;
                order.DeliveryDate = DeliveryDateField.Value;
                order.IsDelivered = false;
            }

            #endregion

            #region payment

            if (PaymentMadeField.Value != 0)
            {
                if (PaymentMadeField.Value - TotalField.Value > 1)
                {
                    MessageBox.Show("Amount Paid cannot be greater than Total Value");
                    return;
                }

                OrderPaymentMade orderPayment = new OrderPaymentMade();                
                orderPayment.CustomerId = (int)order.CustomerId;
                orderPayment.StationCustomerId = order.StationCustomerId;
                orderPayment.Date = DateTime.Now;
                orderPayment.PaymentMade = (int)PaymentMadeField.Value;
                orderPayment.StationOrderPaymentMadeId =(int) Station.StationId;
                orderPayment.StatusCode = (int)LocalDBStatusCode.Added;
                order.OrderPaymentMades.Add(orderPayment);
            }

            #endregion

            var rows = dataGridView1.Rows;

            if (rows.Count == 0)
            {
                MessageBox.Show("please enter some values");
                return;
            }

            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i];

                #region Extras
                if (row.Cells["PricePerUnitColumn"].Value == null)
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.ItemId = int.Parse(row.Cells["ItemIdColumn"].Value.ToString());
                    orderLine.PricePerUnit = double.Parse(row.Cells["TotalPriceColumn"].Value.ToString());                    
                    orderLine.WeightInKg = 1;
                    orderLine.StationOrderLineId =(int) Station.StationId;
                    orderLine.StatusCode = (int)LocalDBStatusCode.Added;
                    //orderLine.isReturned=false
                    orderLinesList.Add(orderLine);
                }

                #endregion

                #region Items
                else
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.Bundle = int.Parse(row.Cells["BundleColumn"].Value.ToString());
                    if (orderLine.Bundle == 0) { orderLine.Bundle = null; }
                    
                    orderLine.ItemId = int.Parse(row.Cells["ItemIdColumn"].Value.ToString());
                    orderLine.Lengths = double.Parse(row.Cells["LengthColumn"].Value.ToString());
                    if (orderLine.Lengths == 0) { orderLine.Lengths = null; }
                    orderLine.PieceCut = int.Parse(row.Cells["PieceCutColumn"].Value.ToString());
                    orderLine.PricePerUnit = double.Parse(row.Cells["PricePerUnitColumn"].Value.ToString());
                    //orderLine.isReturned=false

                    var kg = double.Parse(row.Cells["KiloColumn"].Value.ToString());
                    var grams = double.Parse(row.Cells["GramColumn"].Value.ToString());
                    double totalWeightInKg;
                    if (grams == 0) { totalWeightInKg = kg; }
                    else { totalWeightInKg = kg + (grams / 1000); }
                    orderLine.WeightInKg = totalWeightInKg;
                    orderLine.StationOrderLineId =(int) Station.StationId;
                    orderLine.StatusCode =(int) LocalDBStatusCode.Added;
                    orderLinesList.Add(orderLine);
                }
                #endregion                

            }

            try
            {
                db.Orders.Add(order);
                db.SaveChanges();
                _order = order;
                
                MessageBox.Show("Order Saved");

                if (sender != null)
                {
                    this.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Order Failed");
            }
        }

        
        public void SetCustomer(string JoinedCustomerId)
        {
            InitializeCustomerList();
            if (CustomerComboBox.Enabled)
            {
                CustomerComboBox.SelectedValue = JoinedCustomerId;
            }
        }

        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            Add_New_Customer CustForm = new Add_New_Customer(this);
            CustForm.ShowDialog();
        }

        private void SaveAndPrintButton_Click(object sender, EventArgs e)
        {
            SaveButton_Click(null, null);

            if (_order == null)
            {
                MessageBox.Show("Order not saved");
                return;
            }

            List<InvoiceOrderList> OrdersList = new List<InvoiceOrderList>();
                     

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                InvoiceOrderList order = new InvoiceOrderList();
                if (row.Cells["ItemColumn"].Value!=null)
                {
                    order.Item = row.Cells["ItemColumn"].Value.ToString();
                }
                else
                {
                    order.Item = " ";
                }
                if (row.Cells["KiloColumn"].Value != null)
                {
                    order.Kilo = row.Cells["KiloColumn"].Value.ToString();
                }
                else
                {
                    order.Kilo = " ";
                }
                if (row.Cells["GramColumn"].Value != null)
                {
                    order.Gram = row.Cells["GramColumn"].Value.ToString();
                }
                else
                {
                    order.Gram = " ";
                }
                if (row.Cells["PricePerUnitColumn"].Value != null)
                {
                    order.PricePerUnit = row.Cells["PricePerUnitColumn"].Value.ToString();
                }
                else
                {
                    order.PricePerUnit = " ";
                }
                if (row.Cells["TotalPriceColumn"].Value != null)
                {
                    order.TotalPrice = row.Cells["TotalPriceColumn"].Value.ToString();
                }
                else
                {
                    order.TotalPrice = " ";
                }
                if (row.Cells["BundleColumn"].Value != null)
                {
                    order.Bundle = row.Cells["BundleColumn"].Value.ToString();
                }
                else
                {
                    order.Bundle = " ";
                }
                if (row.Cells["LengthColumn"].Value != null)
                {
                    order.Length = row.Cells["LengthColumn"].Value.ToString();
                }
                else
                {
                    order.Length = " ";
                }
                if (row.Cells["PieceCutColumn"].Value != null)
                {
                    order.PieceCut = row.Cells["PieceCutColumn"].Value.ToString();
                }
                else
                {
                    order.PieceCut = " ";
                }
              OrdersList.Add(order);
            }

            string total = TotalField.Value.ToString();
            string bill = BillField.Value.ToString();
            string paymentMade = PaymentMadeField.Value.ToString().Trim();
            string oldpayments = OldPaymentField.Value.ToString().Trim();
            string customer = CustomerComboBox.Text.ToString().Trim();
            string adress = AddressTextBox.Text.Trim();
            string invoiceId = StationIdHelper.StationIdJoined(_order.StationOrderId , _order.OrderId);
            string detail = DescriptionTextBox.Text.Trim();            
            string orderDate = DateTime.Today.ToShortDateString();
            string deliveryDate = string.Empty;
            if (AdvanceOrderCheck.Checked)
            {
                DateTime dateTime= DeliveryDateField.Value;
                 deliveryDate = dateTime.ToShortDateString();
            }
            else
            {
              deliveryDate = DateTime.Today.ToShortDateString();
            }
            Invoice invoice = new Invoice(OrdersList, total, bill, paymentMade, oldpayments, customer, adress, invoiceId, detail, deliveryDate, orderDate);
            invoice.Show();
            this.Close();
        }

        private void KiloField_Enter(object sender, EventArgs e)
        {
            KiloField.Select(0, KiloField.Text.Length);
        }

        private void GramField_Enter(object sender, EventArgs e)
        {
            GramField.Select(0, GramField.Text.Length);
        }

        private void PricePerUnitField_Enter(object sender, EventArgs e)
        {
            PricePerUnitField.Select(0, PricePerUnitField.Text.Length);
        }

        private void BundleField_Enter(object sender, EventArgs e)
        {
            BundleField.Select(0, BundleField.Text.Length);
        }

        private void LengthField_Enter(object sender, EventArgs e)
        {
            LengthField.Select(0, LengthField.Text.Length);
        }

        private void PieceCutField_Enter(object sender, EventArgs e)
        {
            PieceCutField.Select(0, PieceCutField.Text.Length);
        }

        private void PaymentMadeField_Enter(object sender, EventArgs e)
        {
            PaymentMadeField.Select(0, PaymentMadeField.Text.Length);
        }

        private void PaymentMadeField_Click(object sender, EventArgs e)
        {
            PaymentMadeField.Select(0, PaymentMadeField.Text.Length);
        }

        private void PaymentMadeField_ValueChanged(object sender, EventArgs e)
        {
           // PaymentMadeField_Leave(null,null);
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void OldPaymentField_ValueChanged(object sender, EventArgs e)
        {
            TotalField.Value = (int)(BillField.Value + OldPaymentField.Value);
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void TotalField_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void BillField_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        //private void LoadCustomerData(object sender, MeasureItemEventArgs e)
        //{
        //    LoadCustomerData();
        //}

        //private void LoadCustomerData(object sender, EventArgs e)
        //{
            
        //}

        private void CustomerComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadCustomerDataf();
        }

        private void CustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           LoadCustomerDataf();
        }

        private void CustomerDropDown_SelectedIn(object sender, EventArgs e)
        {
           // LoadCustomerDataf();
        }

        private void CustomerDropDown_TextChanged(object sender, EventArgs e)
        {
            //LoadCustomerDataf();
        }

        private void CustomerComboBox_TextChanged(object sender, EventArgs e)
        {
          //  LoadCustomerDataf();
        }

        private void CustomerComboBox_DropDownClosed(object sender, EventArgs e)
        {
          //  LoadCustomerDataf();
        }

        private void CustomerComboBox_TextUpdate(object sender, EventArgs e)
        {
           // LoadCustomerDataf();
        }

        private void KiloField_Enter_1(object sender, EventArgs e)
        {
           // KiloField.
        }

        private void KiloField_GotFocused(object sender, EventArgs e)
        {
           // KiloField.Select(0,1);
        }

        private void KiloField_Click(object sender, EventArgs e)
        {
           // KiloField_GotFocused(null,null);
        }

        private void OldPaymentButton_Click(object sender, EventArgs e)
        {
            if (CustomerDropDown.SelectedValue == null)
            {
                MessageBox.Show("Please seelct some customer");
                return;
            }

            var joinedCustomerId = CustomerDropDown.SelectedValue.ToString();

            var CustomerIds = StationIdHelper.SeperateStationId(joinedCustomerId);

            int stationCustId = int.Parse(CustomerIds[0]);

            int custId = int.Parse(CustomerIds[1]);

            AddOldPayment oldPaymentForm = new AddOldPayment(custId, stationCustId,this);
            oldPaymentForm.ShowDialog();
        }

        public void UpdateOldPayments(int oldPayment)
        {
            OldPaymentField.Value = oldPayment;
        }

        private void PaymentMadeField_Leave(object sender, EventArgs e)
        {

        }

        private void PaymentMadeField_KeyPress(object sender, KeyPressEventArgs e)
        {
          if (e.KeyChar == (char)Keys.Return)
            {
                decimal total = TotalField.Value;
                decimal paymentMade = PaymentMadeField.Value;
                if (paymentMade > total)
                {
                    decimal returnAmount = paymentMade - total;
                    returnAmountField.Value = returnAmount;
                }
                else
                {
                    returnAmountField.Value = 0;
                }
            }            
        }

        private void ItemDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
