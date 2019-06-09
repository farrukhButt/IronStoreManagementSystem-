using IronStore.Entity;
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

namespace IronStore
{
    public partial class DeleteSupplier : Form
    {
        int _id;
        int _supplierStationID;
        int _totalAmountToBPaid;
        int TotalPaymentsMade;
        int RemainingDueAmount;
        public DeleteSupplier(string id)
        {
            List<string> seperate = Helpers.StationIdHelper.SeperateStationId(id);
             _id = int.Parse(seperate[1]);
            _supplierStationID = int.Parse(seperate[0]);

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteSupplier_Load(object sender, EventArgs e)
        {
            Entity.FaridiaIronStoreEntities db = new Entity.FaridiaIronStoreEntities();
            var supplier = db.Suppliers.Include(aa => aa.SupplierBankDetails).Where(a => a.SupplierId == _id && a.StationSupplierId==_supplierStationID).FirstOrDefault();
            CompanyName.Text = supplier.Name;
            Phone.Text = supplier.Phone;
            Adress.Text = supplier.Address;
            City.Text = supplier.City;
            totalPaymentsToBepaid();
            totalPaymentsMade();
            TotalRemainingDue();
            DuePayment.Text = RemainingDueAmount.ToString();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Entity.FaridiaIronStoreEntities db = new Entity.FaridiaIronStoreEntities();
                var totalamounttobepaid = db.SupplierDuePayments.Where(aa => aa.SupplierId == _id && aa.StationSupplierId == _supplierStationID);
                var totalpaymentsmade = db.SupplierPaymentMades.Where(aa => aa.SupplierId == _id&&aa.StationSupplierId == _supplierStationID);
                var accounts = db.SupplierBankDetails.Where(aa => aa.SupplierId == _id&&aa.StationSupplierId == _supplierStationID);
                var supplier = db.Suppliers.Where(aa=>aa.SupplierId==_id&&aa.StationSupplierId==_supplierStationID).FirstOrDefault();
                db.SupplierPaymentMades.RemoveRange(totalpaymentsmade);
                db.SaveChanges();
                db.SupplierDuePayments.RemoveRange(totalamounttobepaid);
                db.SaveChanges();
                db.SupplierBankDetails.RemoveRange(accounts);
                db.SaveChanges();
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
                this.Close();
            }
            else
            {
                this.Close();
            }          
        }

        private void totalPaymentsToBepaid()
        {
            int totalDueAmount = 0;
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            List<SupplierDuePayment> list = db.SupplierDuePayments.Where(aa => aa.SupplierId == _id&& aa.StationSupplierId==_supplierStationID).ToList();
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
            List<SupplierPaymentMade> list = db.SupplierPaymentMades.Where(aa => aa.SupplierId == _id && aa.StationSupplierId == _supplierStationID).ToList();
            foreach (SupplierPaymentMade payments in list)
            {
                totalDueAmount = totalDueAmount + payments.PaymentMade;
            }
            TotalPaymentsMade = totalDueAmount;
        }

        private void TotalRemainingDue()
        {
            RemainingDueAmount = ((_totalAmountToBPaid) -TotalPaymentsMade);
        }

    }
}
