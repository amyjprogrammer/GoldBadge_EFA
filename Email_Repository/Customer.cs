using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Repository
{
    public enum CustomerType { Current = 1, Past, Potential}
    //First and Last Name must be at least one character (stop an enter)
    public class Customer
    {
        public Customer() { }
        public Customer(string firstName, string lastName, CustomerType type)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfCustomer = type;
        }
        private string _firstName;
        private string _lastName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length < 1 || value.Any(x => !char.IsLetter(x)))
                    throw new FormatException("First Name must be at least one character in the alphabet with no special characters.");
                else
                    _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length < 1 || value.Any(x => !char.IsLetter(x)))
                    throw new FormatException("Last Name must be at least one character in the alphabet with no special characters.");
                else
                    _lastName = value;
            }
        }
        public string FullName
        {
            get
            {
                string fullName = FirstName + " " + LastName;
                return fullName;
            }
        }

        public int CustomerID { get; set; }
        public CustomerType TypeOfCustomer { get; set; }
        public string EmailMessage 
        {
            get
            {
                string message;
                switch (TypeOfCustomer)
                {
                    case CustomerType.Current:
                        message = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon."; 
                        break;
                    case CustomerType.Past:
                        message = "It's been a long time since we've heard from you, we want you back";
                        break;
                    case CustomerType.Potential:
                        message = "We currently have the lowest rates on Helicopter Insurance!";
                        break;
                    default:
                        message = " ";
                        break;
                }
                return message;
            } 
        }
    }
}
