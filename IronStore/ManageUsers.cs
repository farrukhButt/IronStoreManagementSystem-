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
    public partial class ManageUsers : Form
    {   

        public ManageUsers()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            IronStoreMain main = new IronStoreMain();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_New_User newUserForm = new Add_New_User();
            newUserForm.FormClosing += new FormClosingEventHandler(this.Add_New_User_FormClosing);
            newUserForm.Show();
        }

        private void LoadDataToGrid()
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var UsersList = db.Logins.Select(s => new
              {
                LoginId = s.LoginId,
                UserName = s.UserName,
                Password = s.Password,
                Phone = s.Phone,
                Email = s.Email,
                Designation = s.Designation
              }).ToList();
            dataGridView1.DataSource = UsersList;
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }
        private void Add_New_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDataToGrid();
        }

        private void EditUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDataToGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count!=0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                var LoginId = row.Cells["LoginId"].Value;
                EditUser editUser = new EditUser(int.Parse(LoginId.ToString()));
                editUser.FormClosing += new FormClosingEventHandler(this.EditUser_FormClosing);
                editUser.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                var LoginId = row.Cells["LoginId"].Value;
                DeleteUser deleteUser = new DeleteUser(int.Parse(LoginId.ToString()));
                deleteUser.FormClosing += new FormClosingEventHandler(this.DeleteUser_FormClosing);
                deleteUser.Show();
            }
        }

        private void DeleteUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadDataToGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
