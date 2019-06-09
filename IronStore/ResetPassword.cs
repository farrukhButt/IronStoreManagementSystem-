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
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string presetMasterPassword = "MasterPassword";
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            string userName = UserName.Text;
            string newPassword = NewPassword.Text;
            string masterPassword = MasterPassword.Text;
            if (userName.Count() != 0 && newPassword.Count() != 0 && masterPassword.Count() != 0)
            {
                Entity.Login existingUser = db.Logins.Where(aa => aa.UserName.Equals(userName)).FirstOrDefault();
                if (existingUser != null)
                {

                    if (masterPassword.Equals(presetMasterPassword))
                    {
                        existingUser.Password = newPassword;
                        MessageBox.Show("Password Changes");
                        db.SaveChanges();
                        this.Hide();
                        Login login = new Login();
                        login.Show();
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid MasterPassword");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Valid UserName");
                }
            }
            else
            {
                MessageBox.Show("Fill All Fields");
            }
        }
    }
}

