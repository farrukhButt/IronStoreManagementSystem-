using IronStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IronStore.Helpers
{
    class CustomerHelper
    {       


        public object CustomerForDataGrid(List<Customer> customers)
        {

            var customerss = customers.Select(aa => new
            {
                Name = trimStrings(aa.Name),
                CustomerId = aa.StationCustomerId+"_"+ aa.CustomerId,
                Address = trimStrings(aa.Address),
                Phone = trimStrings(aa.Phone),
                
            }
               ).ToList();

            return customerss;
        }

        private string trimStrings(string s)
        {
            if (s != null)
            {
                return s.Trim();
            }

            else return s;

        }

    }

    class CustomersDropDown
    {
        public string CustomerName { get; set; }

        public string JoinedCustomerId { get; set; }


        public static List<CustomersDropDown> GetCustomerForDropDown()
        {
            FaridiaIronStoreEntities db = new FaridiaIronStoreEntities();
            var customers = db.Customers.ToList();

            List<CustomersDropDown> CustomerDropDownList = new List<CustomersDropDown>();


            foreach (var cust in customers)
            {
                CustomersDropDown custDown = new CustomersDropDown();
                custDown.CustomerName = cust.Name.Trim();
                custDown.JoinedCustomerId = cust.StationCustomerId + "_" + cust.CustomerId;
                CustomerDropDownList.Add(custDown);
            }

            return CustomerDropDownList;
        }

    }
}
