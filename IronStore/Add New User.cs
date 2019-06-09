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
    public partial class Add_New_User : Form
    {
        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();

        public Add_New_User()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //ManageUsers main = new ManageUsers();
            //main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
           
            if (textBox1.Text.Count() != 0 && textBox2.Text.Count() != 0 && textBox3.Text.Count()!=0 && textBox3.Text.Count()<15)
            {
                string userName = textBox1.Text;
                string password = textBox2.Text;
                string phone = textBox3.Text;
                string email = textBox4.Text;
                string designation = textBox5.Text;
                Entity.Login existingUser = db.Logins.Where(aa => aa.UserName.Equals(userName)).FirstOrDefault();
                if(existingUser == null)
                {
                    Entity.Login login = new Entity.Login();
                    login.UserName = userName;
                    login.Password = password;
                    login.Phone = phone;
                    login.Email = email;
                    login.Designation = designation;
                    db.Logins.Add(login);
                    db.SaveChanges();
                    MessageBox.Show("User Added");
                    this.Close();
                }
              else
                {
                    MessageBox.Show("UserName Already Exists");
                }
            }
            else
            {
                MessageBox.Show("Fill Empty Fields");
            }           
        }

        private void Add_New_User_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
