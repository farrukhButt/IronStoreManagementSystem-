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
    public partial class IronStoreMain : Form
    {
        public IronStoreMain()
        {
            InitializeComponent();
        }

        
        private void IronStoreMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login m = new Login();
            m.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OrderExtras orderExtras = new OrderExtras();
            orderExtras.Show();
            //main.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Supplier main = new Supplier();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_New_Customer main = new Add_New_Customer();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddOrder order = new AddOrder();
            order.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddExtraItem main = new AddExtraItem();
            main.Show();           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //this.Close();
            //Accounts main = new Accounts();
            //main.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddItem main = new AddItem();
            main.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           // this.Close();
           Reports main = new Reports();
           main.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ManageUsers main = new ManageUsers();
            main.Show();
        }

        private void IronStoreMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //PublishChanges publishChange = new PublishChanges();
            //publishChange.Show();

        }
    }
}