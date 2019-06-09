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

namespace IronStore
{
    public partial class Add_New_Supplier : Form
    {
        public Add_New_Supplier()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_New_Supplier_Load(object sender, EventArgs e)
        {

        }

        private void companyName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void Description_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Adress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void BankName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Branch_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void NTN_TextChanged(object sender, EventArgs e)
        {

        }

        private void Phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // string accountNo = AccountNo.Text;
        }

        private void AccountNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string nameCompany = CompanyName.Text;
            string adress = Adress.Text;
            string phoneNo = Phone.Text;
            string city = City.Text;
            Entity.FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            Entity.Supplier supplierExist = db.Suppliers.Where(aa => aa.Name.Equals(nameCompany)).FirstOrDefault();
            if (supplierExist == null)
            {
                if (phoneNo.Count() > 0 && phoneNo.Count() < 20)
                {
                    Entity.Supplier supplier = new Entity.Supplier();
                    supplier.Name = nameCompany;
                    supplier.Address = adress;
                    supplier.Phone = phoneNo;
                    supplier.City = city;
                    supplier.StationSupplierId = (int) Station.StationId;
                    db.Suppliers.Add(supplier);
                    db.SaveChanges();
                    MessageBox.Show("Saved");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Enter Valid PhoneNo");
                }
            }
            else
            {
                MessageBox.Show("Supplier Already Exists");
            }
        }
    }

}


