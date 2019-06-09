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
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (NameField.Text == null || NameField.Text == "")
            {
                MessageBox.Show("please enter name");
                return;
            }

            if (SotarField.Text == null || SotarField.Text == "")
            {

                DialogResult dialogResult = MessageBox.Show(" Sotar is not entered \n Do you want to save? ", " ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }


            if (ThicknessField.Text == null || ThicknessField.Text == "")
            {

                DialogResult dialogResult = MessageBox.Show(" Thickness is not entered \n Do you want to save? ", " ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            if (CityField.Text == null || CityField.Text == "")
            {
                MessageBox.Show("Please enter city");
                return;                
            }

            Item newItem = new Item();
            newItem.City = CityField.Text;
            newItem.IsExtra = false;
            newItem.ItemName = NameField.Text;
            newItem.Sotar = SotarField.Text;
            newItem.thickness = ThicknessField.Text;
            newItem.StatusCode = (int) LocalDBStatusCode.Added;

            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();

            db.Items.Add(newItem);

            try
            {
                db.SaveChanges();
                MessageBox.Show("Item Added Successfully");
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Failed to save item \n" + ee.Message);
            }           

        }
    }
}
