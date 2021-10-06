using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Repository
{
    public class Customer_Repo
    {
        //field
        protected readonly List<Customer> _customerDirectory = new List<Customer>();

        //Create
        public bool AddACustomer(Customer customerInfo)
        {
            int startingCount = _customerDirectory.Count();
            customerInfo.CustomerID = _customerDirectory.Count() + 1;//generate a CustomerID

            _customerDirectory.Add(customerInfo);

            bool customerAdded = (_customerDirectory.Count > startingCount) ? true : false;
            return customerAdded;
        }
        //Read
        public List<Customer> ReviewAllCustomers()
        {
            return _customerDirectory;
        }
        public Customer GetOneCustomerByID(int customerID)
        {
            foreach (var content in _customerDirectory)
            {
                if (content.CustomerID == customerID)
                {
                    return content;
                }
            }
            return null;
        }
        public bool UpdateAllCustomerInfo(Customer existingInfo, Customer newInfo)
        {
            if(existingInfo != null)
            {
                existingInfo.FirstName = newInfo.FirstName;
                existingInfo.LastName = newInfo.LastName;
                existingInfo.TypeOfCustomer = newInfo.TypeOfCustomer;
                return true;
            }
            return false;
        }
        public bool UpdateCustomerFirstName(Customer existingInfo, string newFirstName)
        {
            if(existingInfo != null)
            {
                existingInfo.FirstName = newFirstName;
                return true;
            }
            return false;
        }
        public bool UpdateCustomerLastName(Customer existingInfo, string newLastName)
        {
            if (existingInfo != null)
            {
                existingInfo.LastName = newLastName;
                return true;
            }
            return false;
        }
        public bool UpdateCustomerType(Customer existingInfo, CustomerType type)
        {
            if (existingInfo != null)
            {
                existingInfo.TypeOfCustomer = type;
                return true;
            }
            return false;
        }
        public bool RemoveCustomerByID(Customer deleteInfo)
        {
            bool success = _customerDirectory.Remove(deleteInfo);
            return success;
        }
    }
}
