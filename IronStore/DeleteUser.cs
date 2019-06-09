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
    public partial class DeleteUser : Form
    {
        int _id;
        public DeleteUser(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var user = db.Logins.Find(_id);
            textBox1.Text = user.UserName;
            textBox2.Text = user.Password;
            textBox3.Text = user.Phone;
            textBox4.Text = user.Email;
            textBox5.Text = user.Designation;
            textBox6.Text = user.LoginId.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            int id = int.Parse(textBox6.Text);
            Entity.Login login = db.Logins.Find(id);
            db.Logins.Remove(login);
            db.SaveChanges();
            MessageBox.Show("User Deleted");
            this.Close();
        }
    }
}
