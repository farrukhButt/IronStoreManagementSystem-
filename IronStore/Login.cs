using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IronStore
{
    public partial class Login : Form
    {
        private IronStore.Entity.FaridiaIronStoreEntities db = new IronStore.Entity.FaridiaIronStoreEntities();
        public Login()
        {
          InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txt_username.Text == "" || txt_password.Text == "")
            {
                MessageBox.Show("Please enter Values");
                return;
            }
             
            else
            {
                string userName = txt_username.Text;
                string password = txt_password.Text;
               // MessageBox.Show(userName+password);
                if (db.Logins.Any(a=>a.UserName==userName && a.Password==password))
                {
                    MessageBox.Show("Login Success! Welcome to IronStore Software.");
                    this.Hide();                   
                    IronStoreMain main = new IronStoreMain();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Please enter valid Username and Password");
                }                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
         
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //txt_username.Text = "farrukh";
           //txt_password.Text = "123";
        }
        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            this.Hide();
            ResetPassword form = new ResetPassword();
            form.Show();
        }
    }
}