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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_New_Supplier newSupplierForm = new Add_New_Supplier();
            newSupplierForm.FormClosing += new FormClosingEventHandler(this.Add_New_Supplier_FormClosing);
            newSupplierForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            IronStoreMain main = new IronStoreMain();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            AccountNo.Text = string.Empty;
            Entity.FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();             
            var supplierList = db.Suppliers.Select(s => new
            {
                SupplierId = s.StationSupplierId.ToString()+"_"+s.SupplierId.ToString(),
                s.Name,
                s.Phone,
                s.City,              
                s.Address
            }).ToList();            
            dataGridView1.DataSource = supplierList;
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string id = row.Cells["SupplierID"].Value.ToString();
                GetAccounts(id);
            }
        }
        private void Add_New_Supplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            Supplier_Load(null,null);
        }

        private void DeleteSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            Supplier_Load(null, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string id = row.Cells["SupplierID"].Value.ToString();
                GetAccounts(id);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                DataGridViewRow rowBank = dataGridView2.SelectedRows[0];
                AccountNo.Text = rowBank.Cells["AccountNo"].Value.ToString().Trim();
            }
        }

        private void GetAccounts(string supplierId)
        {
            List<string> seperate = Helpers.StationIdHelper.SeperateStationId(supplierId);
            int supplierID= int.Parse(seperate[1]);
            int StationID = int.Parse(seperate[0]);
            AccountNo.Text = string.Empty;
            Entity.FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var accounts = db.SupplierBankDetails.Where(aa => aa.SupplierId == supplierID && aa.StationSupplierId== StationID).Select(s => new
            {
                ID = s.StationSupplierBankId + "_"+ s.SupplierBankId,
                AccountNo = s.AccountNo
            }).ToList();
            dataGridView2.DataSource = accounts;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string accountNo = AccountNo.Text;
            if (accountNo.Count() > 0)
            {
                if (dataGridView1.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    string id = row.Cells["SupplierID"].Value.ToString();
                    List<string> seperate = Helpers.StationIdHelper.SeperateStationId(id);
                    int supplierID = int.Parse(seperate[1]);
                    int StationID = int.Parse(seperate[0]);
                    Entity.FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
                    Entity.SupplierBankDetail supplierb = new SupplierBankDetail();
                    supplierb.SupplierId = supplierID; 
                    supplierb.StationSupplierId= StationID;                   
                    supplierb.StationSupplierBankId = (int)Station.StationId;
                    supplierb.AccountNo = accountNo;
                    db.SupplierBankDetails.Add(supplierb);
                    db.SaveChanges();
                    MessageBox.Show("Account Added");
                    AccountNo.Text = string.Empty;
                    GetAccounts(id);
                }
            }
            else
            {
                MessageBox.Show("Enter Account Number");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (AccountNo.Text.Count()!=0 && dataGridView2.SelectedRows.Count != 0)
            {
                DataGridViewRow rowBank = dataGridView2.SelectedRows[0];
                string SupplierbankIdC = rowBank.Cells["ID"].Value.ToString();
                List<string> seperate = Helpers.StationIdHelper.SeperateStationId(SupplierbankIdC);
                int SupplierbankId = int.Parse(seperate[1]);
                int STATIONSupplierbankId = int.Parse(seperate[0]);
                string accountNo = AccountNo.Text;
                if (accountNo.Count() > 0)
                {
                        DataGridViewRow row = dataGridView1.SelectedRows[0];
                        string seperateid = row.Cells["SupplierID"].Value.ToString();
                       // List<string> seperatesupplierID = Helpers.StationIdHelper.SeperateStationId(seperateid);
                       // int supplierID = int.Parse(seperatesupplierID[1]);
                        //int StationID = int.Parse(seperatesupplierID[0]);
                        Entity.FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();                       
                        Entity.SupplierBankDetail supplierb = db.SupplierBankDetails.Where(aa=>aa.SupplierBankId== SupplierbankId&& aa.StationSupplierBankId==STATIONSupplierbankId).FirstOrDefault();
                        supplierb.AccountNo = accountNo;
                        db.SaveChanges();
                        MessageBox.Show("Account Edited");
                        AccountNo.Text = string.Empty;
                        GetAccounts(seperateid);
                }                
            }
            else
            {
                MessageBox.Show("Select Account Number");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (AccountNo.Text.Count() != 0 && dataGridView2.SelectedRows.Count != 0)
            {
                DataGridViewRow rowBank = dataGridView2.SelectedRows[0];
                string bankId = (rowBank.Cells["ID"].Value.ToString());
                List<string> seperate1 = Helpers.StationIdHelper.SeperateStationId(bankId);
                int SupplierbankId = int.Parse(seperate1[1]);
                int STATIONSupplierbankId = int.Parse(seperate1[0]);
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                  string Supplierid = (row.Cells["SupplierID"].Value.ToString());
                List<string> seperate2 = Helpers.StationIdHelper.SeperateStationId(Supplierid);
                int supplierID = int.Parse(seperate2[1]);
                int StationID = int.Parse(seperate2[0]);
                Entity.FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
                    var BANKiD= db.SupplierBankDetails.Where(aa => aa.SupplierBankId == SupplierbankId && aa.StationSupplierBankId == STATIONSupplierbankId).FirstOrDefault();
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.SupplierBankDetails.Remove(BANKiD);
                    db.SaveChanges();
                    MessageBox.Show("Account Deleted");
                    AccountNo.Text = string.Empty;
                    GetAccounts(Supplierid);
                }
                else
                {
                    AccountNo.Text = string.Empty;
                    GetAccounts(Supplierid);
                }
            }
            else
            {
                MessageBox.Show("Select Account Number");
            }          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AccountNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string id = (row.Cells["SupplierID"].Value.ToString());
                SuppliersPayments payments = new SuppliersPayments(id);
                //SupplierPayments saccount = new SupplierPayments(id);
                payments.Show();
            }           
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void SearchName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Supplier_Load(null,null);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AccountNo.Text = string.Empty;
            if (SearchName.Text.Count() > 0 && SearchName.Text.All(char.IsDigit))
            {
                string searchName = SearchName.Text;
                Entity.FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
                var supplierList = db.Suppliers.Where(aa => aa.Phone.Equals(searchName)).Select(s => new
                {
                    SupplierId = s.StationSupplierId.ToString() + "_"+ s.SupplierId.ToString() ,
                    s.Name,
                    s.Phone,
                    s.City,
                    s.Address
                }).ToList();
                if (supplierList.Count() > 0)
                {
                    dataGridView1.DataSource = supplierList;
                    if (dataGridView1.SelectedRows.Count != 0)
                    {
                        DataGridViewRow row = dataGridView1.SelectedRows[0];
                        string id = (row.Cells["SupplierID"].Value.ToString());
                        GetAccounts(id);
                    }
                }
                else
                {
                    dataGridView2.DataSource = null;
                    MessageBox.Show("Cannot Find Supplier");
                }

            }
            else
            {
                MessageBox.Show("Enter Phone");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AccountNo.Text = string.Empty;
            if (SearchName.Text.Count() > 0)
            {
                string searchName = SearchName.Text;
                Entity.FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
                var supplierList = db.Suppliers.Where(aa => aa.Name.ToUpper().Contains(searchName.ToUpper())).Select(s => new
                {
                    SupplierId = s.StationSupplierId.ToString()+ "_" + s.SupplierId.ToString(),
                    s.Name,
                    s.Phone,
                    s.City,
                    s.Address
                }).ToList();
                if (supplierList.Count() > 0)
                {
                    dataGridView1.DataSource = supplierList;
                    if (dataGridView1.SelectedRows.Count != 0)
                    {
                        DataGridViewRow row = dataGridView1.SelectedRows[0];
                        string id = (row.Cells["SupplierID"].Value.ToString());
                        GetAccounts(id);
                    }
                }
                else
                {
                    dataGridView2.DataSource = null;
                    MessageBox.Show("Cannot Find Name");
                }

            }
            else
            {
                MessageBox.Show("Enter Name");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string id = (row.Cells["SupplierID"].Value.ToString());
                EditSupplier form = new EditSupplier(id);
                form.FormClosing += new FormClosingEventHandler(this.EditSupplier_FormClosing);
                form.Show();
            }
           
        }
        private void EditSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            Supplier_Load(null,null);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string id = (row.Cells["SupplierID"].Value.ToString());
                DeleteSupplier form = new DeleteSupplier(id);
                form.FormClosing += new FormClosingEventHandler(this.DeleteSupplier_FormClosing);
                form.Show();
            }
        }
    }
}

