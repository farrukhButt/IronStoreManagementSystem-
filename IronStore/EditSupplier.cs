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

namespace IronStore
{
    public partial class EditSupplier : Form
    {
        int _id;
        int _supplierStationID;
        public EditSupplier(string id)
        {
            List<string> seperate = Helpers.StationIdHelper.SeperateStationId(id);
            _id = int.Parse(seperate[1]);
            _supplierStationID = int.Parse(seperate[0]);
            InitializeComponent();
        }

        private void CompanyName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameCompany = CompanyName.Text;
            string adress = Adress.Text;
            string phoneNo = Phone.Text;
            string city = City.Text;
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            Entity.Supplier supplier = db.Suppliers.Where(a => a.SupplierId == _id && a.StationSupplierId == _supplierStationID).FirstOrDefault();
            //IronStore.EntityFramework.SupplierBankDetail supplierBank = new EntityFramework.SupplierBankDetail();
            //List<IronStore.EntityFramework.SupplierBankDetail> bankList = new List<SupplierBankDetail>();
            supplier.Name = nameCompany;
            supplier.Address = adress;
            supplier.Phone = phoneNo;
            supplier.City = city;
            db.SaveChanges();
            MessageBox.Show("Updated");
            this.Close();
        }

        private void EditSupplier_Load(object sender, EventArgs e)
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var supplier = db.Suppliers.Include(aa => aa.SupplierBankDetails).Where(a => a.SupplierId == _id && a.StationSupplierId == _supplierStationID).FirstOrDefault();
            CompanyName.Text = supplier.Name.Trim();
            Phone.Text = supplier.Phone.Trim();
            Adress.Text = supplier.Address.Trim();
            City.Text = supplier.City.Trim();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string nameCompany = CompanyName.Text;
            string adress = Adress.Text;
            string phoneNo = Phone.Text;
            string city = City.Text;
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            Entity.Supplier supplier = db.Suppliers.Where(a => a.SupplierId == _id && a.StationSupplierId == _supplierStationID).FirstOrDefault();
            //IronStore.EntityFramework.SupplierBankDetail supplierBank = new EntityFramework.SupplierBankDetail();
            //List<IronStore.EntityFramework.SupplierBankDetail> bankList = new List<SupplierBankDetail>();
            supplier.Name = nameCompany;
            supplier.Address = adress;
            supplier.Phone = phoneNo;
            supplier.City = city;
            db.SaveChanges();
            MessageBox.Show("Updated");
            this.Close();
        }
    }
}
