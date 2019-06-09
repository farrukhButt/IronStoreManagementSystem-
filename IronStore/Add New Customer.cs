using System;
using System.Windows.Forms;
using System.Linq;
using IronStore.Entity;
using IronStore.Helpers;

namespace IronStore
{
    public partial class Add_New_Customer : Form
    {
        FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
        int dataGridPage = 1;
        int pageSize = 10;

        private AddOrder orderForm;

        private OrderByCustomer orderByCustomer;

        private ViewCustomerPayment ViewCustomerPaymentform;

        int totalPages;

        public Add_New_Customer(OrderByCustomer form)
        {
            InitializeComponent();
            orderByCustomer = form;
            SaveButton.Enabled = false;
        }

        public Add_New_Customer(ViewCustomerPayment form)
        {
            InitializeComponent();
            ViewCustomerPaymentform = form;
            SaveButton.Enabled = false;
        }

        public Add_New_Customer()
        {
            InitializeComponent();
            this.SelectCustomerButton.Visible = false;
            this.AddPaymentButton.Visible = true;
        }

        public Add_New_Customer(AddOrder form)
        {
            InitializeComponent();
            orderForm = form;
        }

        // event for search button
        private void button5_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(SearchBox.Text)))
            {
                string name = SearchBox.Text;              
                var customers= db.Customers.Where(aa => aa.Name.ToUpper().Contains(name.ToUpper())).ToList();
                var helper = new Helpers.CustomerHelper();
                var customerss = helper.CustomerForDataGrid(customers);
                dataGridView1.DataSource = customerss;                
            }
        }


        // event for save button
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameField.Text) || string.IsNullOrEmpty(PhoneField.Text) || string.IsNullOrEmpty(CityField.Text) || string.IsNullOrEmpty(AddressField.Text))
            {
                MessageBox.Show("Please fill mendatory fields.");
            }
            else
            {
                Customer cust = new Customer();
                cust.Name = NameField.Text;
                cust.Phone = PhoneField.Text;
                cust.Address = AddressField.Text;
                cust.City = CityField.Text;
                cust.StationCustomerId =(int) Station.StationId;
                cust.StatusCode = (int)LocalDBStatusCode.Added;         
                db.Customers.Add(cust);
                db.SaveChanges();
                MessageBox.Show("User Added");

                LoadCustomers();
                var joinedCustomerId = StationIdHelper.StationIdJoined(cust.StationCustomerId, cust.CustomerId);
                if (orderForm != null)
                {
                    orderForm.SetCustomer(joinedCustomerId);
                }
                this.Close();
            }
        }

        private void Add_New_Customer_Load(object sender, EventArgs e)
        {
            totalPages =1+ db.Customers.Count() / pageSize;
            PageLabel.Text = dataGridPage.ToString()+"/" + totalPages.ToString();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            var customers = db.Customers.OrderByDescending(aa => aa.CustomerId).Take(pageSize).ToList();
            var helper = new Helpers.CustomerHelper();
            var customerss = helper.CustomerForDataGrid(customers);
            dataGridView1.DataSource = customerss;
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            
            if (dataGridPage<totalPages)
            {               

                var customers = db.Customers.OrderByDescending(aa => aa.CustomerId).Skip((dataGridPage)*pageSize).Take(pageSize).ToList();

                var helper = new Helpers.CustomerHelper();

                var customerss = helper.CustomerForDataGrid(customers);
              

                dataGridView1.DataSource = customerss;
                dataGridPage++;

                PageLabel.Text = dataGridPage.ToString() + "/" + totalPages.ToString();
            }

        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (dataGridPage > 1)
            {
                dataGridPage--;
                var customers = db.Customers.OrderByDescending(aa => aa.CustomerId).Skip((dataGridPage-1) * pageSize).Take(pageSize).ToList();

                var helper = new Helpers.CustomerHelper();

                var customerss = helper.CustomerForDataGrid(customers);


                dataGridView1.DataSource = customerss;
                PageLabel.Text = dataGridPage.ToString() + "/" + totalPages.ToString();
            }
        }

        private void SelectCustomerButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("No data selected");
                return;
            }

            
            var joinedCustomerId = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            if (orderByCustomer != null)
            {
                orderByCustomer.SetCustomer(joinedCustomerId);
            }

            else if (ViewCustomerPaymentform != null)
            {
           //     ViewCustomerPaymentform.SetCustomer(joinedCustomerId);
            }

            else if (orderForm != null)
            {
                orderForm.SetCustomer(joinedCustomerId);
            }
            this.Close();
        }

        private void SearchNumButton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(SearchBox.Text)))
            {
                string phone = SearchBox.Text;
                var customers = db.Customers.Where(aa => aa.Phone.Contains(phone)).ToList();
                var helper = new Helpers.CustomerHelper();
                var customerss = helper.CustomerForDataGrid(customers);
                dataGridView1.DataSource = customerss;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void AddPaymentButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("No data selected");
                return;
            }

            var joinedCustomerId = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            AddOrderPayment addPayment = new AddOrderPayment(joinedCustomerId);
            addPayment.Show();
        }

        private void ReturnPaymentButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("No data selected");
                return;
            }

            var joinedCustomerId = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            ReturnCustomerPayment returnPayment = new ReturnCustomerPayment(joinedCustomerId);
            returnPayment.Show();
        }

        private void EditCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            FaridiaIronStoreEntities db1 = new FaridiaIronStoreEntities();
            var customers = db1.Customers.OrderByDescending(aa => aa.CustomerId).Take(pageSize).ToList();
            var helper = new Helpers.CustomerHelper();
            var customerss = helper.CustomerForDataGrid(customers);
            dataGridView1.DataSource = customerss;
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("No data selected");
                return;
            }

            var joinedCustomerId = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            EditCustomer editCustomer = new EditCustomer(joinedCustomerId);
            editCustomer.FormClosing += new FormClosingEventHandler(this.EditCustomer_FormClosing);
            editCustomer.Show();
        }
    }
}
