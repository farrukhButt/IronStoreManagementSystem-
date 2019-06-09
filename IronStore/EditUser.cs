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
    public partial class EditUser : Form
    {
        int _id;
        
        public EditUser(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EditUser_Load(object sender, EventArgs e)
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
            string loginId = textBox6.Text;
            string userName = textBox1.Text;
            string password = textBox2.Text;
            string phone = textBox3.Text;
            string email = textBox4.Text;
            string designation = textBox5.Text;
            int id = int.Parse(loginId);
            Entity.Login login = db.Logins.Where(a=>a.LoginId== id).First();
            login.UserName = userName;
            login.Password = password;
            login.Phone = phone;
            login.Email = email;
            login.Designation = designation;
            db.SaveChanges();
            MessageBox.Show("User Updated");
            this.Close();        
        }
    }
}
