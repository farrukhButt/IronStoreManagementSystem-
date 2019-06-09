using IronStore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronStore
{
    public partial class SuppliersPayments : Form
    {
        int _supplierID;
        int _supplierStationId;
        double _totalAmountToBPaid;
        public SuppliersPayments(string id)
        {
            List<string> seperate = Helpers.StationIdHelper.SeperateStationId(id);
            _supplierID = int.Parse(seperate[1]);
             _supplierStationId = int.Parse(seperate[0]);          
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void RefreshPaymentMade()
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
           var list= db.SupplierPaymentMades.Where(aa=>aa.SupplierId==_supplierID && aa.StationSupplierId==_supplierStationId).Select(s=> new {s.PaymentMade, s.Date }).ToList();
            dataGridView1.DataSource = list;
        }

        private void totalPaymentsToBepaid()
        {
            int totalDueAmount = 0;
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            List<SupplierDuePayment> list = db.SupplierDuePayments.Where(aa => aa.SupplierId == _supplierID && aa.StationSupplierId == _supplierStationId).ToList();
            foreach (SupplierDuePayment payments in list)
            {
                totalDueAmount = totalDueAmount + payments.AmountToBePaid;
            }
            _totalAmountToBPaid = totalDueAmount;
        }

        private void totalPaymentsMade()
        {
            int totalDueAmount = 0;
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            List<SupplierPaymentMade> list = db.SupplierPaymentMades.Where(aa => aa.SupplierId == _supplierID && aa.StationSupplierId == _supplierStationId).ToList();
            foreach (SupplierPaymentMade payments in list)
            {
                totalDueAmount = totalDueAmount + payments.PaymentMade;
            }
            TotalPaymentsMade.Text = totalDueAmount.ToString();
        }

        private void TotalRemainingDue()
        {
            RemainingDueAmount.Text = ((_totalAmountToBPaid) - int.Parse(TotalPaymentsMade.Text.ToString())).ToString();
        }

        private void RefreshAmountToPaid()
        {
           // FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
          //  var list = db.SupplierDuePayments.Where(aa => aa.SupplierId == _supplierID).Select(s => new { s.AmountToBePaid, s.Date }).ToList();
          //  dataGridView2.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string madePayments = MadePayment.Text;
            if (madePayments.Count()>0)
            {
                if (madePayments.All(char.IsDigit))
                {

                    FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
                    Entity.SupplierPaymentMade paymentMade = new SupplierPaymentMade();
                    paymentMade.Date = dateTimePicker1.Value;
                    paymentMade.SupplierId = _supplierID;
                    paymentMade.StationSupplierId = _supplierStationId;
                    paymentMade.PaymentMade = int.Parse(madePayments);
                    db.SupplierPaymentMades.Add(paymentMade);
                    db.SaveChanges();
                    MessageBox.Show("Payment Made");
                    MadePayment.Text = string.Empty;
                    RefreshPaymentMade();
                    totalPaymentsMade();
                    totalPaymentsToBepaid();
                    TotalRemainingDue();
                }
                else
                {
                    MessageBox.Show("Numbers Only");
                }
            }
            else
            {
                MessageBox.Show("Enter Value");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string paymentToBePaid = PaymentToBePaid.Text;
            if (paymentToBePaid.Count() > 0)
            {
                if (paymentToBePaid.All(char.IsDigit))
                {

                    FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
                    Entity.SupplierDuePayment payment = new SupplierDuePayment();
                    payment.Date = dateTimePicker2.Value;
                    payment.SupplierId = _supplierID;
                    payment.StationSupplierId = _supplierStationId;
                    payment.AmountToBePaid = int.Parse(paymentToBePaid);
                    db.SupplierDuePayments.Add(payment);
                    db.SaveChanges();
                    MessageBox.Show("AmountToBePaid Added");
                    PaymentToBePaid.Text = string.Empty;
                    RefreshAmountToPaid();
                    totalPaymentsMade();
                    totalPaymentsToBepaid();
                    TotalRemainingDue();
                }
                else
                {
                    MessageBox.Show("Numbers Only");
                }
            }
            else
            {
                MessageBox.Show("Enter Value");
            }

        }

        private void SuppliersPayments_Load(object sender, EventArgs e)
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var supplier = db.Suppliers.Where(aa => aa.SupplierId == _supplierID && aa.StationSupplierId == _supplierStationId).FirstOrDefault();
            SupplierID.Text = Helpers.StationIdHelper.StationIdJoined(supplier.StationSupplierId, supplier.SupplierId);
            SupplierName.Text = supplier.Name;
            RefreshPaymentMade();
            RefreshAmountToPaid();
            totalPaymentsMade();
            totalPaymentsToBepaid();
            TotalRemainingDue();
        }
       
        private void madePayment_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void TotalPaymentsMade_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
