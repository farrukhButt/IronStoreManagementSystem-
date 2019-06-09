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
    public partial class EditCustomer : Form
    {
        int _id;
        int _customerStationID;

        public EditCustomer(string id)
        {
            List<string> seperate = Helpers.StationIdHelper.SeperateStationId(id);
            _id = int.Parse(seperate[1]);
            _customerStationID = int.Parse(seperate[0]);
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var supplier = db.Customers.Where(a => a.CustomerId == _id && a.StationCustomerId == _customerStationID).FirstOrDefault();
            CompanyName.Text = supplier.Name.Trim();
            Phone.Text = supplier.Phone.Trim();
            Adress.Text = supplier.Address.Trim();
            City.Text = supplier.City.Trim();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string nameCompany = CompanyName.Text;
            string adress = Adress.Text;
            string phoneNo = Phone.Text;
            string city = City.Text;
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            Entity.Customer customer = db.Customers.Where(a => a.CustomerId == _id && a.StationCustomerId == _customerStationID).FirstOrDefault();
            //IronStore.EntityFramework.SupplierBankDetail supplierBank = new EntityFramework.SupplierBankDetail();
            //List<IronStore.EntityFramework.SupplierBankDetail> bankList = new List<SupplierBankDetail>();
            customer.Name = nameCompany;
            customer.Address = adress;
            customer.Phone = phoneNo;
            customer.City = city;
            //----------------------
            //customer.StationCustomerId
            //customer.StatusCode
            db.SaveChanges();
            MessageBox.Show("Updated");
            this.Close();
        }
    }
}
