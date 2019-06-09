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
    public partial class AddExtraItem : Form
    {
        public AddExtraItem()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ExtraNameField.Text == null || ExtraNameField.Text == "")
            {
                MessageBox.Show("Please enter Name");
                return;
            }

            Item newExtra = new Item();
            newExtra.ItemName = ExtraNameField.Text;
            newExtra.IsExtra = true;
            newExtra.StatusCode =(int) LocalDBStatusCode.Added;

            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            db.Items.Add(newExtra);
            try
            {
                db.SaveChanges();
                MessageBox.Show("Added Successfully");
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Failed to save item \n" + ee.Message);
            }
        }

        private void AddExtraItem_Load(object sender, EventArgs e)
        {

        }
    }
}
